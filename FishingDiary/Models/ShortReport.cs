//30.04.24
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FishingDiary.Models
{
    /// <summary>
    /// One report
    /// Один отчёт
    /// </summary>
    public class ShortReport
    {
        /// <summary>
        /// Id report beginning with 1
        /// 0 - error
        /// </summary>
        public uint ReportId { get; } = 0;

        /// <summary>
        /// Start date fishing
        /// </summary>
        public DateTime StartDate { get; } = DateTime.Now;

        /// <summary>
        /// End date fishing
        /// </summary>
        public DateTime EndDate { get; } = DateTime.Now;

        /// <summary>
        /// Body Of Water
        /// </summary>
        public string BodyOfWater { get; } = String.Empty;

        /// <summary>
        /// The path to the photo of the pond
        /// </summary>
        public string PhotoPath { get; set; } = String.Empty;

        /// <summary>
        /// Path to the full report
        /// </summary>
        public string ReportPath { get; set; } = String.Empty;

        /// <summary>
        /// Air Temperature
        /// </summary>
        public AirTemperature AirTemperature { get; } = AirTemperature.Plus15_Plus20;

        /// <summary>
        /// Precipitation
        /// </summary>
        public Precipitation Precipitation { get; } = Precipitation.Sun;

        /// <summary>
        /// Wind Direction 
        /// </summary>
        public WindDirection WindDirection { get; } = WindDirection.NorthWest;

        /// <summary>
        /// Wind Speed
        /// </summary>
        public WindSpeed WindSpeed { get; } = WindSpeed.S2;

        /// <summary>
        /// Fishing Method
        /// </summary>
        public List<DataElement> FishingMethods { get; } = new List<DataElement>(); //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        /// <summary>
        /// Total Weight fishes
        /// </summary>
        public float TotalWeight { get; } = 0;


        public ShortReport()
        {

        }

        public ShortReport(Report report)
        {
            ReportId = Properties.GetInstance().CurrentReportId;
            StartDate = report.StartDate;
            EndDate = report.EndDate;
            BodyOfWater = report.BodyOfWater;
            PhotoPath = report.PhotoPath;
            AirTemperature = report.AirTemperature;
            Precipitation = report.Precipitation;
            WindDirection = report.WindDirection;
            WindSpeed = report.WindSpeed;
            FishingMethods = report.FishingMethods;
            TotalWeight = report.TotalWeight;

            Properties.GetInstance().CurrentReportId++;
        }

        public void SaveReport()
        {
            if (!Directory.Exists(PathsAndConstants.SHORT_REPORT_IMAGES_PATH))
            {
                Directory.CreateDirectory(PathsAndConstants.SHORT_REPORT_IMAGES_PATH);
            }

            string photoName = Path.GetFileName(PhotoPath);

            if (photoName != PathsAndConstants.NO_PHOTO_FILE_NAME)
            {
                string ImagePath = PathsAndConstants.SHORT_REPORT_IMAGES_PATH + photoName;

                //reduce and save the original image
                using (Bitmap image = new Bitmap(PhotoPath))
                {
                    Bitmap newImage = image.CreateScaledBitmap(new Avalonia.PixelSize(100, 100));
                    newImage.Save(ImagePath);
                    newImage.Dispose();
                }

                PhotoPath = ImagePath;
            }
            else
            {
                PhotoPath = Path.GetDirectoryName(PhotoPath) + "\\" + PathsAndConstants.NO_PHOTO_FILE_NAME_MINI;
            }


            //Adding a report to a list and saving the list
            ShortReportsList.AddReport(this);
            ShortReportsList.SaveReportsList(PathsAndConstants.SHORT_REPORT_PATH);
        }

    }
}
