//03.12.24;
using FishingDiary.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    internal class CalcStat
    {
        private int _ReportCount = 0;
        private uint _TotalFishCount = 0;

        StatisticsTimeMode _TimeMode = StatisticsTimeMode.AllTime;
        int _Param = 0;
        int _EndYear = 0;

        private List<StatFish> _Fishes;

        private Records _Records;

        public List<StatFish> Fishes => _Fishes;

        public int ReportCount => _ReportCount;

        public uint TotalFishCount => _TotalFishCount;

        public Records Records => _Records;

        public CalcStat(StatisticsTimeMode timeMode, int Param, int EndYear) 
        {
            _Fishes = new List<StatFish>();
            _TimeMode = timeMode;
            _Param = Param;
            _EndYear = EndYear;
            _Records = new Records();
        }

        public void Calc() 
        {
            _ReportCount = 0;
            foreach (Report report in ReportsList.Reports)
            {
                // If the statistics are for the year
                if (_TimeMode == StatisticsTimeMode.Year)
                {
                    if (report.StartDate.Year != _Param)
                    {
                        //If the year does not match, skip it.
                        continue;
                    }
                }
                if (_TimeMode == StatisticsTimeMode.Period)
                {
                    if (report.StartDate.Year < _Param || report.StartDate.Year > _EndYear)
                    {
                        //If the year does not fall within the period, skip it.
                        continue;
                    }
                }
                _ReportCount++;


                _Records.NewReport(report.ReportId, report.StartDate, report.EndDate);

                foreach(RecordFish fish in report.CaughtFishes)
                {
                    StatFish statFish = _Fishes.Find(x => x.Id == fish.FishId);
                    if (statFish == null)
                    {
                        _Fishes.Add(new StatFish(fish));
                    }
                    else
                    {
                        statFish.AddQuantity(fish);
                    }
                    _TotalFishCount += fish.Quantity;

                    _Records.CheckAndAdd(fish, report.BodyOfWater);
                }

                _Records.EndReport();
            }

            _Records.CalcBestDays(_Fishes);

            // sort by quantity descending for all
            _Fishes.Sort();
            _Records.Sort();
            foreach (StatFish sortFish in _Fishes)
            {
                sortFish.SortAll();
            }

            foreach(StatFish statFish1 in _Fishes)
            {
                statFish1.CalcPercent(_TotalFishCount);
            }

        }
    }
}
