﻿//10.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System;
using System.Runtime.CompilerServices;
using FishingDiary.ViewModels;
using FishingDiary.Models;
using System.Text;

namespace FishingDiary.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }


        /// <summary>
        /// Handling the event of clicking the "Add" button
        /// </summary>
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow()
            {
                DataContext = new AddWindowViewModel(),
            };
            addWindow.ShowDialog(this);
        }


        /// <summary>
        /// Handling the event of clicking the "View" button
        /// </summary>
        private void OnViewClick(object sender, RoutedEventArgs e)
        {
            ViewWindow viewWindow = new ViewWindow()
            {
                DataContext = new ViewWindowViewModel(),
            };
            viewWindow.ShowDialog(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Statistic" button
        /// </summary>
        private void OnStatClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindow viewWindow = new StatisticsWindow()
            {
                DataContext = new StatisticsWindowViewModel(),
            };
            viewWindow.ShowDialog(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Editor" button
        /// </summary>
        private void OnEditorClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditorWindow editorWindow = new EditorWindow()
                {
                    DataContext = new EditorWindowViewModel(),
                };
                editorWindow.ShowDialog(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show(null, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }
        }

        /// <summary>
        /// Handling the event of clicking the "Settings" button
        /// </summary>
        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow()
            {
                DataContext = new SettingsWindowViewModel(),
            };

            // window redraw delegate
            Action redrawWindow = delegate () {             
                MainWindowViewModel model = (MainWindowViewModel)this.DataContext;
                model.Redraw();
            };

            TaskAwaiter taskAwaiter = settingsWindow.ShowDialog(this).GetAwaiter();

            // redraw the window after exiting the settings
            taskAwaiter.OnCompleted(redrawWindow);
        }

    }
}
