//19.09.20

using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

using FishingDiary.Models;

namespace FishingDiary.ViewModels
{
    public class AddWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.AddReport.sHead;

        public double dFontSize => Properties.FontSize;

        public string txtAdd => CommonData.GenLanguages.CommonTexts.sButtonAdd;
        public string txtCancel => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        public GeneralReportViewModel generalReport { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddWindowViewModel()
        {
            generalReport = new GeneralReportViewModel();
        }

        /// <summary>
        /// Add current report
        /// Добавление текущего отчёта
        /// </summary>
        public void AddCurrentReport()
        {
            ReportsList.AddReport(generalReport.CurrentReport);
            if (!CommonData.EditableTexts.WatersText.Exists(x => x == generalReport.CurrentReport.BodyOfWater))
            {
                CommonData.EditableTexts.AddWater(generalReport.CurrentReport.BodyOfWater);
            }
        }
    }
}
