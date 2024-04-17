//17.09.20
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FishingDiary.Models
{
    /// <summary>
    /// One report
    /// Один отчёт
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Start date fishing
        /// Начальная дата рыбалки
        /// </summary>
        public DateTime StartDate = DateTime.Now;

        /// <summary>
        /// End date fishing
        /// Конечная дата рыбалки
        /// </summary>
        public DateTime EndDate = DateTime.Now;

        /// <summary>
        /// Body Of Water
        /// Водоём
        /// </summary>
        public string BodyOfWater = "";

        /// <summary>
        /// The path to the photo of the pond
        /// </summary>
        public string PhotoPath;

        /// <summary>
        /// Air Temperature
        /// Температура воздуха
        /// </summary>
        public AirTemperature AirTemperature = AirTemperature.Plus15_Plus20;

        /// <summary>
        /// Precipitation
        /// Осадки
        /// </summary>
        public Precipitation Precipitation = Precipitation.Sun;

        /// <summary>
        /// Wind Direction 
        /// Направление ветра
        /// </summary>
        public WindDirection WindDirection = WindDirection.NorthWest;

        /// <summary>
        /// Wind Speed
        /// Скорость ветра
        /// </summary>
        public WindSpeed WindSpeed = WindSpeed.S2;

        /// <summary>
        /// Pressure
        /// Давление
        /// </summary>
        public ushort Pressure = 745;

        /// <summary>
        /// Moon Phase
        /// Фаза луны
        /// </summary>
        public MoonPhase MoonPhase = MoonPhase.P50;

        /// <summary>
        /// Waxing Moon
        /// Луна растёт?
        /// </summary>
        public bool WaxingMoon = true;

        /// <summary>
        /// Fishing Method
        /// Способ ловли
        /// </summary>
        public List<DataElement> FishingMethods = new List<DataElement>(); //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        /// <summary>
        /// Fishing Tackle
        /// Рыболовные снасти
        /// </summary>
        public List<DataElement> FishingTackles = new List<DataElement>(); //rod, spinning, feeder, winter fishing rod

        /// <summary>
        /// Groundbait
        /// Прикормка
        /// </summary>
        public List<DataElement> Groundbaits = new List<DataElement>(); //pearl barley, corn, millet

        /// <summary>
        /// Baits
        /// Насадки
        /// </summary>
        public List<DataElement> Baits = new List<DataElement>(); //bread, maggot, worms 

        /// <summary>
        /// Biting
        /// Клёв
        /// </summary>
        public Biting Biting;

        /// <summary>
        /// List of fish
        /// Список рыб
        /// </summary>
        public ObservableCollection<RecordFish> CaughtFishes = new ObservableCollection<RecordFish>();

        /// <summary>
        /// Total Weight fishes
        /// Общий вес всей рыбы
        /// </summary>
        public float TotalWeight;

        /// <summary>
        /// Description fishing
        /// Описание рыбалки
        /// </summary>
        public string Description;


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

        public void SaveReport()
        {
            // to do
        }

    }
}
