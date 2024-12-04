//28.11.24

using Avalonia.Media.Imaging;
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.ViewModels
{
    internal class StatisticsWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.StatWindow.sHead;

        public string txtPaintButton => CommonData.GenLanguages.StatWindow.sPaintButton;

        public string txtSave => CommonData.GenLanguages.StatWindow.sSave;

        public double dFontSize => Properties.GetInstance().FontSize;

        StatPainter _StatPainter;

        Bitmap? _ImageStat;


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

            _StatPainter.PaintStat();
            ImageStat = _StatPainter.GetImage();
        }

        public void SaveStat()
        {
            _StatPainter.Save();
        }

    }
}
