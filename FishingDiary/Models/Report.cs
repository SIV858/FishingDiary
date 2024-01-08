//17.09.20
using System;
using System.Collections.Generic;
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
        public string FishingMethod; //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        /// <summary>
        /// Fishing Tackle
        /// Рыболовные снасти
        /// </summary>
        public string FishingTackle; //rod, spinning, feeder, winter fishing rod

        /// <summary>
        /// Groundbait
        /// Прикормка
        /// </summary>
        public string Groundbait; //pearl barley, corn, millet

        /// <summary>
        /// Baits
        /// Насадки
        /// </summary>
        public string Baits; //bread, maggot, worms 

        /// <summary>
        /// Biting
        /// Клёв
        /// </summary>
        public Biting Biting;

        /// <summary>
        /// List of fish
        /// Список рыб
        /// </summary>
        public List<RecordFish> CaughtFish;

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


        public void SaveReport()
        {
            // to do
        }

    }
}
