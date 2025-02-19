//05.01.25
using PDFiumSharp.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models.Statistics
{
    internal class StatMethod : IComparable<StatMethod>
    {
        private int _Id;
        private string _Name;
        private ushort _Quantity;
        private ushort _NotNullCount;
        private double _TotalLenght;

        public int Id => _Id;

        public string Name => _Name;

        public ushort Quantity => _Quantity;

        // Condition to not divide by zero
        public float AverageLength => _NotNullCount == 0 ? 0f : (float)_TotalLenght / _NotNullCount;

        public StatMethod(RecordFish fish)
        {
            _Id = fish.MethodId;
            _Name = fish.Methods[fish.MethodId];
            _Quantity = fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount = _Quantity;
                _TotalLenght = fish.AverageLength * _Quantity;
            }
        }

        public void AddQuantity(RecordFish fish)
        {
            _Quantity += fish.Quantity;
            if (fish.AverageLength != 0)
            {
                _NotNullCount += _Quantity;
                _TotalLenght += fish.AverageLength * _Quantity;
            }
        }

        // Comparer.
        public int CompareTo(StatMethod comparePart)
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
    }
}
