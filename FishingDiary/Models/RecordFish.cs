//03.01.24
using FishingDiary.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FishingDiary.Models
{
    public class RecordFish
    {
        private const ushort START_ID = 1;


        private static ushort _currentId = START_ID;

        private ushort _id = 0;

        private int _FishIdView = 0;
        private int _BaitIdView = 0;
        private int _MethodIdView = 0;
        private int _OptionIdView = 0;

        public ushort Id
        {
            get => _id;
            set => _id = value;
        }
        public int FishId { get; set; }
        [JsonIgnore] public int FishIdView 
        {
            get 
            {
                if (_FishIdView == 0 && FishId != 0)
                {
                    _FishIdView = CommonData.EditableTexts.Fishes.FindIndex(0, x => x.Id == (uint)FishId);
                }
                return _FishIdView;
            }
            set 
            {
                _FishIdView = value;
                FishId = (int)CommonData.EditableTexts.Fishes[_FishIdView].Id;
            }
        } // ID for viewing
        public ushort Quantity { get; set; }      // needed for compatibility
        public int BaitId { get; set; }
        [JsonIgnore] public int BaitIdView
        {
            get
            {
                if (_BaitIdView == 0 && BaitId != 0)
                {
                    _BaitIdView = CommonData.EditableTexts.Baits.FindIndex(0, x => x.Id == (uint)BaitId);
                }
                return _BaitIdView;
            }
            set
            {
                _BaitIdView = value;
                BaitId = (int)CommonData.EditableTexts.Baits[_BaitIdView].Id;
            }
        } // ID for viewing

        public int MethodId { get; set; }
        [JsonIgnore] public int MethodIdView
        {
            get
            {
                if (_MethodIdView == 0 && MethodId != 0)
                {
                    _MethodIdView = CommonData.EditableTexts.Methods.FindIndex(0, x => x.Id == (uint)MethodId);
                }
                return _MethodIdView;
            }
            set
            {
                _MethodIdView = value;
                MethodId = (int)CommonData.EditableTexts.Methods[_MethodIdView].Id;
            }
        } // ID for viewing
        public int OptionId { get; set; }           // Option for Method
        [JsonIgnore] public int OptionIdView
        {
            get
            {
                if (_OptionIdView == 0 && OptionId != 0)
                {
                    _OptionIdView = CommonData.EditableTexts.Options.FindIndex(0, x => x.Id == (uint)OptionId);
                }
                return _OptionIdView;
            }
            set
            {
                _OptionIdView = value;
                OptionId = (int)CommonData.EditableTexts.Options[_OptionIdView].Id;
            }
        } // ID for viewing
        public float AverageLength { get; set; }    // in centimeters
        public float MaxLength { get; set; }       // in centimeters
        public uint MaxWeight { get; set; }        // in grams, 0 if weight was not measured
        public DateTime Time { get; set; }         // Time of catching fish, null if Quantity > 1


        [JsonIgnore] public List<string> Fishes => CommonData.EditableTexts.FishesText;
        [JsonIgnore] public List<string> Baits => CommonData.EditableTexts.BaitsText;
        [JsonIgnore] public List<string> Methods => CommonData.EditableTexts.MethodsText;
        [JsonIgnore] public List<string> Options => CommonData.EditableTexts.OptionsText;

        public RecordFish()
        {
            Id = _currentId;
            _currentId++;
            FishId = 0;
            Quantity = 1;
            BaitId = 0;
            MethodId = 0;
            OptionId = 0;
            AverageLength = 16;
            MaxLength = 18;
            MaxWeight = 0;
        }

        public static void DecrementId()
        {
            _currentId--;
        }

        public static void ResetId()
        {
            SetId(START_ID);
        }

        public static void SetId(ushort Id)
        {
            _currentId = Id;
        }
    }
}
