//03.01.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class RecordFish
    {
        public ushort Id;
        public string NameFish;
        public string Quantity;       // needed for compatibility
        public string Bait;
        public string Method;
        public float AveragLength;    // in centimeters
        public float MaxLength;       // in centimeters
        public uint MaxWeight;        // in grams, 0 if weight was not measured
        public DateTime Time;         // Time of catching fish, null if Quantity > 1
    }
}
