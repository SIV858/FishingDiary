//28.11.24

using Avalonia.Media.Imaging;
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FishingDiary.ViewModels
{
    internal class StatisticsWindowViewModel : ViewModelBase
    {
        StatPainter _StatPainter;

        Bitmap? _ImageStat;

        private int _CurrentYear = 0;
        private bool _IsVisibleYear = false;

        private StatisticsTimeMode _PeriodMode = StatisticsTimeMode.AllTime;

        public string txtHead => CommonData.GenLanguages.StatWindow.sHead;

        public string txtPaintButton => CommonData.GenLanguages.StatWindow.sPaintButton;

        public string txtSave => CommonData.GenLanguages.StatWindow.sSave;

        public string txtPeriod => CommonData.GenLanguages.StatWindow.sPeriod;
        public string txtAllTimeMode => CommonData.GenLanguages.StatWindow.sAllTimeMode;
        public string txtYearMode => CommonData.GenLanguages.StatWindow.sYearMode;
        public string txtPeriodMode => CommonData.GenLanguages.StatWindow.sPeriodMode;
        public string txtYear => CommonData.GenLanguages.StatWindow.sYear;

        public List<int> Years => ReportsList.Years;
        public int CurrentYear
        {
            get => _CurrentYear;
            set => this.RaiseAndSetIfChanged(ref _CurrentYear, value);
        }

        public double dFontSize => Properties.GetInstance().FontSize;

        public bool IsVisibleYear {
            get => _IsVisibleYear;
            set => this.RaiseAndSetIfChanged(ref _IsVisibleYear, value);
        }

        public StatisticsTimeMode PeriodMode
        {
            get => _PeriodMode;
            set 
            {
                this.RaiseAndSetIfChanged(ref _PeriodMode, value);
                if (_PeriodMode != StatisticsTimeMode.Year)
                {
                    IsVisibleYear = false;
                }
                else
                {
                    IsVisibleYear = true;
                }
            }
        }

        public Bitmap? ImageStat
        {
            get => _ImageStat;
            set => this.RaiseAndSetIfChanged(ref _ImageStat, value);
        }

        public event EventHandler UpdateWindow = null;

        public bool IsEnabledPrev => !_StatPainter.FirstPage;
        public bool IsEnabledNext => !_StatPainter.EndPage;

        public string txtPageInfo
        {
            get => _StatPainter.CurrentPage.ToString() + " "
                + CommonData.GenLanguages.CommonTexts.sFrom + " "
                + _StatPainter.CountPages;
        }

        public uint CurrentPage
        {
            get => _StatPainter.CurrentPage;
            set
            {
                uint Value = 0;
                this.RaiseAndSetIfChanged(ref Value, value);
                _StatPainter.SetPage(Value);
            }
        }

        public StatisticsWindowViewModel()
        {
            ReportsList.LoadReports();
            _StatPainter = new StatPainter((float)dFontSize);
        }

        public void PaintStat()
        {
            _StatPainter.PaintStat(PeriodMode, Years[CurrentYear]);
            ImageStat = _StatPainter.GetImage();

            UpdateWindow?.Invoke(this, null);
        }

        public void IncrementPage()
        {
            ImageStat = _StatPainter.IncrementPage();
        }

        public void DecrementPage()
        {
            ImageStat = _StatPainter.DecrementPage();
        }

        public MemoryStream GetStatStream()
        {
            return _StatPainter.GetStream();
        }
    }
}
