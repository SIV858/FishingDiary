//20.10.23
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CSettings
    {
        public string sHead { get; set; } = "Settings";
        public string sLanguage { get; set; } = "Language: ";
        public string sDateMode { get; set; } = "Initial date setting mode: ";
        public string sTimeMode { get; set; } = "Initial time setting mode: ";
        public string sNew { get; set; } = "Сurrent";
        public string sPrevious { get; set; } = "Previous";
        public string sNull { get; set; } = "Zero";
    }
}
