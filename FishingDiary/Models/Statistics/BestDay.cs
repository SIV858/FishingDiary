// 20.02.25
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models.Statistics
{
    public enum BestDayPlaceIndex : byte 
    {
        FirstPlace = 1,
        SecondPlace = 2,
        ThirdPlace = 3
    }

    public class BestDay : IComparable<BestDay>
    {
        private uint _DayId;

        private ushort _FirstPlace = 0;
        private ushort _SecondPlace = 0;
        private ushort _ThirdPlace = 0;

        public ushort FirstPlace => _FirstPlace;
        public ushort SecondPlace => _SecondPlace;
        public ushort ThirdPlace => _ThirdPlace;

        public BestDay(uint DayId, BestDayPlaceIndex IncrementIndex)
        {
            _DayId = DayId;
            switch(IncrementIndex)
            {
                case BestDayPlaceIndex.FirstPlace:
                    _FirstPlace = 1;
                    break;
                case BestDayPlaceIndex.SecondPlace:
                    _SecondPlace = 1;
                    break;
                case BestDayPlaceIndex.ThirdPlace:
                    _ThirdPlace = 1;
                    break;
            }
        }

        public void IncrementFirst()
        {
            _FirstPlace++;
        }

        public void IncrementSecond()
        {
            _SecondPlace++;
        }

        public void IncrementThird()
        {
            _ThirdPlace++;
        }

        // As in the medal table in the Olympics
        public int CompareTo(BestDay other)
        {
            if (other._FirstPlace > this._FirstPlace)
            {
                return 1;
            }
            else
            {
                if (other._FirstPlace == this._FirstPlace)
                {
                    if (other._SecondPlace > this._SecondPlace)
                    {
                        return 1;
                    }
                    else
                    {
                        if (other._SecondPlace == this._SecondPlace)
                        {
                            if (other._ThirdPlace > this._ThirdPlace)
                            {
                                return 1;
                            }
                            else
                            {
                                if (other._SecondPlace == this._SecondPlace)
                                {
                                    return 0;
                                }
                                else
                                {
                                    return -1;
                                }
                                    
                            }
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
