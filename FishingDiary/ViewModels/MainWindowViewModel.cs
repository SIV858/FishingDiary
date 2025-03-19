//10.09.20
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FishingDiary.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private double mWidth = 800;
        private double mHeight = 480;

        private double mButtonsHeight = 30;

        private double mPicsHeight = 165;


        private string mHead = CommonData.GenLanguages.MainWindow.sHead;
        private string mAddButton = CommonData.GenLanguages.MainWindow.sAddButton;
        private string mViewButton = CommonData.GenLanguages.MainWindow.sViewButton;
        private string mStatButton = CommonData.GenLanguages.MainWindow.sStatButton;
        private string mEditorButton = CommonData.GenLanguages.MainWindow.sEditorButton;
        private string mSettingsButton = CommonData.GenLanguages.MainWindow.sSettings;

        public double dFontSize => Properties.GetInstance().FontSize;

        public string txtHead
        {
            get => mHead;
            set => this.RaiseAndSetIfChanged(ref mHead, value);
        }
        public string txtAddButton
        {
            get => mAddButton;
            set => this.RaiseAndSetIfChanged(ref mAddButton, value);
        }
        public string txtSettingsButton
        {
            get => mSettingsButton;
            set => this.RaiseAndSetIfChanged(ref mSettingsButton, value);
        }

        public string txtViewButton
        {
            get => mViewButton;
            set => this.RaiseAndSetIfChanged(ref mViewButton, value);
        }

        public string txtStatButton
        {
            get => mStatButton;
            set => this.RaiseAndSetIfChanged(ref mStatButton, value);
        }

        public string txtEditorButton
        {
            get => mEditorButton;
            set => this.RaiseAndSetIfChanged(ref mEditorButton, value);
        }


        public MainWindowViewModel()
        {
            if (!CommonData.ParsingLanguage)
            {
                LanguageParser parser = new LanguageParser(PathsAndConstants.LOCALE_PATH + CommonData.CurrentLang.Language + PathsAndConstants.EXT_JSON);
                if (!parser.ParseLanguageFile())
                {

                }
                UpdateLang();
            }

            // Parse ShortReportList
            ShortReportsList.LoadReporstList(PathsAndConstants.SHORT_REPORT_PATH);
        }

        public void Redraw()
        {
            UpdateLang();
        }

        /// <summary>
        /// Height images
        /// Высота картинок
        /// </summary>
        public double PicsHeight
        {
            get => mPicsHeight;

            set => this.RaiseAndSetIfChanged(ref mPicsHeight, value);

        }

        /// <summary>
        /// Height buttons
        /// Высота кнопок
        /// </summary>
        public double ButtonsHeight
        {
            get => mButtonsHeight;

            set => this.RaiseAndSetIfChanged(ref mButtonsHeight, value);

        }

        /// <summary>
        /// Width window
        /// Ширина окна
        /// </summary>
        public double Width
        {
            get
            {
                return mWidth;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref mWidth, value);
                UpdateViews();
            }
        }

        /// <summary>
        /// Height window
        /// Высота окна
        /// </summary>
        public double Height
        {
            get
            {
                return mHeight;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref mHeight, value);
                UpdateViews();
            }
        }

        /// <summary>
        /// Update window elements
        /// Функция обновления элементов окна
        /// </summary>
        private void UpdateViews()
        {
            ButtonsHeight = mHeight / 15;
            PicsHeight = mHeight / (mHeight / ((mHeight - ButtonsHeight * 5) / 2));
        }

        private void UpdateLang()
        {
            txtHead = CommonData.GenLanguages.MainWindow.sHead;
            txtAddButton = CommonData.GenLanguages.MainWindow.sAddButton;
            txtViewButton = CommonData.GenLanguages.MainWindow.sViewButton;
            txtStatButton = CommonData.GenLanguages.MainWindow.sStatButton;
            txtEditorButton = CommonData.GenLanguages.MainWindow.sEditorButton;
            txtSettingsButton = CommonData.GenLanguages.MainWindow.sSettings;
        }
    }
}
