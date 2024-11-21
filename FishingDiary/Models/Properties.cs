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

    public enum DateTimeMode
    {
        Now,
        Previous,
        Null
    }

    public class Properties
    {
        private static Properties instance;

        private double mFontSize = 15.0;

        /// <summary>
        /// Current free report Id
        /// </summary>
        private uint _CurrentReportId = 1;

        /// <summary>
        /// Previous DataTime
        /// </summary>
        private DateTime _PreviousDataTime = DateTime.Now;

        public uint CurrentReportId
        {
            get => _CurrentReportId;
            set => _CurrentReportId = value;
        }

        public double FontSize
        {
            get => mFontSize;
            set => mFontSize = value;
        }

        public DateTime PreviousDataTime
        {
            get => _PreviousDataTime;
            set => _PreviousDataTime = value;
        }

        public DateTimeMode DateMode
        {
            get => _DateMode;
            set => _DateMode = value;
        }
        internal DateTimeMode _DateMode = DateTimeMode.Now;

        public DateTimeMode TimeMode
        {
            get => _TimeMode;
            set => _TimeMode = value;
        }
        internal DateTimeMode _TimeMode = DateTimeMode.Now;

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
