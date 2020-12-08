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
        public AirTemperature AirTemperature;

        /// <summary>
        /// Precipitation
        /// Осадки
        /// </summary>
        public Precipitation Precipitation;

        /// <summary>
        /// Wind Direction 
        /// Направление ветра
        /// </summary>
        public WindDirection WindDirection;

        /// <summary>
        /// Wind Speed
        /// Скорость ветра
        /// </summary>
        public WindSpeed WindSpeed;

        /// <summary>
        /// Pressure
        /// Давление
        /// </summary>
        public ushort Pressure;

        /// <summary>
        /// Moon Phase
        /// Фаза луны
        /// </summary>
        public MoonPhase MoonPhase;

        /// <summary>
        /// Waxing Moon
        /// Луна растёт?
        /// </summary>
        public bool WaxingMoon;

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
        /// Caught Fish
        /// Пойманная рыба
        /// </summary>
        public string CaughtFish;

        /// <summary>
        /// Biggest fish
        /// Самая крупная рыба
        /// </summary>
        public string Biggest;

        /// <summary>
        /// Weight
        /// Вес
        /// </summary>
        public float Weight;

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
