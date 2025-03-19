//21.10.23
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace FishingDiary.Models
{
    public class EditTable
    {
        private string _ParamName;
        internal ObservableCollection<ColumnTable> _listColumns;
        internal ObservableCollection<ColumnTable> _listColumnsSelect;

        public string TableName
        {
            get => CommonData.GenLanguages.EditorTexts.GetLocaleParam(_ParamName);
        }

        /// <summary>
        /// All languages
        /// </summary>
        public ObservableCollection<ColumnTable> ListColumns
        {
            get => _listColumns;
            set => _listColumns = value;
        }

        /// <summary>
        /// Selected languages
        /// </summary>
        public ObservableCollection<ColumnTable> ListColumnsSelect
        {
            get => _listColumnsSelect;
            set => _listColumnsSelect = value;
        }

        public ColumnTable ColumnTableSelect => _listColumnsSelect.First();

        public EditTable(string ParamName)
        {
            _ParamName = ParamName;
            _listColumns = new ObservableCollection<ColumnTable>();
            _listColumnsSelect = new ObservableCollection<ColumnTable>();
        }

        public void ReadTable()
        {
            AvailableLanguages availableLanguages = new AvailableLanguages(PathsAndConstants.LANGUAGES_PATH);

            foreach (var lang in availableLanguages.Languages)
            {
                //Parse the language to get the path
                LanguageParser parser = new LanguageParser(PathsAndConstants.LOCALE_PATH + lang + PathsAndConstants.EXT_JSON);
                string DataPath = parser.GetDataPath();
                DataPath += _ParamName + PathsAndConstants.EXT_JSON;

                //Adding data for the current language
                ColumnTable columnTable = new ColumnTable(lang);
                columnTable.ReadTable(DataPath);
                _listColumns.Add(columnTable);
                if (lang == CommonData.CurrentLang.Language)
                { 
                    _listColumnsSelect.Add(columnTable);
                }
            }
        }

        public void WriteTable()
        {
            foreach(var columns in _listColumns) 
            {
                columns.WriteTable();
            }
        }
    }
}
