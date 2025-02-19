//28.11.24
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FishingDiary.ViewModels;
using System;
using System.IO;

namespace FishingDiary.Views
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
        }

        public void UpdateWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Paint" button
        /// </summary>
        private void OnPaintClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            model.UpdateWindow += UpdateView;
            model.PaintStat();
        }

        /// <summary>
        /// Update event in the model
        /// </summary>
        private void UpdateView(object sender, EventArgs e)
        {
            UpdateWindow();
        }


        /// <summary>
        /// Handling the event of clicking the "Save" button
        /// </summary>
        private async void OnSaveClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;

            MemoryStream StatStream = model.GetStatStream();

            if (StatStream != null)
            {
                SaveFileDialog fileDialog = new SaveFileDialog() { Title = "Сохранение статистики" };
                fileDialog.Filters.Add(new FileDialogFilter() { Name = "PDF files", Extensions = { "pdf" } });
                var result = await fileDialog.ShowAsync(this);

                if (result != null)
                {
                    using (FileStream file = new FileStream(result, FileMode.Create))
                    {
                        file.Write(StatStream.GetBuffer());
                    }
                }
            }
        }

        /// <summary>
        /// Handling the event of changed selection period
        /// </summary>
        private void OnPeriodChanged(object sender, SelectionChangedEventArgs e)
        {
            //StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            //if (model.PeriodMode == Models.StatisticsTimeMode.Year)
            //{
            //    this.
            //}
        }

        /// <summary>
        /// Handling the event of clicking the previous page button
        /// </summary>
        private void OnDecrementPage(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            model.DecrementPage();
            this.UpdateWindow();
        }

        /// <summary>
        /// Handling the event of page changes
        /// </summary>
        private void OnPageChanged(object sender, KeyEventArgs e)
        {
            this.UpdateWindow();
        }

        /// <summary>
        /// Handling the event of clicking the next page button
        /// </summary>
        private void OnIncrementPage(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            model.IncrementPage();
            this.UpdateWindow();
        }
    }
}
