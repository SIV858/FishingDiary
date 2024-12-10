//03.02.24
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class DataTables
    {
        private List<EditTable> _listTables;

        public ObservableCollection<EditTable> Tables {
            get
            {
                return new ObservableCollection<EditTable>(_listTables);
            }         
        }

        public DataTables()
        {
            _listTables = new List<EditTable>();
        }

        public void ReadTables()
        {
            //Adding data for the current language
            using (StreamReader reader = new StreamReader(PathsAndConstants.EDIT_TABLES_PATH))
            {
                string json = reader.ReadToEnd();

                var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                List<string> tables = JsonSerializer.Deserialize<List<string>>(readOnlySpan);

                foreach(var table in tables)
                {
                    EditTable editTable = new EditTable(table);
                    editTable.ReadTable();
                    _listTables.Add(editTable);
                }
            }

        }

        public void WriteTables()
        {
            foreach(var table in _listTables)
            {
                table.WriteTable();
            }
        }
    }

}

