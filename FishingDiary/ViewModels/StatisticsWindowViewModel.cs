//28.11.24

using FishingDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.ViewModels
{
    internal class StatisticsWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.StatWindow.sHead;

        public double dFontSize => Properties.GetInstance().FontSize;
    }
}
