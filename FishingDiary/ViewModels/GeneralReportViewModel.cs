//03.01.24
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using Avalonia.Controls;
using Avalonia.Media.Imaging;

using FishingDiary.Models;

namespace FishingDiary.ViewModels
{
    public class GeneralReportViewModel : ViewModelBase
    {
        // Current report
        public Report CurrentReport { get; }

        int _addId = PathsAndConstants.UNDEFINED_ID;
        string _methodsString = String.Empty;
        string _tacklesString = String.Empty;
        string _groundBaitsString = String.Empty;
        string _baitsString = String.Empty;

        // current selected item in the fish table
        private RecordFish _selectedFihsItem;

        public double dFontSize => Properties.GetInstance().FontSize;

        public string txtGeneralInfo => CommonData.GenLanguages.GeneralReport.sGeneral;
        public string txtDate => CommonData.GenLanguages.GeneralReport.sDate;
        public string txtWeather => CommonData.GenLanguages.GeneralReport.sWeather;
        public string txtWater => CommonData.GenLanguages.GeneralReport.sWater;
        public List<string> Waters => CommonData.EditableTexts.WatersText;
        public string txtPhoto => CommonData.GenLanguages.GeneralReport.sPhoto;


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
        public string txtUnknown => CommonData.GenLanguages.GeneralReport.sUnknown;
        public string txtNoFish => CommonData.GenLanguages.GeneralReport.sNoFish;
        public string txtWeak => CommonData.GenLanguages.GeneralReport.sWeak;
        public string txtAverage => CommonData.GenLanguages.GeneralReport.sAverage;
        public string txtGood => CommonData.GenLanguages.GeneralReport.sGood;
        public string txtExcellent => CommonData.GenLanguages.GeneralReport.sExcellent;


        public string txtCaught => CommonData.GenLanguages.GeneralReport.sCaught;
        public string txtBiggest => CommonData.GenLanguages.GeneralReport.sBiggest;
        public string txtWeight => CommonData.GenLanguages.GeneralReport.sWeight;
        public string txtTotalWeight => CommonData.GenLanguages.GeneralReport.sTotalWeight;
        public string txtDescription => CommonData.GenLanguages.GeneralReport.sDescription;
        public string txtClear => CommonData.GenLanguages.CommonTexts.sButtonClear;

        public List<string> Methods => CommonData.EditableTexts.MethodsText;
        public List<string> Tackles => CommonData.EditableTexts.TacklesText;
        public List<string> Groundbaits => CommonData.EditableTexts.GroundbaitsText;
        public List<string> Baits => CommonData.EditableTexts.BaitsText;

        public string txtId => CommonData.GenLanguages.GeneralReport.sId;
        public string txtNameFish => CommonData.GenLanguages.GeneralReport.sNameFish;
        public string txtQuantity => CommonData.GenLanguages.GeneralReport.sQuantity;
        public string txtBait => CommonData.GenLanguages.GeneralReport.sBait;
        public string txtMethodFish => CommonData.GenLanguages.GeneralReport.sMethodFish;
        public string txtOption => CommonData.GenLanguages.GeneralReport.sOption;
        public string txtAverageLength => CommonData.GenLanguages.GeneralReport.sAverageLength;
        public string txtMaxLength => CommonData.GenLanguages.GeneralReport.sMaxLength;
        public string txtMaxWeight => CommonData.GenLanguages.GeneralReport.sMaxWeight;
        public string txtTime => CommonData.GenLanguages.GeneralReport.sTime;

        public string txtAddRow => CommonData.GenLanguages.GeneralReport.sAddRow;
        public string txtDeleteRow => CommonData.GenLanguages.GeneralReport.sDeleteRow;

        public string txtOpenPhoto => CommonData.GenLanguages.GeneralReport.sOpenPhoto;

        Bitmap? _photo;

        public Bitmap? Photo 
        {
            get => _photo;
            set => this.RaiseAndSetIfChanged(ref _photo, value);
        }

        public string PhotoPath
        {
            get => CurrentReport.PhotoPath;
            set 
            { 
                this.RaiseAndSetIfChanged(ref CurrentReport._PhotoPath, value);
                if (Photo != null)
                {
                    Photo.Dispose();
                }
                // update photo on form
                Photo = Helpers.LoadFromFile(CurrentReport.PhotoPath);
                if (Photo == null)
                {
                    Photo = Helpers.LoadFromFile(PathsAndConstants.NO_PHOTO_PATH);
                    CurrentReport.PhotoPath = PathsAndConstants.NO_PHOTO_PATH;
                }
            }
        }

