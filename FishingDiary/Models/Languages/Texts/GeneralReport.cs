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

        public string sPhoto { get; set; } = "Fishing photo:";
        public string sOpenPhoto { get; set; } = "Open photo";

        public string sWeather { get; set; } = "Weather";

        // Temperature
        public string sTemperature { get; set; } = "Air temperature:";
        public string sTemperatureLessThan { get; set; } = "Less than -40";
        public string sTemperatureMoreThan { get; set; } = "More than +40";

        // Precipitation
        public string sPrecipitation { get; set; } = "Precipitation:";
        public string sSun { get; set; } = "Sun";
        public string sСloudy { get; set; } = "Сloudy";
        public string sOvercast { get; set; } = "Overcast";
        public string sRain { get; set; } = "Rain";
        public string sThunderstorm { get; set; } = "Thunderstorm";
        public string sSnow { get; set; } = "Snow";
        public string sBlizzard { get; set; } = "Blizzard";

        // Direction of the wind
        public string sDirection { get; set; } = "Wind direction:";
        public string sNorth { get; set; } = "North";
        public string sEastern { get; set; } = "Eastern";
        public string sSouth { get; set; } = "South";
        public string sWest { get; set; } = "West";
        public string sNorthwest { get; set; } = "Northwest";
        public string sNortheast { get; set; } = "Northeast";
        public string sSoutheast { get; set; } = "Southeast";
        public string sSouthwest { get; set; } = "Southwest";

        // Speed of the wind
        public string sSpeed { get; set; } = "Wind speed:";
        public string sCalm { get; set; } = "Calm";
        public string sStrong { get; set; } = "Strong";
        public string sHurricane { get; set; } = "Hurricane";
        public string sTornado { get; set; } = "Tornado";

        public string sPressure { get; set; } = "Pressure:";

        // Moon Phase
        public string sMoonPhase { get; set; } = "Moon Phase:";
        public string sNewMoon { get; set; } = "New moon";
        public string sFullMoon { get; set; } = "Full moon";

        public string sGrowing { get; set; } = "Is the moon growing?";

        public string sInformation { get; set; } = "Fishing information";
        public string sMethod { get; set; } = "Fishing methods:";
        public string sTackle { get; set; } = "Fishing tackle:";
        public string sGroundbait { get; set; } = "Groundbaits:";
        public string sBaits { get; set; } = "Baits:";
        public string sResult { get; set; } = "Fishing result";

        // Fish activity
        public string sBiting { get; set; } = "Fish activity:";
        public string sNoFish { get; set; } = "No fish";
        public string sWeak { get; set; } = "Weak";
        public string sAverage { get; set; } = "Average";
        public string sGood { get; set; } = "Good";
        public string sExcellent { get; set; } = "Excellent";

        public string sCaught { get; set; } = "Caught fish:";
        // Fish table
        public string sId { get; set; } = "Id";
        public string sNameFish { get; set; } = "Name fish";
        public string sQuantity { get; set; } = "Quantity";
        public string sBait { get; set; } = "Bait";
        public string sMethodFish { get; set; } = "Method";
        public string sAverageLength { get; set; } = "Average length";
        public string sMaxLength { get; set; } = "Max length";
        public string sMaxWeight { get; set; } = "Max Weight";
        public string sTime { get; set; } = "Time";

        public string sAddRow { get; set; } = "Add row";
        public string sDeleteRow { get; set; } = "Delete row";


        public string sBiggest { get; set; } = "Biggest:";
        public string sWeight { get; set; } = "Weight:";
        public string sTotalWeight { get; set; } = "Total weight:";
        public string sDescription { get; set; } = "Description";

    }
}
