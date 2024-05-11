//19.10.23
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using FishingDiary.Models;
using System.Collections.ObjectModel;

namespace FishingDiary.ViewModels
{
    public class SelectLanguagesViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.SelectLanguage.sHead;

        public string txtOk => CommonData.GenLanguages.CommonTexts.sButtonOk;
        public string txtExit => CommonData.GenLanguages.CommonTexts.sButtonExit;

        public string txtLang => CommonData.GenLanguages.SelectLanguage.sChooseLanguage;

        public double dFontSize => Properties.GetInstance().FontSize;

        private ObservableCollection<string> mItems;

        public ObservableCollection<string> Items
        {
            get => mItems;
            set => this.RaiseAndSetIfChanged(ref mItems, value);
        }

        private string mSelectionItem;

        public string SelectedItem
        {
            get => mSelectionItem;
            set => this.RaiseAndSetIfChanged(ref mSelectionItem, value);
        }


        public SelectLanguagesViewModel()
        {
            //Load languages
            AvailableLanguages availableLanguages = new AvailableLanguages(PathsAndConstants.LANGUAGES_PATH);

            Items = new ObservableCollection<string>(availableLanguages.Languages);
        }

        public bool ApplyLanguage()
        {
            LanguageParser parser = new LanguageParser(PathsAndConstants.LOCALE_PATH + mSelectionItem + PathsAndConstants.EXT_JSON);
            if (!parser.ParseLanguageFile())
            {
                return false;
            }

            CommonData.CurrentLang.CreateCurrentLanguageFile(mSelectionItem);
            CommonData.ParsingLanguage = true;

            return true;
        }

    }
}
