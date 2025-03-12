//28.11.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CStatWindow
    {
        public string sHead { get; set; } = "Statistics";
        public string sHeadSaveWindow { get; set; } = "Save statistics";
        public string sPaintButton { get; set; } = "Paint statistics";
        public string sHeader { get; set; } = "All time statistics";
        public string sHeaderYear { get; set; } = "Statistics for the year: ";
        public string sHeaderPeriod { get; set; } = "Statistics for the period from ";

        public string sNumber { get; set; } = "№";
        public string sFishName { get; set; } = "Name of fish";
        public string sQuantity { get; set; } = "Quantity";
        public string sBaits { get; set; } = "Baits";
        public string sMethod { get; set; } = "Method";
        public string sAverageLenght { get; set; } = "Average lenght";

        public string sPeriod { get; set; } = "Statistic time mode:";
        public string sAllTimeMode { get; set; } = "All time";
        public string sYearMode { get; set; } = "Year";
        public string sPeriodMode { get; set; } = "Period";
        public string sYear { get; set; } = "Year:";
        public string sPeriodFrom { get; set; } = "Period from";
        public string sPeriodTo { get; set; } = "to";

        public string sSave { get; set; } = "Save";

        public string sPercent { get; set; } = "Percent";
        public string sRecord { get; set; } = "Record";
        public string sSmall { get; set; } = "small";
        public string sAverage { get; set; } = "average";
        public string sGood { get; set; } = "good";
        public string sTrophy { get; set; } = "trophy";
        public string sNothing { get; set; } = "-";

        public string sAllReport { get; set; } = "Total fishing:";
        public string sAllFishes { get; set; } = "Total fish caught:";

        public string sRecordHeader { get; set; } = "All time records";
        public string sRecordHeaderYear { get; set; } = "Records for the year: ";
        public string sRecordHeaderPeriod { get; set; } = "Records for the period: ";

        public string sStatisticCatching { get; set; } = "caught on";
        public string sStatisticLenght { get; set; } = "lenght";
        public string sStatisticWeight { get; set; } = "weigh";
        public string sStatisticYear { get; set; } = "";
        public string sStatisticPcs { get; set; } = "pcs";
        public string sStatisticPcsInHour { get; set; } = "pcs/h";
        public string sCentimeter { get; set; } = "cm";
        public string sGram { get; set; } = "g";

        public string sStatisticFish { get; set; } = "Fish:";
        public string sStatisticVariety { get; set; } = "Variety:";
        public string sStatisticQuantity { get; set; } = "Quantity:";
        public string sStatisticNibble { get; set; } = "Nibble:";

        public string sBestDaysHeader { get; set; } = "Best days of all time";
        public string sBestDaysHeaderYear { get; set; } = "Best days of the year: ";
        public string sBestDaysHeaderPeriod { get; set; } = "Best days of the period: ";
        public string sBestDaysFirst { get; set; } = "first place";
        public string sBestDaysSecond { get; set; } = "second";
        public string sBestDaysThird { get; set; } = "third";
        public string sBestDaysAll { get; set; } = "all";
    }
}
