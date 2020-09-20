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

        private static string sAddWindowGeneralTxtRussian = "Общая информаация";
        private static string sAddWindowGeneralTxtEnglish = "General information";

        private static string sAddWindowDateTxtRussian = "Дата рыбалки:";
        private static string sAddWindowDateTxtEnglish = "Fishing date:";

        private static string sAddWindowWaterTxtRussian = "Водоём:";
        private static string sAddWindowWaterTxtEnglish = "Body of water:";

        private static string sAddWindowWeatherTxtRussian = "Погода";
        private static string sAddWindowWeatherTxtEnglish = "Weather";

        private static string sAddWindowTemperatureTxtRussian = "Температура воздуха:";
        private static string sAddWindowTemperatureTxtEnglish = "Air temperature:";

        private static string sAddWindowPrecipitationTxtRussian = "Осадки:";
        private static string sAddWindowPrecipitationTxtEnglish = "Precipitation:";

        private static string sAddWindowDirectionTxtRussian = "Направление ветра:";
        private static string sAddWindowDirectionTxtEnglish = "Wind direction:";

        private static string sAddWindowSpeedTxtRussian = "Скорость ветра:";
        private static string sAddWindowSpeedTxtEnglish = "Wind speed:";

        private static string sAddWindowPressureTxtRussian = "Давление:";
        private static string sAddWindowPressureTxtEnglish = "Pressure:";

        private static string sAddWindowInformationTxtRussian = "Информация о ловле";
        private static string sAddWindowInformationTxtEnglish = "Fishing information";

        private static string sAddWindowMethodTxtRussian = "Способ ловли:";
        private static string sAddWindowMethodTxtEnglish = "Fishing method:";

        private static string sAddWindowTackleTxtRussian = "Снасти:";
        private static string sAddWindowTackleTxtEnglish = "Fishing tackle:";

        private static string sAddWindowGroundbaitTxtRussian = "Прикормка:";
        private static string sAddWindowGroundbaitTxtEnglish = "Groundbait:";

        private static string sAddWindowBaitsTxtRussian = "Насадки:";
        private static string sAddWindowBaitsTxtEnglish = "Baits:";

        private static string sAddWindowResultTxtRussian = "Результат ловли";
        private static string sAddWindowResultTxtEnglish = "Fishing result";

        private static string sAddWindowBitingTxtRussian = "Клёв:";
        private static string sAddWindowBitingTxtEnglish = "Biting:";

        private static string sAddWindowCaughtTxtRussian = "Пойманные рыбы:";
        private static string sAddWindowCaughtTxtEnglish = "Caught fish:";

        private static string sAddWindowBiggestTxtRussian = "Самая крупная:";
        private static string sAddWindowBiggestTxtEnglish = "Biggest:";

        private static string sAddWindowWeightTxtRussian = "Вес:";
        private static string sAddWindowWeightTxtEnglish = "Weight:";

        private static string sAddWindowTotalWeightTxtRussian = "Общий вес:";
        private static string sAddWindowTotalWeightxtEnglish = "Total weight:";

        private static string sAddWindowDescriptionTxtRussian = "Описание";
        private static string sAddWindowDescriptionTxtEnglish = "Description";

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

        public static string GetAddWindowGeneralText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowGeneralTxtRussian;
                case Languages.English:
                    return sAddWindowGeneralTxtEnglish;

                default:
                    return sAddWindowGeneralTxtEnglish;
            }
        }

        public static string GetAddWindowDateText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowDateTxtRussian;
                case Languages.English:
                    return sAddWindowDateTxtEnglish;

                default:
                    return sAddWindowDateTxtEnglish;
            }
        }

        public static string GetAddWindowWaterText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowWaterTxtRussian;
                case Languages.English:
                    return sAddWindowWaterTxtEnglish;

                default:
                    return sAddWindowWaterTxtEnglish;
            }
        }

        public static string GetAddWindowWeatherText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowWeatherTxtRussian;
                case Languages.English:
                    return sAddWindowWeatherTxtEnglish;

                default:
                    return sAddWindowWeatherTxtEnglish;
            }
        }

        public static string GetAddWindowTemperatureText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowTemperatureTxtRussian;
                case Languages.English:
                    return sAddWindowTemperatureTxtEnglish;

                default:
                    return sAddWindowTemperatureTxtEnglish;
            }
        }

        public static string GetAddWindowPrecipitationText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowPrecipitationTxtRussian;
                case Languages.English:
                    return sAddWindowPrecipitationTxtEnglish;

                default:
                    return sAddWindowPrecipitationTxtEnglish;
            }
        }

        public static string GetAddWindowDirectionText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowDirectionTxtRussian;
                case Languages.English:
                    return sAddWindowDirectionTxtEnglish;

                default:
                    return sAddWindowDirectionTxtEnglish;
            }
        }

        public static string GetAddWindowSpeedText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowSpeedTxtRussian;
                case Languages.English:
                    return sAddWindowSpeedTxtEnglish;

                default:
                    return sAddWindowSpeedTxtEnglish;
            }
        }

        public static string GetAddWindowPressureText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowPressureTxtRussian;
                case Languages.English:
                    return sAddWindowPressureTxtEnglish;

                default:
                    return sAddWindowPressureTxtEnglish;
            }
        }

        public static string GetAddWindowInformationText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowInformationTxtRussian;
                case Languages.English:
                    return sAddWindowInformationTxtEnglish;

                default:
                    return sAddWindowInformationTxtEnglish;
            }
        }

        public static string GetAddWindowMethodText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowMethodTxtRussian;
                case Languages.English:
                    return sAddWindowMethodTxtEnglish;

                default:
                    return sAddWindowMethodTxtEnglish;
            }
        }

        public static string GetAddWindowTackleText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowTackleTxtRussian;
                case Languages.English:
                    return sAddWindowTackleTxtEnglish;

                default:
                    return sAddWindowTackleTxtEnglish;
            }
        }

        public static string GetAddWindowGroundbaitText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowGroundbaitTxtRussian;
                case Languages.English:
                    return sAddWindowGroundbaitTxtEnglish;

                default:
                    return sAddWindowGroundbaitTxtEnglish;
            }
        }

        public static string GetAddWindowBaitsText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowBaitsTxtRussian;
                case Languages.English:
                    return sAddWindowBaitsTxtEnglish;

                default:
                    return sAddWindowBaitsTxtEnglish;
            }
        }

        public static string GetAddWindowResultText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowResultTxtRussian;
                case Languages.English:
                    return sAddWindowResultTxtEnglish;

                default:
                    return sAddWindowResultTxtEnglish;
            }
        }

        public static string GetAddWindowBitingText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowBitingTxtRussian;
                case Languages.English:
                    return sAddWindowBitingTxtEnglish;

                default:
                    return sAddWindowBitingTxtEnglish;
            }
        }

        public static string GetAddWindowCaughtText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowCaughtTxtRussian;
                case Languages.English:
                    return sAddWindowCaughtTxtEnglish;

                default:
                    return sAddWindowCaughtTxtEnglish;
            }
        }

        public static string GetAddWindowBiggestText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowBiggestTxtRussian;
                case Languages.English:
                    return sAddWindowBiggestTxtEnglish;

                default:
                    return sAddWindowBiggestTxtEnglish;
            }
        }

        public static string GetAddWindowWeightText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowWeightTxtRussian;
                case Languages.English:
                    return sAddWindowWeightTxtEnglish;

                default:
                    return sAddWindowWeightTxtEnglish;
            }
        }

        public static string GetAddWindowTotalWeightText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowTotalWeightTxtRussian;
                case Languages.English:
                    return sAddWindowTotalWeightxtEnglish;

                default:
                    return sAddWindowTotalWeightxtEnglish;
            }
        }

        public static string GetAddWindowDescriptionText()
        {
            switch (Properties.CurrentLanguage)
            {
                case Languages.Russian:
                    return sAddWindowDescriptionTxtRussian;
                case Languages.English:
                    return sAddWindowDescriptionTxtEnglish;

                default:
                    return sAddWindowDescriptionTxtEnglish;
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
