//30.04.24
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using FishingDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FishingDiary.Models
{
    /// <summary>
    /// One report
    /// </summary>
    public class ShortReport
    {
        /// <summary>
        /// Inscriptions inside a list element 
        /// </summary>
        public static string txtDate => CommonData.GenLanguages.GeneralReport.sDate;
        public static string txtWater => CommonData.GenLanguages.GeneralReport.sWater;
        public static string txtMethod => CommonData.GenLanguages.GeneralReport.sMethod;
        public static string txtTotalWeight => CommonData.GenLanguages.GeneralReport.sTotalWeight;

        public static string txtTemperature => CommonData.GenLanguages.GeneralReport.sTemperature;
        public static string txtPrecipitation => CommonData.GenLanguages.GeneralReport.sPrecipitation;
        public static string txtDirection => CommonData.GenLanguages.GeneralReport.sDirection;
        public static string txtSpeed => CommonData.GenLanguages.GeneralReport.sSpeed;


        public static string txtView => CommonData.GenLanguages.ViewWindow.sView;
        public static string txtEdit => CommonData.GenLanguages.ViewWindow.sEdit;
        public static string txtDelete => CommonData.GenLanguages.ViewWindow.sDelete;


        /// <summary>
        /// Id report beginning with 1
        /// 0 - error
        /// </summary>
        public uint ReportId { get; set; } = 0;

        /// <summary>
        /// Start date fishing
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// End date fishing
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Body Of Water
        /// </summary>
        public string BodyOfWater { get; set; } = String.Empty;

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
        public AirTemperature AirTemperature { get; set; } = AirTemperature.Plus15_Plus20;

        /// <summary>
        /// Precipitation
        /// </summary>
        public Precipitation Precipitation { get; set; } = Precipitation.Sun;

        /// <summary>
        /// Wind Direction 
        /// </summary>
        public WindDirection WindDirection { get; set; } = WindDirection.NorthWest;

        /// <summary>
        /// Wind Speed
        /// </summary>
        public WindSpeed WindSpeed { get; set; } = WindSpeed.S2;

        /// <summary>
        /// Fishing Method
        /// </summary>
        public List<DataElement> FishingMethods { get; set; } = new List<DataElement>(); //bobber, baiting, trolling, Feeder, Carpfishing, fly fishing, ice fishing

        /// <summary>
        /// Total Weight fishes
        /// </summary>
        public float TotalWeight { get; set; } = 0;

        /// <summary>
        /// Photo
        /// </summary>
        [JsonIgnore]
        public Bitmap PhotoMini { get; set; } = null;

        [JsonIgnore]
        public string AirTemperatureText => Helpers.ConvertAirTemperatureToString(AirTemperature);
        [JsonIgnore]
        public string PrecipitationText => Helpers.ConvertPrecipitationToString(Precipitation);
        [JsonIgnore]
        public string WindDirectionText => Helpers.ConvertWindDirectionToString(WindDirection);
        [JsonIgnore]
        public string WindSpeedText => Helpers.ConvertWindSpeedToString(WindSpeed);




        public ShortReport()
        {

        }

        /// <summary>
        /// Constructor from report
        /// </summary>
        /// <param name="report">Report</param>
        public ShortReport(Report report)
        {
            ReportId = Properties.GetInstance().CurrentReportId;

            CopyData(report);

            Properties.GetInstance().CurrentReportId++;
            Properties.GetInstance().PreviousDataTime = report.StartDate;
        }

        private void CopyData(Report report)
        {
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
        }


        public void EditAndSaveReport(Report report)
        {
            CopyData(report);

            string photoName = Path.GetFileName(PhotoPath);

            if (photoName != PathsAndConstants.NO_PHOTO_FILE_NAME)
            {
                string ImagePath = PathsAndConstants.SHORT_REPORT_IMAGES_PATH + photoName;

                //reduce and save the original image
                using (Bitmap image = new Bitmap(PhotoPath))
                {
                    if (image.Size.Width / image.Size.Height > PathsAndConstants.AVERAGE_RATIO_COEF)
                    {
                        PhotoMini = image.CreateScaledBitmap(new Avalonia.PixelSize(PathsAndConstants.WIDTH_16x9_IMAGE,
                            PathsAndConstants.HEIGHT_16x9_IMAGE));
                    }
                    else
                    {
                        PhotoMini = image.CreateScaledBitmap(new Avalonia.PixelSize(PathsAndConstants.WIDTH_4x3_IMAGE,
                            PathsAndConstants.WIDTH_4x3_IMAGE));
                    }
                    PhotoMini.Save(ImagePath);
                }

                PhotoPath = ImagePath;
            }
            else
            {
                PhotoPath = Path.GetDirectoryName(PhotoPath) + "\\" + PathsAndConstants.NO_PHOTO_FILE_NAME_MINI;
            }

            ShortReportsList.SaveReportsList(PathsAndConstants.SHORT_REPORT_PATH);
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
                    if (image.Size.Width / image.Size.Height > PathsAndConstants.AVERAGE_RATIO_COEF)
                    {
                        PhotoMini = image.CreateScaledBitmap(new Avalonia.PixelSize(PathsAndConstants.WIDTH_16x9_IMAGE,
                            PathsAndConstants.HEIGHT_16x9_IMAGE));
                    }
                    else
                    {
                        PhotoMini = image.CreateScaledBitmap(new Avalonia.PixelSize(PathsAndConstants.WIDTH_4x3_IMAGE,
                            PathsAndConstants.WIDTH_4x3_IMAGE));
                    }
                    PhotoMini.Save(ImagePath);  
                }

                PhotoPath = System.IO.Path.GetRelativePath(System.IO.Directory.GetCurrentDirectory(), ImagePath);
            }
            else
            {
                PhotoPath = System.IO.Path.GetRelativePath(System.IO.Directory.GetCurrentDirectory(), 
                    Path.GetDirectoryName(PhotoPath) + "\\" + PathsAndConstants.NO_PHOTO_FILE_NAME_MINI);
            }


            //Adding a report to a list and saving the list
            ShortReportsList.AddReport(this);
            ShortReportsList.SaveReportsList(PathsAndConstants.SHORT_REPORT_PATH);
        }

    }
}
