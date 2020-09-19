//10.09.20
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private double mWidth = 800;
        private double mHeight = 450;

        private double mButtonsHeight = 30;

        private double mPicsHeight = 180;

        public string txtAddButton => LanguageText.GetMainWindowAddButtonText();
        public string txtSettingsButton => LanguageText.GetMainWindowSettingsButtonText();
        public string txtViewButton => LanguageText.GetMainWindowViewButtonText();

        public string txtHead => LanguageText.GetMainWindowHeadText();

        public double dFontSize => Properties.FontSize;

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
            PicsHeight = mHeight / 2.5;
            ButtonsHeight = mHeight / 15;
        }
    }
}