        public string Water
        {
            get => CurrentReport.BodyOfWater;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._BodyOfWater, value);
        }

        public DateTimeOffset StartDate
        {
            get => new DateTimeOffset(CurrentReport.StartDate);
            set => this.RaiseAndSetIfChanged(ref CurrentReport._StartDate, value.Date + CurrentReport.StartDate.TimeOfDay);
        }

        public TimeSpan StartTime
        {
            get => new TimeSpan(CurrentReport.StartDate.Hour, CurrentReport.StartDate.Minute, CurrentReport.StartDate.Second);
            set => this.RaiseAndSetIfChanged(ref CurrentReport._StartDate, CurrentReport.StartDate.Date + value);
        }

        public DateTimeOffset EndDate
        {
            get => new DateTimeOffset(CurrentReport.EndDate);
            set => this.RaiseAndSetIfChanged(ref CurrentReport._EndDate, value.DateTime + CurrentReport.EndDate.TimeOfDay);
        }

        public TimeSpan EndTime
        {
            get => new TimeSpan(CurrentReport.EndDate.Hour, CurrentReport.EndDate.Minute, CurrentReport.EndDate.Second);
            set => this.RaiseAndSetIfChanged(ref CurrentReport._EndDate, CurrentReport.EndDate.Date + value);
        }


