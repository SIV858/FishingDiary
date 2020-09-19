//19.09.20

using FishingDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.ViewModels
{
    public class AddWindowViewModel : ViewModelBase
    {
        public string txtHead => LanguageText.GetAddWindowHeadText();
    }
}
