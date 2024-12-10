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
        public string sParamNotFound { get; set; } = "Parameter with given ID not found (Parameter:ID): ";
        public string sNullNameWater { get; set; } = "It is necessary to specify the name of the reservoir";
        public string sIdAlreadyExists { get; set; } = "Such an Id already exists";
    }
}
