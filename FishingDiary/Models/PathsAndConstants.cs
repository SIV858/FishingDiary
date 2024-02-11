//17.10.23
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public static class PathsAndConstants
    {
        private static string _currentDirectory = System.IO.Directory.GetCurrentDirectory();
        private static string _commonDatapath = _currentDirectory + "\\Data";
        private static string _editTablesPath = _commonDatapath + "\\EditTables.json";
        private static string _localePath = _currentDirectory + "\\locale\\";
        private static string _languagesPath = _localePath + "Languages.json";
        private static string _currentLanguagePath = _localePath + "CurrentLanguage.json";
        private static string _extJSON = ".json";

        public static string CURRENT_DIRECTORY
        {
            get => _currentDirectory;
        }
        public static string COMMON_DATA_PATH
        {
            get => _commonDatapath;
        }
        public static string EDIT_TABLES_PATH
        {
            get => _editTablesPath;
        }
        public static string LOCALE_DATA_PATH
        {
            get => _commonDatapath + CommonData.GenLanguages.LanguagePaths.sDataPath;
        }
        public static string LOCALE_PATH
        {
            get => _localePath;
        }
        public static string LANGUAGES_PATH
        {
            get => _languagesPath;
        }
        public static string CURRENT_LANGUAGE_PATH
        {
            get => _currentLanguagePath;
        }
        public static string EXT_JSON
        {
            get => _extJSON;
        }

    }
}
