//15.09.20
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FishingDiary.Models
{

    /// <summary>
    /// Available languages
    /// Доступные языки
    /// </summary>
    public enum Languages
    {
        English,
        Russian     
    }

    /// <summary>
    /// Class for getting labels text
    /// Класс для получения надписей элементов
    /// </summary>
    public static class LanguageText
    {


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// Standart Texts
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>

        private static string sButtonOkRussian = "Ок";
        private static string sButtonOkEnglish = "Ok";

        private static string sButtonCancelRussian = "Отмена";
        private static string sButtonCancelEnglish = "Cancel";

        private static string sButtonApplyRussian = "Применить";
        private static string sButtonApplyEnglish = "Apply";

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// MainWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>

        private static string sMainWindowAddButtonRussian = "Добавить новый отчёт";
        private static string sMainWindowAddButtonEnglish = "Add a new report";

        private static string sMainWindowViewButtonRussian = "Посмотреть отчёты";
        private static string sMainWindowViewButtonEnglish = "View reports";

        private static string sMainWindowSettingsButtonRussian = "Настройки";
        private static string sMainWindowSettingsButtonEnglish = "Settings";

        private static string sMainWindowHeadRussian = "Рыболовные отчёты";
        private static string sMainWindowHeadEnglish = "Fishing reports";

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// SettingsWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>
        private static string sSettingsWindowHeadRussian = "Настройки";
        private static string sSettingsWindowHeadEnglish = "Settings";

        private static string sSettingsWindowLangRussian = "Язык: ";
        private static string sSettingsWindowLangEnglish = "Language: ";

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// AddWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>

        private static string sAddWindowHeadRussian = "Добавить отчёт";
        private static string sAddWindowHeadEnglish = "Add report";

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// Standart Texts
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>
        public static string GetOkButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sButtonOkRussian;
                case Languages.English:
                    return sButtonOkEnglish;

                default:
                    return sButtonOkEnglish;
            }
        }

        public static string GetCancelButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sButtonCancelRussian;
                case Languages.English:
                    return sButtonCancelEnglish;

                default:
                    return sButtonCancelEnglish;
            }
        }

        public static string GetApplyButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sButtonApplyRussian;
                case Languages.English:
                    return sButtonApplyEnglish;

                default:
                    return sButtonApplyEnglish;
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// MainWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>

        public static string GetMainWindowAddButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sMainWindowAddButtonRussian;
                case Languages.English:
                    return sMainWindowAddButtonEnglish;

                default:
                    return sMainWindowAddButtonEnglish;
            }
        }

        public static string GetMainWindowViewButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sMainWindowViewButtonRussian;
                case Languages.English:
                    return sMainWindowViewButtonEnglish;

                default:
                    return sMainWindowViewButtonEnglish;
            }
        }

        public static string GetMainWindowSettingsButtonText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sMainWindowSettingsButtonRussian;
                case Languages.English:
                    return sMainWindowSettingsButtonEnglish;

                default:
                    return sMainWindowSettingsButtonEnglish;
            }
        }

        public static string GetMainWindowHeadText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sMainWindowHeadRussian;
                case Languages.English:
                    return sMainWindowHeadEnglish;

                default:
                    return sMainWindowHeadEnglish;
            }
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// SettingsWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>
        public static string GetSettingsWindowHeadText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sSettingsWindowHeadRussian;
                case Languages.English:
                    return sSettingsWindowHeadEnglish;

                default:
                    return sSettingsWindowHeadEnglish;
            }
        }

        public static string GetSettingsWindowLangText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sSettingsWindowLangRussian;
                case Languages.English:
                    return sSettingsWindowLangEnglish;

                default:
                    return sSettingsWindowLangEnglish;
            }
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////
        /// AddWindow
        /// //////////////////////////////////////////////////////////////////////
        /// </summary>
        public static string GetAddWindowHeadText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowHeadRussian;
                case Languages.English:
                    return sAddWindowHeadEnglish;

                default:
                    return sAddWindowHeadEnglish;
            }
        }

        /// <summary>
        /// Get current language
        /// Получить текущий язык
        /// </summary>
        /// <returns>Language</returns>
        public static string GetSelectionItemLanguage()
        {
            return LanguagesToString(Properties.CurrentLanguage);
        }

        /// <summary>
        /// Set language
        /// Установить язык
        /// </summary>
        /// <param name="sLanguage">Language in text format</param>
        public static void SetSelectionItemLanguage(string sLanguage)
        {
            Properties.CurrentLanguage = StringToLanguages(sLanguage);
        }

        /// <summary>
        /// Get language collection
        /// Получение коллекции языков
        /// </summary>
        /// <returns>Language collection</returns>
        public static Collection<string> GetLanguageCollection()
        {
            // Getting a collection from an enum
            // Получение коллекции из перечисления
            Array arr = Enum.GetValues(typeof(Languages));

            Collection<string> coll = new Collection<string>();

            foreach (Languages lang in arr)
            {
                coll.Add(LanguagesToString(lang));
            }

            return coll;
        }

        /// <summary>
        /// Languages enum to string
        /// Преобразование перечисления языков в строку
        /// </summary>
        /// <param name="lang">Languages enum element</param>
        /// <returns>Language in string format</returns>     

        private static string LanguagesToString(Languages lang)
        {
            switch(lang)
            {
                case Languages.English:
                    return "English";
                case Languages.Russian:
                    return "Русский";

                default:
                    return "English";
            }
        }


        /// <summary>
        /// String to Languages enum
        /// Преобразование строки в перечисление языков 
        /// </summary>
        /// <param name="lang">Language in string format</param>
        /// <returns>Languages enum element</returns>     

        private static Languages StringToLanguages(string sLang)
        {
            switch (sLang)
            {
                case "English":
                    return Languages.English;
                case "Русский":
                    return Languages.Russian;

                default:
                    return Languages.English;
            }
        }
    }
}