        public AirTemperature Temperature
        {
            get => CurrentReport.AirTemperature;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._AirTemperature, value);
        }

        public Precipitation Precipitation
        {
            get => CurrentReport.Precipitation;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._Precipitation, value);
        }

        public WindDirection WindDirection
        {
            get => CurrentReport.WindDirection;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._WindDirection, value);
        }
        public WindSpeed WindSpeed
        {
            get => CurrentReport.WindSpeed;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._WindSpeed, value);
        }
        public ushort Pressure
        {
            get => CurrentReport.Pressure;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._Pressure, value);
        }
        public MoonPhase MoonPhase
        {
            get => CurrentReport.MoonPhase;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._MoonPhase, value);
        }
        public bool WaxingMoon
        {
            get => CurrentReport.WaxingMoon;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._WaxingMoon, value);
        }

        public Biting Biting
        {
            get => CurrentReport.Biting;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._Biting, value);
        }

        public float TotalWeight
        {
            get => CurrentReport.TotalWeight;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._TotalWeight, value);
        }

        public string Description
        {
            get => CurrentReport.Description;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._Description, value);
        }

        public int AddMethod
        {
            get => _addId;
            set
            {
                this.RaiseAndSetIfChanged(ref _addId, value);
                if (_addId != PathsAndConstants.UNDEFINED_ID)
                {
                    CurrentReport.AddMethod(_addId);
                    ListMethods = CurrentReport.GetMethodsText();
                }
            }
        }

        public string ListMethods
        {
            get => _methodsString;
            set => this.RaiseAndSetIfChanged(ref _methodsString, value);
        }

        public int AddTackle
        {
            get => _addId;
            set
            {
                this.RaiseAndSetIfChanged(ref _addId, value);
                if (_addId != PathsAndConstants.UNDEFINED_ID)
                {
                    CurrentReport.AddFishingTackle(_addId);
                    ListTackle = CurrentReport.GetFishingTacklesText();
                }
            }
        }

        public string ListTackle
        {
            get => _tacklesString;
            set => this.RaiseAndSetIfChanged(ref _tacklesString, value);
        }

        public int AddGroundbait
        {
            get => _addId;
            set
            {
                this.RaiseAndSetIfChanged(ref _addId, value);
                if (_addId != PathsAndConstants.UNDEFINED_ID)
                {
                    CurrentReport.AddGroundbait(_addId);
                    ListGroundbaits = CurrentReport.GetGroundbaitsText();
                }
            }
        }

        public string ListGroundbaits
        {
            get => _groundBaitsString;
            set => this.RaiseAndSetIfChanged(ref _groundBaitsString, value);
        }

        public int AddBait
        {
            get => _addId;
            set
            {
                this.RaiseAndSetIfChanged(ref _addId, value);
                if (_addId != PathsAndConstants.UNDEFINED_ID)
                {
                    CurrentReport.AddBait(_addId);
                    ListBaits = CurrentReport.GetBaitsText();
                }
            }
        }

        public string ListBaits
        {
            get => _baitsString;
            set => this.RaiseAndSetIfChanged(ref _baitsString, value);
        }

        public ObservableCollection<RecordFish> Fishes 
        {
            get => CurrentReport.CaughtFishes;
            set => this.RaiseAndSetIfChanged(ref CurrentReport._CaughtFishes, value);
        }

        public RecordFish SelectItem
        {
            get => _selectedFihsItem;
            set => this.RaiseAndSetIfChanged(ref _selectedFihsItem, value);
        }

        public ReactiveCommand<Unit, Unit> AddFish { get; set; }
        public ReactiveCommand<Unit, Unit> DeleteFish { get; set; }

        // selecting an item from the list of fish
        public ReactiveCommand<SelectionChangedEventArgs, Unit> SelectionChangedCommand { get; set; }



        public void ClearMethods()
        {
            CurrentReport.ClearMethods();
            ListMethods = String.Empty;
            AddMethod = PathsAndConstants.UNDEFINED_ID;
        }

        public void ClearTackles()
        {
            CurrentReport.ClearFishingTackles();
            ListTackle = String.Empty;
            AddTackle = PathsAndConstants.UNDEFINED_ID;
        }

        public void ClearGroundbaits()
        {
            CurrentReport.ClearGroundbaits();
            ListGroundbaits = String.Empty;
            AddGroundbait = PathsAndConstants.UNDEFINED_ID;
        }

        public void ClearBaits()
        {
            CurrentReport.ClearBaits();
            ListBaits = String.Empty;
            AddBait = PathsAndConstants.UNDEFINED_ID;
        }

        public void SetPhoto(string path)
        {
            PhotoPath = path;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public GeneralReportViewModel(string Path = null, uint ReportId = 0)
        {
            AddFish = ReactiveCommand.Create(() =>
            {
                CurrentReport.CaughtFishes.Add(new RecordFish());         
            });

            //To do: ID is not updated when deleted. The problem should go away when updating Avalonia
            DeleteFish = ReactiveCommand.Create(() =>
            {
                if (_selectedFihsItem != null)
                {      
                    CurrentReport.DeleteFish(_selectedFihsItem);
                }
            });

            if (String.IsNullOrEmpty(Path))
            {
                CurrentReport = new Report();
                _photo = Helpers.LoadFromFile(PathsAndConstants.NO_PHOTO_PATH);
                // New report - reset ID
                RecordFish.ResetId();

                // Settings DataTime
                CurrentReport.StartDate = DateTime.MinValue;
                CurrentReport.EndDate = DateTime.MinValue;
                if (Properties.GetInstance().DateMode == DateTimeMode.Previous)
                {
                    CurrentReport.StartDate = Properties.GetInstance().PreviousDataTime.Date;
                    CurrentReport.EndDate = Properties.GetInstance().PreviousDataTime.Date;
                }
                else
                {
                    CurrentReport.StartDate = DateTime.Now.Date;
                    CurrentReport.EndDate = DateTime.Now.Date;
                }


                if (Properties.GetInstance().TimeMode == DateTimeMode.Previous)
                {
                    CurrentReport.StartDate = CurrentReport.StartDate.AddTicks(Properties.GetInstance().PreviousDataTime.TimeOfDay.Ticks);
                    CurrentReport.EndDate = CurrentReport.EndDate.AddTicks(Properties.GetInstance().PreviousDataTime.TimeOfDay.Ticks);
                }
                else if (Properties.GetInstance().TimeMode == DateTimeMode.Now)
                {
                    CurrentReport.StartDate = CurrentReport.StartDate.AddTicks(DateTime.Now.TimeOfDay.Ticks);
                    CurrentReport.EndDate = CurrentReport.EndDate.AddTicks(DateTime.Now.TimeOfDay.Ticks);
                }

            }
            else
            {
                CurrentReport = ReportsList.GetReport(Path, ReportId);
                ListMethods = CurrentReport.GetMethodsText();
                ListTackle = CurrentReport.GetFishingTacklesText();
                ListGroundbaits = CurrentReport.GetGroundbaitsText();
                ListBaits = CurrentReport.GetBaitsText();
                _photo = Helpers.LoadFromFile(CurrentReport.PhotoPath);
                if (_photo == null)
                {
                    _photo = Helpers.LoadFromFile(PathsAndConstants.NO_PHOTO_PATH);
                    CurrentReport.PhotoPath = PathsAndConstants.NO_PHOTO_PATH;
                }
                RecordFish.SetId((ushort)(CurrentReport.CaughtFishes.Count + 1));
            }
        }
    }
}
