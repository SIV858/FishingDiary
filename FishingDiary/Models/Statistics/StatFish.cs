//04.12.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models.Statistics
{
    public class StatFish : IComparable<StatFish>
    {
        private int _Id;
        private string _Name;
        private ushort _Quantity;
        private ushort _NotNullCount;
        private float _Percent;
        private double _TotalLenght;


        private List<StatBait> _Baits;

        public int Id => _Id;

        public string Name => _Name;

        public ushort Quantity => _Quantity;

        public float Percent => _Percent;

        // Condition to not divide by zero
        public float AverageLength => _NotNullCount == 0 ? 0f : (float)_TotalLenght / _NotNullCount;

        public List<StatBait> StatBaits => _Baits;

        public StatFish(RecordFish fish)
        {
            _Id = fish.FishId;
            _Name = fish.Fishes[fish.FishIdView];
            _Baits = new List<StatBait>();
            _Baits.Add(new StatBait(fish));
            _Quantity = fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount = _Quantity;
                _TotalLenght = fish.AverageLength * _Quantity;
            }
        }

        public void AddQuantity(RecordFish fish)
        {
            StatBait statBait = _Baits.Find(x => x.Id == fish.BaitId);
            if (statBait == null)
            {
                _Baits.Add(new StatBait(fish));
            }
            else
            {
                statBait.AddQuantity(fish);
            }
            _Quantity += fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount += _Quantity;
                _TotalLenght += fish.AverageLength * _Quantity;
            }
        }

        public void CalcPercent(uint TotalQuantity)
        {
            _Percent = ((float)_Quantity / TotalQuantity) * 100f;
        }

        // Comparer.
        public int CompareTo(StatFish comparePart)
        {
            if (comparePart.Quantity > this.Quantity)
            {
                return 1;
            }
            else
            {
                if (comparePart.Quantity == this.Quantity)
                {
                    return String.Compare(this.Name, comparePart.Name);
                }
                else
                {
                    return -1;
                }
            }
        }

        public void SortAll()
        {
            _Baits.Sort();
            foreach (StatBait sortBait in _Baits)
            {
                sortBait.Sort();
            }
        }
    }
}
