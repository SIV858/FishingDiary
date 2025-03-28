// 28.03.25
using FishingDiary.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class StatYear : IComparable<StatYear>
    {
        private int _Year;
        private int _FirstPlaces;
        private int _SecondPlaces;
        private int _ThirdPlaces;

        public int Year => _Year;
        public int FirstPlaces => _FirstPlaces;
        public int SecondPlaces => _SecondPlaces;
        public int ThirdPlaces => _ThirdPlaces;
        public int AllPlaces => _FirstPlaces + _SecondPlaces + _ThirdPlaces;

        public StatYear(int Year)
        {
            _Year = Year;
        }

        public void AddFirst(ushort First)
        {
            _FirstPlaces+=First;
        }

        public void AddSecond(ushort Second)
        {
            _SecondPlaces+=Second;
        }

        public void AddThird(ushort Third)
        {
            _ThirdPlaces+=Third;
        }

        // As in the medal table in the Olympics
        public int CompareTo(StatYear other)
        {
            if (other._FirstPlaces > this._FirstPlaces)
            {
                return 1;
            }
            else
            {
                if (other._FirstPlaces == this._FirstPlaces)
                {
                    if (other._SecondPlaces > this._SecondPlaces)
                    {
                        return 1;
                    }
                    else
                    {
                        if (other._SecondPlaces == this._SecondPlaces)
                        {
                            if (other._ThirdPlaces > this._ThirdPlaces)
                            {
                                return 1;
                            }
                            else
                            {
                                if (other._SecondPlaces == this._SecondPlaces)
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
