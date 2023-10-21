//17.10.23
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public static class PathsAndConstants
    {
        public static string CURRENT_DIRECTORY = System.IO.Directory.GetCurrentDirectory();
        public static string LOCALE_PATH = CURRENT_DIRECTORY + "\\locale\\";
        public static string LANGUAGES_PATH = LOCALE_PATH + "Languages.json";
        public static string CURRENT_LANGUAGE_PATH = LOCALE_PATH + "CurrentLanguage.json";
        public static string EXT_JSON = ".json";
    }
}
