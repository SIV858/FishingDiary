//17.10.23
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class LanguageParser
    {
        public LanguageParser(string sLanguage)
        {
            mLanguage = sLanguage;
        }

        public bool ParseLanguageFile()
        {
            try
            {
                //GeneralLaguages gen = new GeneralLaguages();
                //string s = JsonSerializer.Serialize<GeneralLaguages>(gen);

                using (StreamReader reader = new StreamReader(mLanguage))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    CommonData.GenLanguages = JsonSerializer.Deserialize<GeneralLaguages>(readOnlySpan);
                }
            }
            catch(FileNotFoundException)
            {
                return false;
            }
            catch (JsonException)
            {
                return false;
            }

            return true;
        }

        public string GetDataPath()
        {
            GeneralLaguages genLang;

            try
            {
                using (StreamReader reader = new StreamReader(mLanguage))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    genLang = JsonSerializer.Deserialize<GeneralLaguages>(readOnlySpan);
                }
            }
            catch (FileNotFoundException)
            {
                return String.Empty;
            }
            catch (JsonException)
            {
                return String.Empty;
            }

            return PathsAndConstants.COMMON_DATA_PATH + "\\" + genLang.LanguagePaths.sDataPath + "\\";
        }

        private string mLanguage = null;
    }
}
