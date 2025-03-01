//19.09.20

using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

using FishingDiary.Models;
using Avalonia.Animation.Easings;
using System.Xml.Linq;
using Avalonia.Controls.Shapes;

namespace FishingDiary.ViewModels
{
    public class AddWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.AddReport.sHead;

        public double dFontSize => Properties.GetInstance().FontSize;

        public string txtLoad => CommonData.GenLanguages.CommonTexts.sButtonImport;
        public string txtAdd => CommonData.GenLanguages.CommonTexts.sButtonAdd;
        public string txtCancel => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        private GeneralReportViewModel generalReport { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddWindowViewModel()
        {
            generalReport = new GeneralReportViewModel();
        }

        /// <summary>
        /// </summary>
        public bool AddCurrentReport()
        {
            if (String.IsNullOrEmpty(generalReport.CurrentReport.BodyOfWater))
            {
                return false;
            }

            ShortReport shortReport = new ShortReport(generalReport.CurrentReport);

            // adding a report to the list
            ReportsList.AddReport(generalReport.CurrentReport);
            // saving the report and getting the path to it
            shortReport.ReportPath = System.IO.Path.GetRelativePath(System.IO.Directory.GetCurrentDirectory(),
                generalReport.CurrentReport.SaveReport(shortReport.ReportId));

            //adding a short report to the list and saving the list
            shortReport.SaveReport();

            // saving the name of the body of wate if there is none
            if (!CommonData.EditableTexts.WatersText.Exists(x => x == generalReport.CurrentReport.BodyOfWater))
            {
                CommonData.EditableTexts.AddWater(generalReport.CurrentReport.BodyOfWater);
            }

            return true;
        }

        public void LoadReport(string Data, string FishermanDiaryPath)
        {
            FisherDiaryParser parser = new FisherDiaryParser(Data);
            parser.Parse();

            generalReport.Water = parser.Water;
            generalReport.StartDate = parser.StartDate;
            generalReport.EndDate = parser.EndDate;
            generalReport.Temperature = parser.AirTemperature;
            generalReport.Precipitation = parser.Precipitation;
            generalReport.WindDirection = parser.WindDirection;
            generalReport.WindSpeed = parser.WindSpeed;
            generalReport.Pressure = parser.Pressure;
            generalReport.MoonPhase = parser.MoonPhase;
            generalReport.WaxingMoon = parser.WaxingMoon;
            generalReport.Biting = parser.Biting;
            generalReport.TotalWeight = parser.TotalWeight;
            generalReport.Description = parser.Description;

            foreach(var element in parser.Methods)
            {
                generalReport.AddMethod = (int)element.Id;
            }

            foreach (var element in parser.Tackles)
            {
                generalReport.AddTackle = (int)element.Id;
            }

            foreach (var element in parser.Groundbaits)
            {
                generalReport.AddGroundbait = (int)element.Id;
            }

            foreach (var element in parser.Baits)
            {
                generalReport.AddBait = (int)element.Id;
            }


            string sPath = FishermanDiaryPath + "\\photo\\" + parser.ImagePath;
            generalReport.SetPhoto(sPath);
        }
    }
}
