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

        private string mSelectionItem = LanguageText.GetSelectionItemLanguage();

        private bool mIsLanguageChanged = false;

        public string txtHead => LanguageText.GetSettingsWindowHeadText();

        public string txtOk => LanguageText.GetOkButtonText();
        public string txtCancel => LanguageText.GetCancelButtonText();
        public string txtApply => LanguageText.GetApplyButtonText();

        public string txtLang => LanguageText.GetSettingsWindowLangText();

        public double dFontSize => Properties.FontSize;

        public string txtSelectionItem
        {
            get => mSelectionItem;
            set => this.RaiseAndSetIfChanged(ref mSelectionItem, value);
        }


        public Collection<string> LangItems => LanguageText.GetLanguageCollection();

        public bool IsLanguageChanged => mIsLanguageChanged;

        /// <summary>
        /// Apply settings
        /// Приминение настроек
        /// </summary>
        public void ApplySettings()
        {
            if (mSelectionItem != LanguageText.GetSelectionItemLanguage())
            {
                LanguageText.SetSelectionItemLanguage(mSelectionItem);
                mIsLanguageChanged = true;
            }
        }


    }
}
