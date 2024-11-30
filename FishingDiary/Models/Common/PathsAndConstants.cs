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
        private static string _propertiesPath = _commonDatapath + "\\Properties.json";
        private static string _localePath = _currentDirectory + "\\locale\\";
        private static string _languagesPath = _localePath + "Languages.json";
        private static string _currentLanguagePath = _localePath + "CurrentLanguage.json";
        private static string _extJSON = ".json";
        private static string _baitsFile = "Baits" + _extJSON;
        private static string _fishesFile = "Fishes" + _extJSON;
        private static string _fishingTackleFile = "Fishing_tackle" + _extJSON;
        private static string _groundbaitsFile = "Groundbaits" + _extJSON;
        private static string _methodsFile = "Methods" + _extJSON;
        private static string _optionsFile = "Options" + _extJSON;
        private static string _watersFile = "Waters" + _extJSON;
        private static string _noPhotoFileName = "No_Photo.png";
        private static string _noPhotoFileNameMini = "No_Photo_mini.png";
        private static string _noPhotoPath = _commonDatapath + "\\" + _noPhotoFileName;
        private static string _noPhotoPathMini = _commonDatapath + "\\" + _noPhotoFileNameMini;
        private static string _reportsPath = _commonDatapath + "\\Reports";
        private static string _shortReportsFile = _reportsPath + "\\ShortReports.json";
        private static string _shortReportsImagesPath = _reportsPath + "\\Mini\\";

        public const int UNDEFINED_ID = -1;

        public const int HEIGHT_16x9_IMAGE = 180;
        public const int WIDTH_16x9_IMAGE = 320;

        public const int HEIGHT_4x3_IMAGE = 240;
        public const int WIDTH_4x3_IMAGE = 320;

        public const double AVERAGE_RATIO_COEF = 1.5;

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
        public static string PROPERTIES_PATH
        {
            get => _propertiesPath;
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
        public static string BAITS_FILE
        {
            get => _baitsFile;
        }
        public static string FISHES_FILE
        {
            get => _fishesFile;
        }
        public static string FISHING_TACKLE_FILE
        {
            get => _fishingTackleFile;
        }
        public static string GROUNDBAITS_FILE
        {
            get => _groundbaitsFile;
        }
        public static string METHODS_FILE
        {
            get => _methodsFile;
        }
        public static string OPTIONS_FILE
        {
            get => _optionsFile;
        }
        public static string WATERS_FILE
        {
            get => _watersFile;
        }

        public static string NO_PHOTO_FILE_NAME
        {
            get => _noPhotoFileName;
        }

        public static string NO_PHOTO_FILE_NAME_MINI
        {
            get => _noPhotoFileNameMini;
        }

        public static string NO_PHOTO_PATH
        {
            get => _noPhotoPath;
        }

        public static string NO_PHOTO_PATH_MINI
        {
            get => _noPhotoPathMini;
        }

        public static string REPORTS_PATH
        {
            get => _reportsPath;
        }

        public static string SHORT_REPORT_PATH
        {
            get => _shortReportsFile;
        }

        public static string SHORT_REPORT_IMAGES_PATH
        {
            get => _shortReportsImagesPath;
        }

    }
}
