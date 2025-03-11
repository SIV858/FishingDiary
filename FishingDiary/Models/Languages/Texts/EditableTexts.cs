//14.02.24

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    // Texts that can be edited in the editor
    public class EditableTexts
    {
        private string _DataPath;

        private List<DataElement> _Baits;
        private List<DataElement> _Fishes;
        private List<DataElement> _FishingTackles;
        private List<DataElement> _Groundbaits;
        private List<DataElement> _Methods;
        private List<DataElement> _Options;
        private List<DataElement> _Waters;

        public List<DataElement> Baits => _Baits;
        public List<DataElement> Fishes => _Fishes;
        public List<DataElement> FishingTackle => _FishingTackles;
        public List<DataElement> Groundbaits => _Groundbaits;
        public List<DataElement> Methods => _Methods;
        public List<DataElement> Options => _Options;
        public List<DataElement> Waters => _Waters;

        public List<string> MethodsText 
        {
            get
            {
               return _Methods.ConvertAll<string>(x => x.Text);
            }
        }
        public List<string> OptionsText
        {
            get
            {
                return _Options.ConvertAll<string>(x => x.Text);
            }
        }
        public List<string> TacklesText
        {
            get
            {
                return _FishingTackles.ConvertAll<string>(x => x.Text);
            }
        }
        public List<string> GroundbaitsText
        {
            get
            {
                return _Groundbaits.ConvertAll<string>(x => x.Text);
            }
        }
        public List<string> BaitsText
        {
            get
            {
                return _Baits.ConvertAll<string>(x => x.Text);
            }
        }

        public List<string> FishesText
        {
            get
            {
                return _Fishes.ConvertAll<string>(x => x.Text);
            }
        }
        public List<string> WatersText
        {
            get
            {
                return _Waters.ConvertAll<string>(x => x.Text);
            }
        }

        public EditableTexts(string DataPath)
        {
            _DataPath = DataPath;
        }

        /// <summary>
        /// Add water to list and udpate data file
        /// </summary>
        /// <param name="water">water</param>
        public void AddWater(string water)
        {
            _Waters.Add(new DataElement()
            {
                Id = (uint)_Waters.Count,
                Text = water
            });
            UpdateFile(_DataPath + PathsAndConstants.WATERS_FILE, _Waters);
        }

        public void Parse()
        {
            ParseList(_DataPath + PathsAndConstants.BAITS_FILE, out _Baits);
            ParseList(_DataPath + PathsAndConstants.FISHES_FILE, out _Fishes);
            ParseList(_DataPath + PathsAndConstants.FISHING_TACKLE_FILE, out _FishingTackles);
            ParseList(_DataPath + PathsAndConstants.GROUNDBAITS_FILE, out _Groundbaits);
            ParseList(_DataPath + PathsAndConstants.METHODS_FILE, out _Methods);
            ParseList(_DataPath + PathsAndConstants.OPTIONS_FILE, out _Options);
            ParseList(_DataPath + PathsAndConstants.WATERS_FILE, out _Waters);
        }

        private void ParseList(string fileName, out List<DataElement> list)
        {
            try
            {
                //Read data from file
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    list = JsonSerializer.Deserialize<List<DataElement>>(readOnlySpan);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(fileName);
            }
            catch (JsonException)
            {
                throw new JsonException(fileName);
            }

        }

        private void UpdateFile(string fileName, List<DataElement> list)
        {
            try
            {
                //Write data to file
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    string json = JsonSerializer.Serialize<List<DataElement>>(list);
                    writer.Write(json);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(fileName);
            }
            catch (JsonException)
            {
                throw new JsonException(fileName);
            }
        }
    }
}
