//15.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);         
        }

        /// <summary>
        /// Handling the event of clicking the "Ok" button
        /// </summary>
        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            SettingsWindowViewModel model = (SettingsWindowViewModel)this.DataContext;
            if (!model.ApplySettings())
            {
                MessageBox.Show(this, CommonData.GenLanguages.ErrorTexts.sErrorCorruptedLanguageFile, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }
            this.Close();
        }

        /// <summary>
        /// Handling the event of clicking the "Cancel" button
        /// </summary>
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Handling the event of clicking the "Apply" button
        /// </summary>
        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            SettingsWindowViewModel model = (SettingsWindowViewModel)this.DataContext;
            if (!model.ApplySettings())
            {
                MessageBox.Show(this, CommonData.GenLanguages.ErrorTexts.sErrorCorruptedLanguageFile, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }

            //If the language has changed, then redraw the window, location and size unchanged
            //if (model.IsLanguageChanged)
            //{
            //    this.InitializeComponent();
            //}
        }
    }
}
