//12.02.25

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FishingDiary.Models
{
    public class DataFish : IComparable<DataFish>
    {
        public uint RecordId { get; set; }
        public int FishId { get; set; }
        public int BaitId { get; set; }
        public int MethodId { get; set; }
        public int OptionId { get; set; }           // Option for Method
        public string BodyOfWater { get; set; } // the body of water where the fish was caught 
        public float Length { get; set; }       // in centimeters
        public uint Weight { get; set; }        // in grams, 0 if weight was not measured
        public DateTime Time { get; set; }         // Time of catching fish, null if Quantity > 1

        public int CompareTo(DataFish other)
        {
            return String.Compare(CommonData.EditableTexts.Fishes[this.FishId].Text,
                CommonData.EditableTexts.Fishes[other.FishId].Text);
        }
    }
}
