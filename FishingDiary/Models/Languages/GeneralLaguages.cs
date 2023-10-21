//19.10.23
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class GeneralLaguages
    {
        public GeneralLaguages()
        {
            CommonTexts = new CCommonTexts();
            SelectLanguage = new CSelectLanguage();
            MainWindow = new CMainWindow();
            Settings = new CSettings();
            GeneralReport = new CGeneralReport();
            AddReport = new CAddReport();
        }

        public CCommonTexts CommonTexts { get; set; }
        public CSelectLanguage SelectLanguage { get; set; }
        public CMainWindow MainWindow { get; set; }
        public CSettings Settings { get; set; }
        public CGeneralReport GeneralReport { get; set; }
        public CAddReport AddReport { get; set; }
    }
}
