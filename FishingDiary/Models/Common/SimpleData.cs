//15.02.25
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class SimpleData<T> : IComparable<SimpleData<T>> where T : IComparable<T>
    {
        public uint Id { get; set; }
        public T Data { get; set; }

        public SimpleData (uint id, T data)
        {
            Id = id;
            Data = data;
        }

        public int CompareTo(SimpleData<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
