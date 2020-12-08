//19.09.20

using FishingDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace FishingDiary.ViewModels
{
    public class AddWindowViewModel : ViewModelBase
    {
        // Current report
        private Report report = new Report();

        public string txtHead => LanguageText.GetAddWindowHeadText();

        public double dFontSize => Properties.FontSize;

        public string txtAdd => LanguageText.GetAddButtonText();
        public string txtCancel => LanguageText.GetCancelButtonText();

        public string txtGeneralInfo => LanguageText.GetAddWindowGeneralText();
        public string txtDate => LanguageText.GetAddWindowDateText();
        public string txtWeather => LanguageText.GetAddWindowWeatherText();
        public string txtWater => LanguageText.GetAddWindowWaterText();
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


        public string Water
        {
            get => report.BodyOfWater;
            set => this.RaiseAndSetIfChanged(ref report.BodyOfWater, value);
        }

        public DateTime StartDateTime
        {
            get => report.StartDate;
            set => this.RaiseAndSetIfChanged(ref report.StartDate, value);
        }

        public DateTime EndDateTime
        {
            get => report.EndDate;
            set => this.RaiseAndSetIfChanged(ref report.EndDate, value);
        }

        /// <summary>
        /// Add current report
        /// Добавление текущего отчёта
        /// </summary>
        public void AddCurrentReport()
        {
            ReportsList.AddReport(report);
        }
    }
}
