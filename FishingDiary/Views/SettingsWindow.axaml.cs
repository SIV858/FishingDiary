//15.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);         
        }

        /// <summary>
        /// Handling the event of clicking the "Ok" button
        /// Обработка события нажатия на кнопку ОК
        /// </summary>
        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            SettingsWindowViewModel model = (SettingsWindowViewModel)this.DataContext;
            if (!model.ApplySettings())
            {
                MessageBox.Show(this, CommonData.GenLanguages.SelectLanguage.sErrorCorruptedFile, CommonData.GenLanguages.CommonTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Handling the event of clicking the "Cancel" button
        /// Обработка события нажатия на кнопку отмены
        /// </summary>
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Handling the event of clicking the "Apply" button
        /// Обработка события нажатия на кнопку применить
        /// </summary>
        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            SettingsWindowViewModel model = (SettingsWindowViewModel)this.DataContext;
            if (!model.ApplySettings())
            {
                MessageBox.Show(this, CommonData.GenLanguages.SelectLanguage.sErrorCorruptedFile, CommonData.GenLanguages.CommonTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }

            //If the language has changed, then redraw the window, location and size unchanged
            //Если изменился язык, то перерисовываем окно на том же месте и с теми же размерам 
            //if (model.IsLanguageChanged)
            //{
            //    this.InitializeComponent();
            //}
        }
    }
}
