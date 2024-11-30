//03.01.24
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

        public ushort Id 
        {
            get => _id;
            set => _id = value;
        }
        public int FishId { get; set; }
        public ushort Quantity { get; set; }      // needed for compatibility
        public int BaitId { get; set; }
        public int MethodId { get; set; }
        public int OptionId { get; set; }           // Option for Method
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
