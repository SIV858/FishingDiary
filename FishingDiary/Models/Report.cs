//17.09.20
using Avalonia.Animation.Easings;
using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    /// <summary>
    /// One report
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Start date fishing
        /// </summary>
        public DateTime StartDate
        {
            get => _StartDate;
            set => _StartDate = value;
        }
        internal DateTime _StartDate = DateTime.Now;

        /// <summary>
        /// End date fishing
        /// </summary>
        public DateTime EndDate
        {
            get => _EndDate;
            set => _EndDate = value;
        }
        internal DateTime _EndDate = DateTime.Now;

        /// <summary>
        /// Body Of Water
        /// </summary>
        public string BodyOfWater
        {
            get => _BodyOfWater;
            set => _BodyOfWater = value;
        }
        internal string _BodyOfWater = String.Empty;

        /// <summary>
        /// The path to the photo of the pond
        /// </summary>
        public string PhotoPath
        {
            get => _PhotoPath;
            set => _PhotoPath = value;
        }
        internal string _PhotoPath = String.Empty;

        /// <summary>
        /// Air Temperature
        /// </summary>
        public AirTemperature AirTemperature
        {
            get => _AirTemperature;
            set => _AirTemperature = value;
        }
        internal AirTemperature _AirTemperature = AirTemperature.Plus15_Plus20;

        /// <summary>
        /// Precipitation
        /// </summary>
        public Precipitation Precipitation
        {
            get => _Precipitation;
            set => _Precipitation = value;
        }
        internal Precipitation _Precipitation = Precipitation.Sun;

        /// <summary>
        /// Wind Direction 
        /// </summary>
        public WindDirection WindDirection
        {
            get => _WindDirection;
            set => _WindDirection = value;
        }
        internal WindDirection _WindDirection = WindDirection.NorthWest;

        /// <summary>
        /// Wind Speed
        /// </summary>
        public WindSpeed WindSpeed
        {
            get => _WindSpeed;
            set => _WindSpeed = value;
        }
        internal WindSpeed _WindSpeed = WindSpeed.S2;

        /// <summary>
        /// Pressure
        /// </summary>
        public ushort Pressure
        {
            get => _Pressure;
            set => _Pressure = value;
        }
        internal ushort _Pressure = 745;

        /// <summary>
        /// Moon Phase
        /// </summary>
        public MoonPhase MoonPhase
        {
            get => _MoonPhase;
            set => _MoonPhase = value;
        }
        internal MoonPhase _MoonPhase = MoonPhase.P50;

        /// <summary>
        /// Waxing Moon
        /// </summary>
        public bool WaxingMoon
        {
            get => _WaxingMoon;
            set => _WaxingMoon = value;
        }
        internal bool _WaxingMoon = true;

        /// <summary>
        /// Fishing Method
        /// </summary>
        public List<DataElement> FishingMethods { get; set; } = new List<DataElement>(); //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        /// <summary>
        /// Fishing Tackle
        /// </summary>
        public List<DataElement> FishingTackles { get; set; } = new List<DataElement>(); //rod, spinning, feeder, winter fishing rod

        /// <summary>
        /// Groundbait
        /// </summary>
        public List<DataElement> Groundbaits { get; set; } = new List<DataElement>(); //pearl barley, corn, millet

        /// <summary>
        /// Baits
        /// </summary>
        public List<DataElement> Baits { get; set; } = new List<DataElement>(); //bread, maggot, worms 

        /// <summary>
        /// Biting
        /// </summary>
        public Biting Biting
        {
            get => _Biting;
            set => _Biting = value;
        }
        internal Biting _Biting = Biting.NoFishCaught;

        /// <summary>
        /// List of fish
        /// </summary>
        public ObservableCollection<RecordFish> CaughtFishes
        {
            get => _CaughtFishes;
            set => _CaughtFishes = value;
        }
        internal ObservableCollection<RecordFish> _CaughtFishes = new ObservableCollection<RecordFish>();

        /// <summary>
        /// Total Weight fishes
        /// </summary>
        public float TotalWeight
        {
            get => _TotalWeight;
            set => _TotalWeight = value;
        }
        internal float _TotalWeight = 0;

        /// <summary>
        /// Description fishing
        /// </summary>
        public string Description
        {
            get => _Description;
            set => _Description = value;
        }
        internal string _Description = String.Empty;


        public Report()
        {
            PhotoPath = PathsAndConstants.NO_PHOTO_PATH;
        }

        public void AddMethod(int Id)
        {
            if (!AddElemById(Id, CommonData.EditableTexts.Methods, FishingMethods))
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sParamNotFound +
                    CommonData.GenLanguages.GeneralReport.sMethod + Id.ToString());
            }
        }

        public string GetMethodsText()
        {
            return GetElemsText(FishingMethods);
        }

        public void ClearMethods()
        {
            FishingMethods.Clear();
        }

        public void AddFishingTackle(int Id)
        {
            if (!AddElemById(Id, CommonData.EditableTexts.FishingTackle, FishingTackles))
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sParamNotFound +
                    CommonData.GenLanguages.GeneralReport.sTackle + Id.ToString());
            }
        }

        public string GetFishingTacklesText()
        {
            return GetElemsText(FishingTackles);
        }

        public void ClearFishingTackles()
        {
            FishingTackles.Clear();
        }

        public void AddGroundbait(int Id)
        {
            if (!AddElemById(Id, CommonData.EditableTexts.Groundbaits, Groundbaits))
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sParamNotFound +
                    CommonData.GenLanguages.GeneralReport.sGroundbait + Id.ToString());
            }
        }

        public string GetGroundbaitsText()
        {
            return GetElemsText(Groundbaits);
        }

        public void ClearGroundbaits()
        {
            Groundbaits.Clear();
        }

        public void AddBait(int Id)
        {
            if (!AddElemById(Id, CommonData.EditableTexts.Baits, Baits))
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sParamNotFound +
                    CommonData.GenLanguages.GeneralReport.sBaits + Id.ToString());
            }
        }

        public string GetBaitsText()
        {
            return GetElemsText(Baits);
        }

        public void ClearBaits()
        {
            Baits.Clear();
        }

        /// <summary>
        /// Add an DataElement from one list to another by id
        /// If such an DataElement already exists, it will not be added
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="source">The list in which the search is carried out</param>
        /// <param name="destination">The list where the DataElement will be added</param>
        /// <returns>Sign of an DataElement being in the source list</returns>
        private bool AddElemById(int id, List<DataElement> source, List<DataElement> destination)
        {
            foreach (var method in source)
            {
                if (method.Id == id)
                {
                    // If such an element already exists, then do not add it
                    if (!destination.Exists(x => x.Id == method.Id))
                    {
                        destination.Add(method);
                    }
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Get a text representation of a list of elements
        /// </summary>
        /// <param name="elements">List of elements</param>
        /// <returns>Text representation of a list of elements/returns>
        private string GetElemsText(List<DataElement> elements)
        {
            string elemsText = "";

            if (elements != null)
            {
                foreach (var element in elements)
                {
                    elemsText += element.Text + ", ";
                }
            }

            return elemsText;
        }

        public void DeleteFish(RecordFish deleteFish)
        {
            foreach (var fish in CaughtFishes)
            {
                if (fish.Id > deleteFish.Id)
                {
                    fish.Id--;
                }
            }

            CaughtFishes.Remove(deleteFish);

            RecordFish.DecrementId();
        }

        public string SaveReport(uint reportId)
        {
            //Reports are broken down by year for easier searching
            string ReportPath = String.Format("{0}\\{1}", PathsAndConstants.REPORTS_PATH, StartDate.Year.ToString());
            if (!Directory.Exists(ReportPath))
            {
                Directory.CreateDirectory(ReportPath);
            }

            ReportPath += String.Format("\\{0}_{1}", reportId.ToString(), StartDate.ToShortDateString());
            Directory.CreateDirectory(ReportPath);

            string photoName = System.IO.Path.GetFileName(PhotoPath);

            if (photoName != PathsAndConstants.NO_PHOTO_FILE_NAME)
            {

                //copying an image and saving a new path to it
                string ImagePath = String.Format("{0}\\{1}", ReportPath, photoName);
                try
                {
                    File.Copy(PhotoPath, ImagePath);
                }
                catch (IOException)
                {

                }

                PhotoPath = ImagePath;
            }

            ReportPath += String.Format("\\{0}_report.json", reportId.ToString());

            try
            {
                //Write data to file
                using (StreamWriter writer = new StreamWriter(ReportPath))
                {
                    string json = JsonSerializer.Serialize<Report>(this);
                    writer.Write(json);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(ReportPath);
            }
            catch (JsonException)
            {
                throw new JsonException(ReportPath);
            }

            return ReportPath;
        }

    }
}
