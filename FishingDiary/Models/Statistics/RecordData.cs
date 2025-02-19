//15.02.25
using iTextSharp.testutils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FishingDiary.Models
{
    /// <summary>
    /// Record details
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RecordData<T> : IComparable<RecordData<T>> where T : IComparable<T>
    {
        private uint _RecordId;
        private DateTime _Date;
        private T _Record;

        // Report ID(fishing) when record is set
        public uint RecordId => _RecordId;
        public DateTime Date => _Date;
        public T Record
        { 
           get => _Record;
           set => _Record = value;
        }

        public RecordData(RecordData<T> recordData)
        {
            _Date = recordData.Date;
            _Record = recordData.Record;
            _RecordId = recordData.RecordId;
        }

        public RecordData(uint RecordId, DateTime Date, T Record) 
        { 
            _Date = Date;
            _Record = Record;
            _RecordId = RecordId;
        }

        public int CompareTo(RecordData<T> other)
        {
            return this._Record.CompareTo(other._Record);
        }
    }
}
