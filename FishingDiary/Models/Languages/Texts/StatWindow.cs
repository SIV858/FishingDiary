//28.11.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CStatWindow
    {
        public string sHead { get; set; } = "Statistics";
        public string sPaintButton { get; set; } = "Paint statistics";
        public string sHeader { get; set; } = "All time statistics";
        public string sNumber { get; set; } = "№";
        public string sFishName { get; set; } = "Name of fish";
        public string sQuantity { get; set; } = "Quantity";
        public string sBaits { get; set; } = "Baits";
        public string sPercent { get; set; } = "Percent";
        public string sSave { get; set; } = "Save";
        public string sPeriod { get; set; } = "Statistic time mode:";
        public string sAllTimeMode { get; set; } = "All time";
        public string sYearMode { get; set; } = "Year";
        public string sPeriodMode { get; set; } = "Period";
        public string sYear { get; set; } = "Year:";
        public string sAllReport { get; set; } = "Total fishing:";
        public string sAllFishes { get; set; } = "Total fish caught:";
    }
}
