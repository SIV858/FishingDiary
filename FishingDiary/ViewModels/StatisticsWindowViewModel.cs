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
        private int _StartYear = 0;
        private int _EndYear = 0;
        private bool _IsVisibleYear = false;
        private bool _IsVisiblePeriod = false;

        private StatisticsTimeMode _PeriodMode = StatisticsTimeMode.AllTime;

        public string txtHead => CommonData.GenLanguages.StatWindow.sHead;

        public string txtPaintButton => CommonData.GenLanguages.StatWindow.sPaintButton;

        public string txtSave => CommonData.GenLanguages.StatWindow.sSave;

        public string txtPeriod => CommonData.GenLanguages.StatWindow.sPeriod;
        public string txtAllTimeMode => CommonData.GenLanguages.StatWindow.sAllTimeMode;
        public string txtYearMode => CommonData.GenLanguages.StatWindow.sYearMode;
        public string txtPeriodMode => CommonData.GenLanguages.StatWindow.sPeriodMode;
        public string txtYear => CommonData.GenLanguages.StatWindow.sYear;
        public string txtPeriodFrom => CommonData.GenLanguages.StatWindow.sPeriodFrom;
        public string txtPeriodTo => CommonData.GenLanguages.StatWindow.sPeriodTo;

        public List<int> Years => ReportsList.Years;
        public int CurrentYear
        {
            get => _CurrentYear;
            set => this.RaiseAndSetIfChanged(ref _CurrentYear, value);
        }
        public int StartYear
        {
            get => _StartYear;
            set
            {
                this.RaiseAndSetIfChanged(ref _StartYear, value);
                if (_StartYear > _EndYear)
                {
                    EndYear = _StartYear;
                }
            }
        }
        public int EndYear
        {
            get => _EndYear;
            set
            {
                this.RaiseAndSetIfChanged(ref _EndYear, value);
                if (_StartYear > _EndYear)
                {
                    StartYear = _EndYear;
                }
            }
        }

        public double dFontSize => Properties.GetInstance().FontSize;

        public bool IsVisibleYear {
            get => _IsVisibleYear;
            set => this.RaiseAndSetIfChanged(ref _IsVisibleYear, value);
        }
        public bool IsVisiblePeriod
        {
            get => _IsVisiblePeriod;
            set => this.RaiseAndSetIfChanged(ref _IsVisiblePeriod, value);
        }

        public StatisticsTimeMode PeriodMode
        {
            get => _PeriodMode;
            set 
            {
                this.RaiseAndSetIfChanged(ref _PeriodMode, value);
                switch(_PeriodMode)
                {
                    case StatisticsTimeMode.Year:
                        IsVisibleYear = true;
                        IsVisiblePeriod = false;
                        break;
                    case StatisticsTimeMode.Period:
                        IsVisibleYear = false;
                        IsVisiblePeriod = true;
                        break;
                    default:
                        IsVisibleYear = false;
                        IsVisiblePeriod = false;
                        break;
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
            if (PeriodMode == StatisticsTimeMode.Period)
            {
                _StatPainter.PaintStat(PeriodMode, Years[_StartYear], Years[_EndYear]);
            }
            else
            {
                _StatPainter.PaintStat(PeriodMode, Years[CurrentYear]);
            }
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
