//18.10.23
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class SelectLanguageWindow : Window
    {
        public SelectLanguageWindow()
        {
            this.InitializeComponent();
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
            SelectLanguagesViewModel model = (SelectLanguagesViewModel)this.DataContext;
            if (!model.ApplyLanguage())
            {
                MessageBox.Show(this, CommonData.GenLanguages.ErrorTexts.sErrorCorruptedLanguageFile, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(),
            };
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handling the event of clicking the "Exit" button
        /// Обработка события нажатия на кнопку выхода
        /// </summary>
        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
