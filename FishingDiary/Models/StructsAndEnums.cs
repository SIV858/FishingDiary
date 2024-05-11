//17.09.20
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public enum AirTemperature
    {
        LessMinus40,
        Minus40_Minus35,
        Minus35_Minus30,
        Minus30_Minus25,
        Minus25_Minus20,
        Minus20_Minus15,
        Minus15_Minus10,
        Minus10_Minus5,
        Minus5_Zero,
        Zero_Plus5,
        Plus5_Plus10,
        Plus10_Plus15,
        Plus15_Plus20,
        Plus20_Plus25,
        Plus25_Plus30,
        Plus30_Plus35,
        Plus35_Plus40,
        MorePlus40
    }

    public enum Precipitation
    {
        Sun,
        Cloudy,
        Dull,
        Rain,
        Shower,
        Thunderstorm,
        Snow,
        Blizzard,
        Fog
    }

    public enum WindDirection
    {
        North,
        East,
        South,
        West,
        NorthWest,
        NorthEast,
        SouthEast,
        SouthWest
    }

    public enum WindSpeed
    {
        Calm,
        S1,
        S2,
        S3,
        S4,
        S5,
        S6,
        StrongWind,
        Hurricane,
        Tornado
    }

    public enum MoonPhase
    {
        NewMoon,
        P10,
        P20,
        P30,
        P40,
        P50,
        P60,
        P70,
        P80,
        P90,
        FullMoon
    }

    public enum Biting
    {
        NoFishCaught,
        FishCaughtBad,
        FishCaughtNormal,
        FishCaughtGood,
        FishCaughtExcellent
    }
}
