//28.11.24

using Avalonia.Media.Imaging;
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
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

        public StatisticsWindowViewModel()
        {
            ReportsList.LoadReports();
            _StatPainter = new StatPainter((float)dFontSize);
        }

        public void PaintStat()
        {

            _StatPainter.PaintStat(PeriodMode, Years[CurrentYear]);
            ImageStat = _StatPainter.GetImage();
        }

        public void SaveStat()
        {
            _StatPainter.Save();
        }

    }
}
