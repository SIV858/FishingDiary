//19.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public class AddWindow : Window
    {
        public AddWindow()
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
        /// Handling the event of clicking the "Add" button
        /// Обработка события нажатия на кнопку добавить
        /// </summary>
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddWindowViewModel model = (AddWindowViewModel)this.DataContext;
            model.AddCurrentReport();

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
    }
}
