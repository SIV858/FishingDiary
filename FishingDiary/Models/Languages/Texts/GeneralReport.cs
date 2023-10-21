//20.10.23
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CGeneralReport
    {
        public string sGeneral { get; set; } = "General information";
        public string sDate { get; set; } = "Fishing date:";
        public string sWater { get; set; } = "Body of water:";
        public string sWeather { get; set; } = "Weather";
        public string sTemperature { get; set; } = "Air temperature:";
        public string sTemperatureLessThan { get; set; } = "Less than -40";
        public string sTemperatureMoreThan { get; set; } = "More than +40";
        public string sPrecipitation { get; set; } = "Precipitation:";
        public string sDirection { get; set; } = "Wind direction:";
        public string sSpeed { get; set; } = "Wind speed:";
        public string sPressure { get; set; } = "Pressure:";
        public string sMoonPhase { get; set; } = "Moon Phase";
        public string sGrowing { get; set; } = "Is the moon growing?";
        public string sInformation { get; set; } = "Fishing information";
        public string sMethod { get; set; } = "Fishing method:";
        public string sTackle { get; set; } = "Fishing tackle:";
        public string sGroundbait { get; set; } = "Groundbait:";
        public string sBaits { get; set; } = "Baits:";
        public string sResult { get; set; } = "Fishing result";
        public string sBiting { get; set; } = "Biting:";
        public string sCaught { get; set; } = "Caught fish:";
        public string sBiggest { get; set; } = "Biggest:";
        public string sWeight { get; set; } = "Weight:";
        public string sTotalWeight { get; set; } = "Total weight:";
        public string sDescription { get; set; } = "Description";

    }
}
