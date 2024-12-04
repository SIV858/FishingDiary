//04.12.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models.Statistics
{
    internal class StatFish : IComparable<StatFish>
    {
        private int _Id;
        private string _Name;
        private ushort _Quantity;
        private float _Percent;

        public int Id => _Id;

        public string Name => _Name;

        public ushort Quantity => _Quantity;

        public float Percent => _Percent;

        public StatFish(int Id, string Name, ushort Quantity)
        {
            _Id = Id;
            _Name = Name;
            _Quantity = Quantity;
        }

        public void AddQuantity(ushort Quantity)
        {
            _Quantity += Quantity;
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
    }
}
