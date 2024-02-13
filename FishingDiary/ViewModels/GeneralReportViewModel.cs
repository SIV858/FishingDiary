//03.01.24
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

using FishingDiary.Models;

namespace FishingDiary.ViewModels
{
    public class GeneralReportViewModel : ViewModelBase
    {
        // Current report
        public Report CurrentReport { get; }

        public double dFontSize => Properties.FontSize;

        public string txtGeneralInfo => CommonData.GenLanguages.GeneralReport.sGeneral;
        public string txtDate => CommonData.GenLanguages.GeneralReport.sDate;
        public string txtWeather => CommonData.GenLanguages.GeneralReport.sWeather;
        public string txtWater => CommonData.GenLanguages.GeneralReport.sWater;

        // Temperature
        public string txtTemperature => CommonData.GenLanguages.GeneralReport.sTemperature;
        public string txtTemperatureLessThan => CommonData.GenLanguages.GeneralReport.sTemperatureLessThan;
        public string txtTemperatureMoreThan => CommonData.GenLanguages.GeneralReport.sTemperatureMoreThan;

        // Precipitation
        public string txtPrecipitation => CommonData.GenLanguages.GeneralReport.sPrecipitation;
        public string txtSun => CommonData.GenLanguages.GeneralReport.sSun;
        public string txtСloudy => CommonData.GenLanguages.GeneralReport.sСloudy;
        public string txtOvercast => CommonData.GenLanguages.GeneralReport.sOvercast;
        public string txtRain => CommonData.GenLanguages.GeneralReport.sRain;
        public string txtThunderstorm => CommonData.GenLanguages.GeneralReport.sThunderstorm;
        public string txtSnow => CommonData.GenLanguages.GeneralReport.sSnow;
        public string txtBlizzard => CommonData.GenLanguages.GeneralReport.sBlizzard;

        // Direction of the wind
        public string txtDirection => CommonData.GenLanguages.GeneralReport.sDirection;
        public string txtNorth => CommonData.GenLanguages.GeneralReport.sNorth;
        public string txtEastern => CommonData.GenLanguages.GeneralReport.sEastern;
        public string txtSouth => CommonData.GenLanguages.GeneralReport.sSouth;
        public string txtWest => CommonData.GenLanguages.GeneralReport.sWest;
        public string txtNorthwest => CommonData.GenLanguages.GeneralReport.sNorthwest;
        public string txtNortheast => CommonData.GenLanguages.GeneralReport.sNortheast;
        public string txtSoutheast => CommonData.GenLanguages.GeneralReport.sSoutheast;
        public string txtSouthwest => CommonData.GenLanguages.GeneralReport.sSouthwest;

        // Speed of the wind
        public string txtSpeed => CommonData.GenLanguages.GeneralReport.sSpeed;
        public string txtCalm => CommonData.GenLanguages.GeneralReport.sCalm;
        public string txtStrong => CommonData.GenLanguages.GeneralReport.sStrong;
        public string txtHurricane => CommonData.GenLanguages.GeneralReport.sHurricane;
        public string txtTornado => CommonData.GenLanguages.GeneralReport.sTornado;

        public string txtPressure => CommonData.GenLanguages.GeneralReport.sPressure;

        // Moon Phase
        public string txtMoonPhase => CommonData.GenLanguages.GeneralReport.sMoonPhase;
        public string txtNewMoon => CommonData.GenLanguages.GeneralReport.sNewMoon;
        public string txtFullMoon => CommonData.GenLanguages.GeneralReport.sFullMoon;

        public string txtGrowing => CommonData.GenLanguages.GeneralReport.sGrowing;

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
            get => CurrentReport.BodyOfWater;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.BodyOfWater, value);
        }

        public DateTime StartDateTime
        {
            get => CurrentReport.StartDate;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.StartDate, value + CurrentReport.StartDate.TimeOfDay);
        }

        public int StartHour
        {
            get => CurrentReport.StartDate.Hour;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.StartDate, CurrentReport.StartDate.AddHours(value - CurrentReport.StartDate.Hour));
        }

        public int StartMinute
        {
            get => CurrentReport.StartDate.Minute;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.StartDate, CurrentReport.StartDate.AddMinutes(value - CurrentReport.StartDate.Minute));
        }

        public DateTime EndDateTime
        {
            get => CurrentReport.EndDate;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.EndDate, value + CurrentReport.EndDate.TimeOfDay);
        }

        public int EndtHour
        {
            get => CurrentReport.EndDate.Hour;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.EndDate, CurrentReport.EndDate.AddHours(value - CurrentReport.EndDate.Hour));
        }

        public int EndMinute
        {
            get => CurrentReport.EndDate.Minute;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.EndDate, CurrentReport.EndDate.AddMinutes(value - CurrentReport.EndDate.Minute));
        }


        public AirTemperature Temperature
        {
            get => CurrentReport.AirTemperature;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.AirTemperature, value);
        }

        public Precipitation Precipitation
        {
            get => CurrentReport.Precipitation;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.Precipitation, value);
        }

        public WindDirection WindDirection
        {
            get => CurrentReport.WindDirection;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.WindDirection, value);
        }
        public WindSpeed WindSpeed
        {
            get => CurrentReport.WindSpeed;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.WindSpeed, value);
        }
        public ushort Pressure
        {
            get => CurrentReport.Pressure;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.Pressure, value);
        }
        public MoonPhase MoonPhase
        {
            get => CurrentReport.MoonPhase;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.MoonPhase, value);
        }
        public bool WaxingMoon
        {
            get => CurrentReport.WaxingMoon;
            set => this.RaiseAndSetIfChanged(ref CurrentReport.WaxingMoon, value);
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralReportViewModel()
        {
            CurrentReport = new Report();
        }
    }
}
