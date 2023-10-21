//18.10.23
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class CurrentLanguage
    {
        public bool LoadCurrentLanguage()
        {
            // if a file exist then read it
            if (File.Exists(PathsAndConstants.CURRENT_LANGUAGE_PATH))
            {
                using (StreamReader reader = new StreamReader(PathsAndConstants.CURRENT_LANGUAGE_PATH))
                {
                    mLanguage = reader.ReadToEnd();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateCurrentLanguageFile(string sLanguage)
        {
            mLanguage = sLanguage;
            using (StreamWriter writer = new StreamWriter(PathsAndConstants.CURRENT_LANGUAGE_PATH))
            {
                writer.Write(sLanguage);
            }
        }


        public string Language
        {
            get
            {
                return mLanguage;
            }
        }

        private string mLanguage = null;
    }
}
