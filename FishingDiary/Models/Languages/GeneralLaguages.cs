//19.10.23
using FishingDiary.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class GeneralLaguages
    {
        public GeneralLaguages()
        {
            LanguagePaths = new CLanguagePaths();
            CommonTexts = new CCommonTexts();
            SelectLanguage = new CSelectLanguage();
            MainWindow = new CMainWindow();
            Settings = new CSettings();
            GeneralReport = new CGeneralReport();
            AddReport = new CAddReport();
            ViewWindow = new CViewWindow();
            StatWindow = new CStatWindow();
            EditorTexts = new CEditorTexts();
            AddParamTexts = new CAddParamTexts();
        }

        public CLanguagePaths LanguagePaths { get; set; }
        public CCommonTexts CommonTexts { get; set; }
        public CErrorTexts ErrorTexts { get; set; }
        public CSelectLanguage SelectLanguage { get; set; }
        public CMainWindow MainWindow { get; set; }
        public CSettings Settings { get; set; }
        public CGeneralReport GeneralReport { get; set; }
        public CAddReport AddReport { get; set; }
        public CEditReport EditReport { get; set; }
        public CViewWindow ViewWindow { get; set; }
        public CStatWindow StatWindow { get; set; }
        public CEditorTexts EditorTexts { get; set; }
        public CAddParamTexts AddParamTexts {  get; set; }
    }
}
