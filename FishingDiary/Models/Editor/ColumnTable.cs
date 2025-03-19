//11.02.24
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using HarfBuzzSharp;
using System.Linq;
using System.Reflection;

namespace FishingDiary.Models
{
    public class ColumnTable
    {
        private string _ColumnName;

        private string _DataPath;

        private int _SelectedIndex = -1;

        private ObservableCollection<DataElement> _DataList;

        private DataElement _CurrentElement;

        public string ColumnName 
        { 
            get => _ColumnName; 
            set => _ColumnName = value;
        }
        public ObservableCollection<DataElement> DataList
        {
            get => _DataList;
            set => _DataList = value;
        }
           
        public int SelectedIndex
        {
            get => _SelectedIndex;
            set
            {
                _SelectedIndex = value;
                if (_SelectedIndex != -1)
                {
                    _CurrentElement.Id = DataList[_SelectedIndex].Id;
                    _CurrentElement.Text = DataList[_SelectedIndex].Text;
                }
            }
        }


        public uint CurrentId
        {
            get => _CurrentElement.Id;
            set => _CurrentElement.Id = value;
        }

        public string CurrentText
        {
            get => _CurrentElement.Text;
            set => _CurrentElement.Text = value;
        }


        public ColumnTable(string ColumnName)
        {
            _ColumnName = ColumnName;
            _CurrentElement = new DataElement();
        }

        public void AddCurrentElement()   
        {
            int index = 0;
            foreach (DataElement element in _DataList)
            {
                if (element.Id >= _CurrentElement.Id)
                {
                    if (element.Id == _CurrentElement.Id)
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

            DataList.Insert(index, new DataElement() { Id = _CurrentElement.Id, Text = _CurrentElement.Text });
        }

        public void EditCurrentElement()
        {
            foreach (DataElement element in _DataList)
            {
                if (element.Id == _CurrentElement.Id)
                {
                    element.Text = _CurrentElement.Text;
                    break;
                }
            }
        }

        public void DeleteCurrentElement()
        {
            _DataList.RemoveAt(_SelectedIndex);
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
