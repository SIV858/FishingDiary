//12.02.25

using DynamicData;
using PDFiumSharp.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class Records
    {
        private RecordList<RecordData<ushort>> _QuantityRecords;
        private RecordList<RecordData<float>> _NibbleRecords;
        private List<DataFish> _FishRecords;

        // List of pairs: the first element of the pair is ID of fish
        // the second element is a list of records for this fish
        private List<Tuple<int, RecordList<RecordData<ushort>>>> _FishCountRecords;
        private RecordList<RecordData<ushort>> _VarietyRecords;

        private ushort _CurrentVariety;
        private List <Tuple<int, RecordData<ushort>>> _CurrentFishCount;

        private ushort _CurrentQuantity;
        private uint _CurrentRecordId;
        private DateTime _StartDate;
        private DateTime _EndDate;

        public RecordList<RecordData<ushort>> QuantityRecords => _QuantityRecords;
        public RecordList<RecordData<float>> NibbleRecords => _NibbleRecords;
        public List<DataFish> FishRecords => _FishRecords;
        public List<Tuple<int, RecordList<RecordData<ushort>>>> FishCountRecords => _FishCountRecords;
        public RecordList<RecordData<ushort>> VarietyRecords => _VarietyRecords;



        public Records() 
        {
            _FishRecords = new List<DataFish>();
            _QuantityRecords = new RecordList<RecordData<ushort>>(10);
            _NibbleRecords = new RecordList<RecordData<float>>(10);
            _VarietyRecords = new RecordList<RecordData<ushort>>(3);
            _FishCountRecords = new List<Tuple<int,RecordList<RecordData<ushort>>>>();


            _CurrentFishCount = new List<Tuple<int, RecordData<ushort>>>();
        }

        /// <summary>
        /// Resetting data for the previous report
        /// </summary>
        public void NewReport(uint RecordId, DateTime Start, DateTime End)
        {
            _CurrentVariety = 0;
            _CurrentQuantity = 0;
            _CurrentFishCount.Clear();

            _CurrentRecordId = RecordId;
            _StartDate = Start;
            _EndDate = End;

        }

        /// <summary>
        /// Save data for the report
        /// </summary>
        public void EndReport()
        {

            _QuantityRecords.Add(new RecordData<ushort>(_CurrentRecordId, _StartDate, _CurrentQuantity));

            if (_StartDate != _EndDate)
            {
                TimeSpan time = _EndDate - _StartDate;
                double Nibble = _CurrentQuantity / time.TotalHours;

                _NibbleRecords.Add(new RecordData<float>(_CurrentRecordId, _StartDate, (float)Nibble));
            }


            _VarietyRecords.Add(new RecordData<ushort>(_CurrentRecordId, _StartDate, _CurrentVariety));

            foreach(var record in _CurrentFishCount)
            {
                var item = _FishCountRecords.Find(x => x.Item1 == record.Item1);
                if (item != null)
                {
                    item.Item2.Add(record.Item2);
                }
                else
                {
                    RecordList<RecordData<ushort>> recordList = new RecordList<RecordData<ushort>>(3);
                    recordList.Add(new RecordData<ushort>(record.Item2));

                    _FishCountRecords.Add(
                        new Tuple<int,
                        RecordList<RecordData<ushort>>>(
                            record.Item1,
                            recordList));
                }
            }
        }


        /// <summary>
        /// Check or add a record
        /// </summary>
        /// <param name="fish"></param>
        public void CheckAndAdd(RecordFish fish, string BodyOfWater)
        {
            ////////////////////////////////////////////////////////////////////////////////
            ///Quantity Records
            ////////////////////////////////////////////////////////////////////////////////

            _CurrentQuantity += fish.Quantity;

            ////////////////////////////////////////////////////////////////////////////////
            ///Variety Records
            ////////////////////////////////////////////////////////////////////////////////

            Tuple<int, RecordData<ushort>> recordData = _CurrentFishCount.Find(x => x.Item1 == fish.FishId);

            if (recordData == null)
            { 
                _CurrentVariety++;
            }

            ////////////////////////////////////////////////////////////////////////////////
            ///Fish Count Records
            ////////////////////////////////////////////////////////////////////////////////

            if (recordData == null)
            {
                _CurrentFishCount.Add(new Tuple<int, RecordData<ushort>>(
                    fish.FishId,
                    new RecordData<ushort>(_CurrentRecordId, _StartDate, fish.Quantity)));
            }
            else
            {
                recordData.Item2.Record += fish.Quantity;
            }

            ////////////////////////////////////////////////////////////////////////////////
            ///Fish Records
            ////////////////////////////////////////////////////////////////////////////////
            List<DataFish> dataFishList = _FishRecords.FindAll(x => x.FishId == fish.FishId);


            // nothing to put on the records list 
            if (fish.MaxLength == 0 && fish.MaxWeight == 0)
            {
                return;
            }

            // No data found for this fish, adding it
            if (dataFishList.Count == 0)
            {
                DataFish dataFish = new DataFish();
                dataFish.FishId = fish.FishId;
                dataFish.BaitId = fish.BaitId;
                dataFish.MethodId = fish.MethodId;
                dataFish.OptionId = fish.OptionId;
                dataFish.BodyOfWater = BodyOfWater;
                dataFish.Length = fish.MaxLength;
                dataFish.Weight = fish.MaxWeight;
                if (fish.Time.Year > 1)
                {
                    dataFish.Time = fish.Time;
                }
                else
                {
                    dataFish.Time = _StartDate;
                }

                _FishRecords.Add(dataFish);
            }
            else
            {
                bool IsFirst = true;

                foreach (DataFish f in dataFishList)
                {
                    // If the record is broken, then replace the data
                    if (f.Length < fish.MaxLength || f.Weight < fish.MaxWeight)
                    {
                        if (IsFirst)
                        {
                            f.BaitId = fish.BaitId;
                            f.MethodId = fish.MethodId;
                            f.OptionId = fish.OptionId;
                            f.BodyOfWater = BodyOfWater;
                            f.Length = fish.MaxLength;
                            f.Weight = fish.MaxWeight;
                            if (fish.Time.Year > 1)
                            {
                                f.Time = fish.Time;
                            }
                            else
                            {
                                f.Time = _StartDate;
                            }
                            IsFirst = false;
                        }
                        else // If the record has already been broken, then the entries are deleted
                        {
                            //не удаляется !!!
                            _FishRecords.Remove(f);
                        }
                    }
                }
            }

        }

        public void Sort()
        {
            _FishRecords.Sort();
            _FishCountRecords.Sort();
        }
    }
}
