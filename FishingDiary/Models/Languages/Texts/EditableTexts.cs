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

        public List<DataElement> Baits => _Baits;
        public List<DataElement> Fishes => _Fishes;
        public List<DataElement> FishingTackle => _FishingTackles;
        public List<DataElement> Groundbaits => _Groundbaits;
        public List<DataElement> Methods => _Methods;
        public List<string> MethodsText 
        {
            get
            {
               return _Methods.ConvertAll<string>(x => x.Text);
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


        public EditableTexts(string DataPath)
        {
            _DataPath = DataPath;
        }

        public void Parse()
        {
            string fileName = _DataPath + PathsAndConstants.BAITS_FILE;
            ParseList(fileName, out _Baits);
            fileName = _DataPath + PathsAndConstants.FISHES_FILE;
            ParseList(fileName, out _Fishes);
            fileName = _DataPath + PathsAndConstants.FISHING_TACKLE_FILE;
            ParseList(fileName, out _FishingTackles);
            fileName = _DataPath + PathsAndConstants.GROUNDBAITS_FILE;
            ParseList(fileName, out _Groundbaits);
            fileName = _DataPath + PathsAndConstants.METHODS_FILE;
            ParseList(fileName, out _Methods);
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
    }
}
