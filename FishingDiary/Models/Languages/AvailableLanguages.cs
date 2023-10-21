//17.10.23
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class AvailableLanguages
    {
        public AvailableLanguages(string sPath)
        {
            LoadLanguages(sPath);
        }

        private void LoadLanguages(string sPath)
        {
            using (StreamReader reader = new StreamReader(sPath))
            {
                string json = reader.ReadToEnd();
                var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                mLanguagesList = JsonSerializer.Deserialize<List<string>>(readOnlySpan);
            }
        }

        public List<string> Languages
        {
            get
            {
                return mLanguagesList;
            }      
        }

        List<string> mLanguagesList;
    }
}
