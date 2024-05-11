//19.09.20
using Avalonia.Media.Imaging;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    public class Properties
    {
        private static Properties instance;


        //private static Languages mCurrentLanguage = Languages.English;
        private double mFontSize = 15.0;

        //public static Languages CurrentLanguage
        //{
        //    get => mCurrentLanguage;
        //    set => mCurrentLanguage = value;
        //}

        /// <summary>
        /// Current free report Id
        /// </summary>
        public uint CurrentReportId { get; set; } = 1;

        public double FontSize
        {
            get => mFontSize;
            set => mFontSize = value;
        }

        public static Properties GetInstance()
        {
            if (instance == null)
            {
                // if a file exist then read it
                if (File.Exists(PathsAndConstants.PROPERTIES_PATH))
                {
                    using (StreamReader reader = new StreamReader(PathsAndConstants.PROPERTIES_PATH))
                    {
                        string json = reader.ReadToEnd();

                        var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                        instance = JsonSerializer.Deserialize<Properties>(readOnlySpan);
                    }
                }
                else
                {
                    instance = new Properties();
                }
            }
            return instance;
        }


        public void SaveProperties()
        {

            try
            {
                //Write data to file
                using (StreamWriter writer = new StreamWriter(PathsAndConstants.PROPERTIES_PATH))
                {
                    string json = JsonSerializer.Serialize<Properties>(this);
                    writer.Write(json);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(PathsAndConstants.PROPERTIES_PATH);
            }
            catch (JsonException)
            {
                throw new JsonException(PathsAndConstants.PROPERTIES_PATH);
            }
        }
    }
}
