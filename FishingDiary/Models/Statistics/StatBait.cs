//05.01.25
using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models.Statistics
{
    public class StatBait : IComparable<StatBait>
    {
        private int _Id;
        private string _Name;
        private ushort _Quantity;
        private ushort _NotNullCount;
        private double _TotalLenght;

        private List<StatMethod> _Methods;

        public int Id => _Id;

        public string Name => _Name;

        public ushort Quantity => _Quantity;

        // Condition to not divide by zero
        public float AverageLength => _NotNullCount == 0 ? 0f: (float)_TotalLenght / _NotNullCount;

        public List<StatMethod> StatMethods => _Methods;

        public StatBait(RecordFish fish)
        {
            _Id = fish.BaitId;
            _Name = fish.Baits[fish.BaitId];
            _Methods = new List<StatMethod>();
            _Methods.Add(new StatMethod(fish));
            _Quantity = fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount = _Quantity;
                _TotalLenght = fish.AverageLength * _Quantity;
            }
        }

        public void AddQuantity(RecordFish fish)
        {
            StatMethod statMethod = _Methods.Find(x => x.Id == fish.MethodId);
            if (statMethod == null)
            {
                _Methods.Add(new StatMethod(fish));
            }
            else
            {
                statMethod.AddQuantity(fish);
            }
            _Quantity += fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount += _Quantity;
                _TotalLenght += fish.AverageLength * _Quantity;
            }
        }

        // Comparer.
        public int CompareTo(StatBait comparePart)
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

        public void Sort()
        {
            _Methods.Sort();
        }
    }
}
