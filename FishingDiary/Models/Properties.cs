//19.09.20
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public static class Properties
    {
        private static Languages mCurrentLanguage = Languages.Russian;
        private static double mFontSize = 15.0;

        public static Languages CurrentLanguage
        {
            get => mCurrentLanguage;
            set => mCurrentLanguage = value;
        }

        public static double FontSize
        {
            get => mFontSize;
            set => mFontSize = value;
        }
    }
}
