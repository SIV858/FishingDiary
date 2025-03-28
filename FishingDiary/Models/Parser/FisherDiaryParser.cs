// 22.02.24
using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingDiary.Models
{
    public enum TypeListElements
    {
        Methods,
        Tackles,
        Groundbaits,
        Baits
    }

    public class FisherDiaryParser
    {
        private string _BodyOfWater;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private string _DescriptionWater;
        private string _Road;
        private AirTemperature _AirTemperature;
        private Precipitation _Precipitation;
        private WindDirection _WindDirection;
        private WindSpeed _WindSpeed;
        private bool _WaxingMoon;
        private MoonPhase _MoonPhase;
        private ushort _Pressure;
        private List<DataElement> _FishingMethods;
        private List<DataElement> _FishingTackles;
        private List<DataElement> _Groundbaits;
        private List<DataElement> _Baits;
        private Biting _Biting;
        private string _CaughtFishes;
        private string _MaxWeightFishName;
        private float _MaxWeightFish;
        private string _OtherFishers;
        private string _Description;
        private float _TotalWeight;
        private string _ImagePath;


        private string _Data;
        private int _DataIndex;

        // Lists of elements to match the texts in the fisherman's diary and id
        private List<DataElement> _MethodsList;
        private List<DataElement> _TacklesList;
        private List<DataElement> _GroundbaitsList;
        private List<DataElement> _BaitsList;


        public string Water => _BodyOfWater;
        public DateTime StartDate => _StartDate;
        public DateTime EndDate => _EndDate;
        public AirTemperature AirTemperature => _AirTemperature;
        public Precipitation Precipitation => _Precipitation;
        public WindDirection WindDirection => _WindDirection;
        public WindSpeed WindSpeed => _WindSpeed;
        public bool WaxingMoon => _WaxingMoon;
        public MoonPhase MoonPhase => _MoonPhase;
        public ushort Pressure => _Pressure;
        public Biting Biting => _Biting;
        public float TotalWeight => _TotalWeight;
        public string Description => _Description;
        public string ImagePath => _ImagePath;
        public List<DataElement> Methods => _FishingMethods;
        public List<DataElement> Tackles => _FishingTackles;
        public List<DataElement> Groundbaits => _Groundbaits;
        public List<DataElement> Baits => _Baits;



        public FisherDiaryParser(string Data)
        {
            _DataIndex = 0;
            _Data = Data;

            _MethodsList = new List<DataElement>();
            _MethodsList.Add(new DataElement() { Id = 1, Text = "поплав" });
            _MethodsList.Add(new DataElement() { Id = 2, Text = "донка" });
            _MethodsList.Add(new DataElement() { Id = 3, Text = "блесн" });
            _MethodsList.Add(new DataElement() { Id = 3, Text = "спин" });
            _MethodsList.Add(new DataElement() { Id = 4, Text = "нахлыст" });
            _MethodsList.Add(new DataElement() { Id = 6, Text = "мормышка" });

            _TacklesList = new List<DataElement>();
            _TacklesList.Add(new DataElement() { Id = 1, Text = "маховая" });
            _TacklesList.Add(new DataElement() { Id = 2, Text = "болонская" });
            _TacklesList.Add(new DataElement() { Id = 3, Text = "донка" });
            _TacklesList.Add(new DataElement() { Id = 4, Text = "фидер" });
            _TacklesList.Add(new DataElement() { Id = 5, Text = "спиннинг" });
            _TacklesList.Add(new DataElement() { Id = 6, Text = "зимняя" });

            _GroundbaitsList = new List<DataElement>();
            _GroundbaitsList.Add(new DataElement() { Id = 1, Text = "нет" });
            _GroundbaitsList.Add(new DataElement() { Id = 2, Text = "перловка" });
            _GroundbaitsList.Add(new DataElement() { Id = 3, Text = "кукуруза" });
            _GroundbaitsList.Add(new DataElement() { Id = 4, Text = "каша" });
            _GroundbaitsList.Add(new DataElement() { Id = 5, Text = "пшено" });

            _BaitsList = new List<DataElement>();
            _BaitsList.Add(new DataElement() { Id = 1, Text = "болтушка" });
            _BaitsList.Add(new DataElement() { Id = 2, Text = "кукуруза" });
            _BaitsList.Add(new DataElement() { Id = 3, Text = "манка" });
            _BaitsList.Add(new DataElement() { Id = 4, Text = "мотыль" });
            _BaitsList.Add(new DataElement() { Id = 5, Text = "опарыш" });
            _BaitsList.Add(new DataElement() { Id = 6, Text = "перловка" });
            _BaitsList.Add(new DataElement() { Id = 7, Text = "хлеб" });
            _BaitsList.Add(new DataElement() { Id = 8, Text = "червь" });
        }

        private AirTemperature ConvertStringToAirTemperature(string temperature)
        {
            switch (temperature)
            {
                case "-30...-35":
                    return AirTemperature.Minus35_Minus30;
                case "-25...-30":
                    return AirTemperature.Minus30_Minus25;
                case "-20...-25":
                    return AirTemperature.Minus25_Minus20;
                case "-15...-20":
                    return AirTemperature.Minus20_Minus15;
                case "-10...-15":
                    return AirTemperature.Minus15_Minus10;
                case "-5...-10":
                    return AirTemperature.Minus10_Minus5;
                case "0...-5":
                    return AirTemperature.Minus5_Zero;
                case "0...+5":
                    return AirTemperature.Zero_Plus5;
                case "+5...+10":
                    return AirTemperature.Plus5_Plus10;
                case "+10...+15":
                    return AirTemperature.Plus10_Plus15;
                case "+15...+20":
                    return AirTemperature.Plus15_Plus20;
                case "+20...+25":
                    return AirTemperature.Plus20_Plus25;
                case "+25...+30":
                    return AirTemperature.Plus25_Plus30;
                case "+30...+35":
                    return AirTemperature.Plus30_Plus35;
                case "+35...+40":
                    return AirTemperature.Plus35_Plus40;
                default:
                    return AirTemperature.Plus15_Plus20;
            }
        }

        public static Precipitation ConvertStringToPrecipitation(string precipitation)
        {
            switch (precipitation)
            {
                case "ясно":
                    return Precipitation.Sun;
                case "облачно":
                    return Precipitation.Cloudy;
                case "пасмурно":
                    return Precipitation.Overcast;
                case "дождь":
                    return Precipitation.Rain;
                case "гроза":
                    return Precipitation.Thunderstorm;
                case "снег":
                    return Precipitation.Snow;
                case "метель":
                    return Precipitation.Blizzard;
                default:
                    return Precipitation.Sun;
            }
        }


        public WindDirection ConvertStringToWindDirection(string windDirection)
        {
            switch (windDirection)
            {
                case "северный":
                    return WindDirection.North;
                case "восточный":
                    return WindDirection.East;
                case "южный":
                    return WindDirection.South;
                case "западный":
                    return WindDirection.West;
                case "северо-восточный":
                    return WindDirection.NorthEast;
                case "северо-западный":
                    return WindDirection.NorthWest;
                case "юго-восточный":
                    return WindDirection.SouthEast;
                case "юго-западный":
                    return WindDirection.SouthWest;
                default:
                    return WindDirection.West;
            }
        }


        public WindSpeed ConvertStringToWindSpeed(string windSpeed)
        {
            switch (windSpeed)
            {
                case "штиль":
                    return WindSpeed.Calm;
                case "1":
                    return WindSpeed.S1;
                case "2":
                    return WindSpeed.S2;
                case "3":
                    return WindSpeed.S3;
                case "4":
                    return WindSpeed.S4;
                case "5":
                    return WindSpeed.S5;
                case "6":
                    return WindSpeed.S6;
                case "порывистый":
                    return WindSpeed.StrongWind;
                case "сильный":
                    return WindSpeed.StrongWind;
                case "ураган":
                    return WindSpeed.Hurricane;
                default:
                    return WindSpeed.S2;
            }
        }

        public MoonPhase ConvertStringToPhase(string phase)
        {
            switch(phase)
            {
                case "нов":
                    return MoonPhase.NewMoon;
                case "10%":
                    return MoonPhase.P10;
                case "20%":
                    return MoonPhase.P20;
                case "30%":
                    return MoonPhase.P30;
                case "40%":
                    return MoonPhase.P40;
                case "50%":
                    return MoonPhase.P50;
                case "60%":
                    return MoonPhase.P60;
                case "70%":
                    return MoonPhase.P70;
                case "80%":
                    return MoonPhase.P80;
                case "90%":
                    return MoonPhase.P90;
                default:
                    return MoonPhase.FullMoon;
            }
        }

        public Biting ConvertStringToBiting(string biting)
        {
            switch (biting)
            {
                case "клёва небыло":
                    return Biting.NoFishCaught;
                case "плохой клёв":
                    return Biting.FishCaughtBad;
                case "нормальный клёв":
                    return Biting.FishCaughtNormal;
                case "хорошо клевало, но не попадалась":
                    return Biting.FishCaughtNormal;
                case "хорошо клевало, ":
                    return Biting.FishCaughtGood;
                case "клёв превосходный!":
                    return Biting.FishCaughtExcellent;
                default:
                    return Biting.Unknown;
            }
        }

        /// <summary>
        /// Parse Moon phase
        /// </summary>
        /// <param name="Data">String</param>
        /// <param name="moonPhase">Moon phase</param>
        /// <returns>Is the moon waxing?</returns>
        private bool ParseMoonPhase(string Data, out MoonPhase moonPhase)
        {
            moonPhase = MoonPhase.FullMoon;
            int positionOfNewLine = Data.IndexOf("-");
            if (positionOfNewLine >= 0)
            {
                positionOfNewLine++;
                string phase = String.Empty;
                if (Data.Length >= positionOfNewLine + 3)
                {
                    phase = Data.Substring(positionOfNewLine, 3);
                }
                moonPhase = ConvertStringToPhase(phase);
                if (positionOfNewLine == 16)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }


        private List<DataElement> ParseMethodsList(List<string> Elements)
        {
            List<DataElement> Result = new List<DataElement>();
            if (Elements.Count == 1 && Elements.First() == String.Empty)
            {
                Result.Add(new DataElement() { Id = 0, Text = CommonData.EditableTexts.Methods.First().Text });
            }

            foreach (string Element in Elements)
            {
                foreach (DataElement method in _MethodsList)
                {
                    if (Element.IndexOf(method.Text) != -1)
                    {
                        DataElement dataElement = CommonData.EditableTexts.Methods.Find(x=>x.Id == method.Id);
                        Result.Add(dataElement);
                        break;
                    }
                }
            }
            return Result;
        }

        private List<DataElement> ParseTacklesList(List<string> Elements)
        {
            List<DataElement> Result = new List<DataElement>();
            if (Elements.Count == 1 && Elements.First() == String.Empty)
            {
                Result.Add(new DataElement() { Id = 0, Text = CommonData.EditableTexts.FishingTackle.First().Text });
            }

            foreach (string Element in Elements)
            {
                foreach (DataElement method in _TacklesList)
                {
                    if (Element.IndexOf(method.Text) != -1)
                    {
                        DataElement dataElement = CommonData.EditableTexts.FishingTackle.Find(x => x.Id == method.Id);
                        Result.Add(dataElement);
                        break;
                    }
                }
            }
            return Result;
        }

        private List<DataElement> ParseGroundbaitsList(List<string> Elements)
        {
            List<DataElement> Result = new List<DataElement>();
            if (Elements.Count == 1 && Elements.First() == String.Empty)
            {
                Result.Add(new DataElement() { Id = 0, Text = CommonData.EditableTexts.Groundbaits.First().Text });
            }

            foreach (string Element in Elements)
            {
                foreach (DataElement method in _GroundbaitsList)
                {
                    if (Element.IndexOf(method.Text) != -1)
                    {
                        DataElement dataElement = CommonData.EditableTexts.Groundbaits.Find(x => x.Id == method.Id);
                        Result.Add(dataElement);
                        break;
                    }
                }
            }
            return Result;
        }

        private List<DataElement> ParseBaitsList(List<string> Elements)
        {
            List<DataElement> Result = new List<DataElement>();
            if (Elements.Count == 1 && Elements.First() == String.Empty)
            {
                Result.Add(new DataElement() { Id = 0, Text = CommonData.EditableTexts.Baits.First().Text });
            }

            foreach (string Element in Elements)
            {
                foreach (DataElement method in _BaitsList)
                {
                    if (Element.IndexOf(method.Text) != -1)
                    {
                        DataElement dataElement = CommonData.EditableTexts.Baits.Find(x => x.Id == method.Id);
                        Result.Add(dataElement);
                        break;
                    }
                }
            }
            return Result;
        }

        private List<DataElement> ParseListElements(string Elements, TypeListElements typeListElements)
        {
            List<string> elementsString = new List<string>();
            int oldIndex = 0;
            int index = 0;
            do
            {
                index = Elements.IndexOf(",", oldIndex);
                if (index == -1)
                {
                    elementsString.Add(Elements.Substring(oldIndex, Elements.Length - oldIndex).ToLower());
                }
                else
                {
                    elementsString.Add(Elements.Substring(oldIndex, index - oldIndex).ToLower());
                }
                oldIndex = index + 1;
            } while (index != -1);

            switch(typeListElements)
            {
                case TypeListElements.Methods:
                    return ParseMethodsList(elementsString);
                case TypeListElements.Tackles:
                    return ParseTacklesList(elementsString);
                case TypeListElements.Groundbaits:
                    return ParseGroundbaitsList(elementsString);
                case TypeListElements.Baits:
                    return ParseBaitsList(elementsString);
                default:
                    return null;
            }
        }


        private string ReadLine()
        {
            int positionOfNewLine = _Data.IndexOf("\r\n", _DataIndex);
            if (positionOfNewLine >= 0)
            {
                string partBefore = _Data.Substring(_DataIndex, positionOfNewLine - _DataIndex);
                _DataIndex = positionOfNewLine + 2;
                return partBefore;
            }
            return String.Empty;
        }


        public void Parse()
        {
            _BodyOfWater = ReadLine();
            _StartDate = DateTime.Parse(ReadLine());
            _EndDate = DateTime.Parse(ReadLine());
            _DescriptionWater = ReadLine();
            _Road = ReadLine();
            _AirTemperature = ConvertStringToAirTemperature(ReadLine());
            _Precipitation = ConvertStringToPrecipitation(ReadLine());
            _WindDirection = ConvertStringToWindDirection(ReadLine());
            _WindSpeed = ConvertStringToWindSpeed(ReadLine());
            MoonPhase moonPhase;
            _WaxingMoon = ParseMoonPhase(ReadLine(), out moonPhase);
            _MoonPhase = moonPhase;
            try
            {
                _Pressure = ushort.Parse(ReadLine());
            }catch(Exception) 
            {
                _Pressure = 750;
            }
            _FishingMethods = ParseListElements(ReadLine(), TypeListElements.Methods);
            _FishingTackles = ParseListElements(ReadLine(), TypeListElements.Tackles);
            _Groundbaits = ParseListElements(ReadLine(), TypeListElements.Groundbaits);
            _Baits = ParseListElements(ReadLine(), TypeListElements.Baits);
            _Biting = ConvertStringToBiting(ReadLine());
            _CaughtFishes = ReadLine();
            _MaxWeightFishName = ReadLine();
            _MaxWeightFish = float.Parse(ReadLine());
            _OtherFishers = ReadLine();
            _Description = ReadLine();
            _TotalWeight = float.Parse(ReadLine());
            _ImagePath = ReadLine();

    }

    }
}
