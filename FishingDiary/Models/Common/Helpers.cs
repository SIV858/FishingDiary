//03.01.24
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

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
    }
}
