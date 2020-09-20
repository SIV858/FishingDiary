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
        public double dFontSize => Properties.FontSize;
        public string txtGeneralInfo => LanguageText.GetAddWindowGeneralText();
        public string txtDate => LanguageText.GetAddWindowDateText();
        public string txWeather => LanguageText.GetAddWindowWeatherText();
        public string txWater => LanguageText.GetAddWindowWaterText();
        public string txtTemperature => LanguageText.GetAddWindowTemperatureText();
        public string txtPrecipitation => LanguageText.GetAddWindowPrecipitationText();
        public string txtDirection => LanguageText.GetAddWindowDirectionText();
        public string txtSpeed => LanguageText.GetAddWindowSpeedText();
        public string txtPressure => LanguageText.GetAddWindowPressureText();
        public string txtInformation => LanguageText.GetAddWindowInformationText();
        public string txtMethod => LanguageText.GetAddWindowMethodText();
        public string txtTackle => LanguageText.GetAddWindowTackleText();
        public string txtGroundbait => LanguageText.GetAddWindowGroundbaitText();
        public string txtBaits => LanguageText.GetAddWindowBaitsText();
        public string txtResult => LanguageText.GetAddWindowResultText();
        public string txtBiting => LanguageText.GetAddWindowBitingText();
        public string txtCaughtTxt => LanguageText.GetAddWindowCaughtText();
        public string txtBiggest => LanguageText.GetAddWindowBiggestText();
        public string txtWeight => LanguageText.GetAddWindowWeightText();
        public string txtTotalWeight => LanguageText.GetAddWindowTotalWeightText();
        public string txtDescription => LanguageText.GetAddWindowDescriptionText();

    }
}
