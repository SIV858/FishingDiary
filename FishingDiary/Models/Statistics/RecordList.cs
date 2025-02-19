//13.02.25
using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace FishingDiary.Models
{
    /// <summary>
    /// A list of records in which the elements are in descending order 
    /// and the number of elements does not exceed a specified value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RecordList<T> where T : IComparable<T>
    {
        // Maximum number of elements
        private uint _CountElements;

        // One record can contain several fishing trips
        private List<List<T>> _Items;

        public List<List<T>> Items => _Items;

        public RecordList(uint CountEleents = 3) 
        {
            _CountElements = CountEleents;
            _Items = new List<List<T>>();
        }

        public new void Add(T item)
        {
            if (_CountElements == 0)
            {
                return;
            }

            if (_Items.Count == 0)
            {
                _Items.Add(new List<T>() { item });
            }
            else
            {
                int index = 0;
                // We go through the data and if our value is greater, we insert it
                foreach (List<T> curItem in _Items)
                {
                    int Compare = item.CompareTo(curItem.First());
                    if (Compare >= 0)
                    {
                        if (Compare == 0)
                        {
                            curItem.Add(item);
                        }
                        else
                        {
                            _Items.Insert(index, new List<T> { item });
                        }
                        index = -1;
                        break;
                    }
                    index++;
                }

                // If there is space in the list and the entry has not been inserted, then we add it
                if (_Items.Count < _CountElements && index != -1) 
                {
                    _Items.Add(new List<T>() { item });
                }

                // Deleting an extra entry
                if (_Items.Count > _CountElements)
                {
                    _Items.RemoveAt(_Items.Count - 1);
                }
            }
        }
    }
}
