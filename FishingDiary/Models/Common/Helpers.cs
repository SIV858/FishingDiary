//03.01.24
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SkiaSharp;

namespace FishingDiary.Models
{
    public static class Helpers
    {
        public static Bitmap LoadFromFile(string resourcePath)
        {
            Bitmap image;
            using (Stream imageStream = new FileStream(resourcePath, FileMode.Open))
            {
                image = new Bitmap(imageStream);
            }

            return image;
        }

        public static Bitmap LoadFromResource(string resourcePath)
        {
            Uri resourceUri;

            if (!resourcePath.StartsWith("avares://"))
            {
                var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
                resourceUri = new Uri($"avares://{assemblyName}/{resourcePath.TrimStart('/')}");
            }
            else
            {
                resourceUri = new Uri(resourcePath);
            }

            return new Bitmap(AssetLoader.Open(resourceUri));
        }

        public static string ConvertAirTemperatureToString(AirTemperature temperature)
        {
            switch (temperature)
            {
                case AirTemperature.LessMinus40:
                    return CommonData.GenLanguages.GeneralReport.sTemperatureLessThan;
                case AirTemperature.Minus40_Minus35:
                    return "-40...-35";
                case AirTemperature.Minus35_Minus30:
                    return "-35...-30";
                case AirTemperature.Minus30_Minus25:
                    return "-30...-25";
                case AirTemperature.Minus25_Minus20:
                    return "-25...-20";
                case AirTemperature.Minus20_Minus15:
                    return "-20...-15";
                case AirTemperature.Minus15_Minus10:
                    return "-15...-10";
                case AirTemperature.Minus10_Minus5:
                    return "-10...-5";
                case AirTemperature.Minus5_Zero:
                    return "-5...-0";
                case AirTemperature.Zero_Plus5:
                    return "+0...+5";
                case AirTemperature.Plus5_Plus10:
                    return "+5...+10";
                case AirTemperature.Plus10_Plus15:
                    return "+10...+15";
                case AirTemperature.Plus15_Plus20:
                    return "+15...+20";
                case AirTemperature.Plus20_Plus25:
                    return "+20...+25";
                case AirTemperature.Plus25_Plus30:
                    return "+25...+30";
                case AirTemperature.Plus30_Plus35:
                    return "+30...+35";
                case AirTemperature.Plus35_Plus40:
                    return "+35...+40";
                case AirTemperature.MorePlus40:
                    return CommonData.GenLanguages.GeneralReport.sTemperatureMoreThan;
                default:
                    return CommonData.GenLanguages.ErrorTexts.sTextError;
            }
        }
        public static string ConvertPrecipitationToString(Precipitation precipitation)
        {
            switch (precipitation)
            {
                case Precipitation.Sun:
                    return CommonData.GenLanguages.GeneralReport.sSun;
                case Precipitation.Cloudy:
                    return CommonData.GenLanguages.GeneralReport.sСloudy;
                case Precipitation.Overcast:
                    return CommonData.GenLanguages.GeneralReport.sOvercast;
                case Precipitation.Rain:
                    return CommonData.GenLanguages.GeneralReport.sRain;
                case Precipitation.Thunderstorm:
                    return CommonData.GenLanguages.GeneralReport.sThunderstorm;
                case Precipitation.Snow:
                    return CommonData.GenLanguages.GeneralReport.sSnow;
                case Precipitation.Blizzard:
                    return CommonData.GenLanguages.GeneralReport.sBlizzard;
                default:
                    return CommonData.GenLanguages.ErrorTexts.sTextError;
            }
        }

        public static string ConvertWindDirectionToString(WindDirection windDirection)
        {
            switch (windDirection)
            {
                case WindDirection.North:
                    return CommonData.GenLanguages.GeneralReport.sNorth;
                case WindDirection.East:
                    return CommonData.GenLanguages.GeneralReport.sEastern;
                case WindDirection.South:
                    return CommonData.GenLanguages.GeneralReport.sSouth;
                case WindDirection.West:
                    return CommonData.GenLanguages.GeneralReport.sWest;
                case WindDirection.NorthWest:
                    return CommonData.GenLanguages.GeneralReport.sNorthwest;
                case WindDirection.NorthEast:
                    return CommonData.GenLanguages.GeneralReport.sNortheast;
                case WindDirection.SouthEast:
                    return CommonData.GenLanguages.GeneralReport.sSoutheast;
                case WindDirection.SouthWest:
                    return CommonData.GenLanguages.GeneralReport.sSouthwest;
                default:
                    return CommonData.GenLanguages.ErrorTexts.sTextError;
            }
        }

        public static string ConvertWindSpeedToString(WindSpeed windSpeed)
        {
            switch (windSpeed)
            {
                case WindSpeed.Calm:
                    return CommonData.GenLanguages.GeneralReport.sCalm;
                case WindSpeed.S1:
                    return "1";
                case WindSpeed.S2:
                    return "2";
                case WindSpeed.S3:
                    return "3";
                case WindSpeed.S4:
                    return "4";
                case WindSpeed.S5:
                    return "5";
                case WindSpeed.S6:
                    return "6";
                case WindSpeed.StrongWind:
                    return CommonData.GenLanguages.GeneralReport.sStrong;
                case WindSpeed.Hurricane:
                    return CommonData.GenLanguages.GeneralReport.sHurricane;
                case WindSpeed.Tornado:
                    return CommonData.GenLanguages.GeneralReport.sTornado;
                default:
                    return CommonData.GenLanguages.ErrorTexts.sTextError;
            }
        }

        public static uint ConvertViewReportModeToUint(ViewReportMode viewReportMode)
        {
            switch (viewReportMode)
            {
                case ViewReportMode.All:
                    return 0;
                case ViewReportMode.M8:
                    return 8;
                case ViewReportMode.M10:
                    return 10;
                case ViewReportMode.M20:
                    return 20;
                case ViewReportMode.M50:
                    return 50;
                default:
                    return 0;
            }
        }

        public static string ConvertBoolToString(bool value)
        {
            return value ? "True" : "False";
        }
    }
}
