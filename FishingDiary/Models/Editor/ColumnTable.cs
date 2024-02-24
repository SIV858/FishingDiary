//11.02.24
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class ColumnTable
    {
        private string _ColumnName;

        private List<DataElement> _DataList;

        public string ColumnName => _ColumnName;
        public ObservableCollection<DataElement> DataList
        {
            get
            {
                return new ObservableCollection<DataElement>(_DataList);
            }
        }
           
        public ObservableCollection<DataElement> ElementsList { get; }

        public ColumnTable(string ColumnName)
        {
            _ColumnName = ColumnName;
        }

        public void ReadTable(string DataPath)
        {
            //Read data from file
            using (StreamReader reader = new StreamReader(DataPath))
            {
                string json = reader.ReadToEnd();

                var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                _DataList = JsonSerializer.Deserialize<List<DataElement>>(readOnlySpan);
            }

        }
    }
}
