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
            model.ApplySettings();
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(),
            };
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Handling the event of clicking the "Cancel" button
        /// Обработка события нажатия на кнопку отмены
        /// </summary>
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(),
            };
            mainWindow.Show();
            this.Close();
        }


        /// <summary>
        /// Handling the event of clicking the "Apply" button
        /// Обработка события нажатия на кнопку применить
        /// </summary>
        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            SettingsWindowViewModel model = (SettingsWindowViewModel)this.DataContext;
            model.ApplySettings();

            //If the language has changed, then redraw the window, location and size unchanged
            //Если изменился язык, то перерисовываем окно на том же месте и с теми же размерам 
            if (model.IsLanguageChanged)
            {
                SettingsWindow settingsWindow = new SettingsWindow()
                {
                    DataContext = new SettingsWindowViewModel(),
                    Position = new PixelPoint(this.Position.X, this.Position.Y),
                    Height = this.Height,
                    Width = this.Width,
                    WindowState = this.WindowState,
                };
                settingsWindow.Show();
                this.Close();
            }
        }
    }
}
