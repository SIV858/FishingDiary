//20.02.24

using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CErrorTexts
    {
        public string sTextError { get; set; } = "Error";
        public string sErrorCorruptedLanguageFile { get; set; } = "The current language file not found or is corrupted";
        public string sErrorFileNotFound { get; set; } = "The following file was not found: ";
        public string sErrorCorruptedFile { get; set; } = "The following file is corrupted: ";
        public string sErrorOpenFile { get; set; } = "Failed to open file";
        public string sParamNotFound { get; set; } = "Parameter with given ID not found (Parameter:ID): ";
        public string sNullNameWater { get; set; } = "It is necessary to specify the name of the reservoir";
        public string sIdAlreadyExists { get; set; } = "Such an Id already exists";
        public string sNullIdEdit { get; set; } = "The zero element cannot be edited";
        public string sNullIdDelete { get; set; } = "The zero element cannot be deleted";
        public string sNoItemSelected { get; set; } = "No item selected";
        public string sErrorEndDate { get; set; } = "The end date and time of fishing cannot be less than the start time";
        public string sNullMethods { get; set; } = "Fishing methods must be specified";
        public string sNullTackles { get; set; } = "Fishing tackles must be specified";
        public string sNullGroundbaits { get; set; } = "It is necessary to specify the groundbait";
        public string sNullBaits { get; set; } = "It is necessary to specify the bait";
        public string sErrorFishLenght { get; set; } = "The maximum length cannot be less than the average";
        public string sErrorFishTime { get; set; } = "The time of catching fish must fall within the fishing time range";
        public string sErrorOneFishLenght { get; set; } = "The average and maximum lengths of one fish should be equal";
    }
}
