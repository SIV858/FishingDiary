﻿//19.09.20

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
    }
}
