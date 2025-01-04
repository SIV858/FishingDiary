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

        private List<StatFish> _Fishes;
        public List<StatFish> Fishes => _Fishes;

        public int ReportCount => _ReportCount;

        public uint TotalFishCount => _TotalFishCount;

        public CalcStat(StatisticsTimeMode timeMode, int Param) 
        {
            _Fishes = new List<StatFish>();
            _TimeMode = timeMode;
            _Param = Param;
        }

        public void Calc() 
        {
            _ReportCount = ReportsList.Reports.Count;
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

                foreach(RecordFish fish in report.CaughtFishes)
                {
                    StatFish statFish = _Fishes.Find(x => x.Id == fish.FishId);
                    if (statFish == null)
                    {
                        _Fishes.Add(new StatFish(fish.FishId, fish.Fishes[fish.FishId], fish.Quantity));
                    }
                    else
                    {
                        statFish.AddQuantity(fish.Quantity);
                    }
                    _TotalFishCount += fish.Quantity;
                }
            }

            _Fishes.Sort();

            foreach(StatFish statFish1 in _Fishes)
            {
                statFish1.CalcPercent(_TotalFishCount);
            }

        }
    }
}
