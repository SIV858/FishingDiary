//15.09.24

using FishingDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.ViewModels
{
    internal class EditWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.EditReport.sHead;

        public double dFontSize => Properties.GetInstance().FontSize;

        public string txtChange => CommonData.GenLanguages.CommonTexts.sButtonChange;
        public string txtCancel => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        // Current report
        private GeneralReportViewModel generalReport { get; }

        // Current Short report
        private ShortReport shortReport;

        public EditWindowViewModel(uint CurrentReportID)
        {
            shortReport = ShortReportsList.FindReport(CurrentReportID);
            generalReport = new GeneralReportViewModel(shortReport.ReportPath, shortReport.ReportId);
        }

        /// <summary>
        /// Change current report
        /// </summary>
        public void EditCurrentReport()
        {
            if (String.IsNullOrEmpty(generalReport.CurrentReport.BodyOfWater))
            {
                return;
            }

            // saving the report
            generalReport.CurrentReport.SaveReport(shortReport.ReportId);

            // edit and save a short report
            shortReport.EditAndSaveReport(generalReport.CurrentReport);

            // saving the name of the body of wate if there is none
            if (!CommonData.EditableTexts.WatersText.Exists(x => x == generalReport.CurrentReport.BodyOfWater))
            {
                CommonData.EditableTexts.AddWater(generalReport.CurrentReport.BodyOfWater);
            }
        }
    }
}
