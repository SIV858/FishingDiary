//10.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Runtime.CompilerServices;
using FishingDiary.ViewModels;
using FishingDiary.Models;

namespace FishingDiary.Views
{
    public class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Settings" button
        /// Обработка события нажатия на кнопку настроек
        /// </summary>
        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow()
            {
                DataContext = new SettingsWindowViewModel(),
            };
            settingsWindow.Show();
            this.Close();
        }


        /// <summary>
        /// Handling the event of clicking the "Add" button
        /// Обработка события нажатия на кнопку добавления
        /// </summary>
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow()
            {
                DataContext = new AddWindowViewModel(),
            };
            addWindow.Show();
            this.Close();
        }
    }
}
