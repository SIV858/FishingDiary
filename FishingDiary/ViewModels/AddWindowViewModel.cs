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

        public string txtHead => CommonData.GenLanguages.AddReport.sHead;

        public double dFontSize => Properties.FontSize;

        public string txtAdd => CommonData.GenLanguages.CommonTexts.sButtonAdd;
        public string txtCancel => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        public string txtGeneralInfo => CommonData.GenLanguages.GeneralReport.sGeneral;
        public string txtDate => CommonData.GenLanguages.GeneralReport.sDate;
        public string txtWeather => CommonData.GenLanguages.GeneralReport.sWeather;
        public string txtWater => CommonData.GenLanguages.GeneralReport.sWater;
        public string txtTemperature => CommonData.GenLanguages.GeneralReport.sTemperature;
        public string txtPrecipitation => CommonData.GenLanguages.GeneralReport.sPrecipitation;
        public string txtDirection => CommonData.GenLanguages.GeneralReport.sDirection;
        public string txtSpeed => CommonData.GenLanguages.GeneralReport.sSpeed;
        public string txtPressure => CommonData.GenLanguages.GeneralReport.sPressure;
        public string txtInformation => CommonData.GenLanguages.GeneralReport.sInformation;
        public string txtMethod => CommonData.GenLanguages.GeneralReport.sMethod;
        public string txtTackle => CommonData.GenLanguages.GeneralReport.sTackle;
        public string txtGroundbait => CommonData.GenLanguages.GeneralReport.sGroundbait;
        public string txtBaits => CommonData.GenLanguages.GeneralReport.sBaits;
        public string txtResult => CommonData.GenLanguages.GeneralReport.sResult;
        public string txtBiting => CommonData.GenLanguages.GeneralReport.sBiting;
        public string txtCaughtTxt => CommonData.GenLanguages.GeneralReport.sCaught;
        public string txtBiggest => CommonData.GenLanguages.GeneralReport.sBiggest;
        public string txtWeight => CommonData.GenLanguages.GeneralReport.sWeight;
        public string txtTotalWeight => CommonData.GenLanguages.GeneralReport.sTotalWeight;
        public string txtDescription => CommonData.GenLanguages.GeneralReport.sDescription;


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
