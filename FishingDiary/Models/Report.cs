//17.09.20
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    /// <summary>
    /// One report
    /// Один отчёт
    /// </summary>
    public class Report
    {
        private DateTime mStartDate;
        private DateTime mEndDate;

        private string mBodyOfWater;

        private AirTemperature mAirTemperature;

        private Precipitation mPrecipitation;

        private WindDirection mWindDirection;

        private WindSpeed mWindSpeed;

        private ushort mPressure;

        private MoonPhase mMoonPhase;

        private bool fWaxingMoon;

        private string mFishingMethod; //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        private string mFishingTackle; //rod, spinning, feeder, winter fishing rod

        private string mGroundbait; //pearl barley, corn, millet

        private string mBaits; //bread, maggot, worms 

        private Biting mBiting; 

        private string mCaughtFish;

        private string mBiggest;

        private float mWeight;

        private float mTotalWeight;

        private string mDescription;

    }
}
