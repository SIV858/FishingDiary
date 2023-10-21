//15.09.20
using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using FishingDiary.Models;
using System.Collections.ObjectModel;

namespace FishingDiary.ViewModels
{
    public class SettingsWindowViewModel : ViewModelBase
    {

        private string mSelectionItem;

        private bool mIsLanguageChanged = false;

        private string mHead = CommonData.GenLanguages.Settings.sHead;
        private string mOk = CommonData.GenLanguages.CommonTexts.sButtonOk;
        private string mCancel = CommonData.GenLanguages.CommonTexts.sButtonCancel;
        private string mApply = CommonData.GenLanguages.CommonTexts.sButtonApply;
        private string mLang = CommonData.GenLanguages.Settings.sLanguage;

        public double dFontSize => Properties.FontSize;

        public string txtHead
        {
            get => mHead;
            set => this.RaiseAndSetIfChanged(ref mHead, value);
        }
        public string txtOk
        {
            get => mOk;
            set => this.RaiseAndSetIfChanged(ref mOk, value);
        }
        public string txtCancel
        {
            get => mCancel;
            set => this.RaiseAndSetIfChanged(ref mCancel, value);
        }

        public string txtApply
        {
            get => mApply;
            set => this.RaiseAndSetIfChanged(ref mApply, value);
        }
        public string txtLang
        {
            get => mLang;
            set => this.RaiseAndSetIfChanged(ref mLang, value);
        }

        public string txtSelectionItem
        {
            get => mSelectionItem;
            set => this.RaiseAndSetIfChanged(ref mSelectionItem, value);
        }

        public SettingsWindowViewModel()
        {
            mSelectionItem = CommonData.CurrentLang.Language;

            //Load languages
            AvailableLanguages availableLanguages = new AvailableLanguages(PathsAndConstants.LANGUAGES_PATH);
            mLangItems = new ObservableCollection<string>();

            foreach (var sLang in availableLanguages.Languages)
            {
                mLangItems.Add(sLang);
            }
        }

        public ObservableCollection<string> mLangItems;

        public ObservableCollection<string> LangItems
        {
            get => mLangItems;
            set => this.RaiseAndSetIfChanged(ref mLangItems, value);
        }

        public bool IsLanguageChanged => mIsLanguageChanged;

        /// <summary>
        /// Apply settings
        /// Приминение настроек
        /// </summary>
        public bool ApplySettings()
        {
            if (mSelectionItem != CommonData.CurrentLang.Language)
            {
                LanguageParser parser = new LanguageParser(PathsAndConstants.LOCALE_PATH + mSelectionItem + PathsAndConstants.EXT_JSON);
                if (!parser.ParseLanguageFile())
                {
                    return false;
                }
                CommonData.CurrentLang.CreateCurrentLanguageFile(mSelectionItem);
                CommonData.ParsingLanguage = true;
                mIsLanguageChanged = true;
                UpdateLang();
            }
            return true;
        }

        private void UpdateLang()
        {
            txtHead = CommonData.GenLanguages.Settings.sHead;
            txtOk = CommonData.GenLanguages.CommonTexts.sButtonOk;
            txtCancel = CommonData.GenLanguages.CommonTexts.sButtonCancel;
            txtApply = CommonData.GenLanguages.CommonTexts.sButtonApply;
            txtLang = CommonData.GenLanguages.Settings.sLanguage;
        }


    }
}
