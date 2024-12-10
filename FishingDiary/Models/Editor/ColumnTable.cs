//11.02.24
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using HarfBuzzSharp;

namespace FishingDiary.Models
{
    public class ColumnTable
    {
        private string _ColumnName;

        private string _DataPath;

        private ObservableCollection<DataElement> _DataList;

        private DataElement _AddedElement;

        public string ColumnName => _ColumnName;
        public ObservableCollection<DataElement> DataList
        {
            get => _DataList;
            set => _DataList = value;
        }
           

        public uint AddedId
        {
            get => _AddedElement.Id;
            set => _AddedElement.Id = value;
        }

        public string AddedText
        {
            get => _AddedElement.Text;
            set => _AddedElement.Text = value;
        }


        public ColumnTable(string ColumnName)
        {
            _ColumnName = ColumnName;
            _AddedElement = new DataElement();
        }

        public void AddCurrentElement()   
        {
            int index = 0;
            foreach (DataElement element in _DataList)
            {
                if (element.Id >= _AddedElement.Id)
                {
                    if (element.Id == _AddedElement.Id)
                    {
                        throw new Exception(CommonData.GenLanguages.ErrorTexts.sIdAlreadyExists);
                    }
                    else
                    {
                        break;
                    }
                }

                index++;
            }

            DataList.Insert(index, _AddedElement);
        }

        public void ReadTable(string DataPath)
        {
            _DataPath = DataPath;
            try
            {
                //Read data from file
                using (StreamReader reader = new StreamReader(_DataPath))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    List<DataElement> ReadList = JsonSerializer.Deserialize<List<DataElement>>(readOnlySpan);
                    _DataList = new ObservableCollection<DataElement>(ReadList);
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sErrorFileNotFound + _DataPath);
            }
            catch (JsonException)
            {
                throw new Exception(CommonData.GenLanguages.ErrorTexts.sErrorCorruptedFile + _DataPath);
            }
        }

        public void WriteTable()
        {
            try
            {
                //Write table to file
                using (StreamWriter writer = new StreamWriter(_DataPath))
                {
                    string json = JsonSerializer.Serialize<ObservableCollection<DataElement>>(_DataList);
                    writer.Write(json);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(_DataPath);
            }
            catch (JsonException)
            {
                throw new JsonException(_DataPath);
            }
        }
    }
}
