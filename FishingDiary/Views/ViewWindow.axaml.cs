//07.02.24

using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using FishingDiary.Models;
using static FishingDiary.MessageBox;
using System.Threading.Tasks;

namespace FishingDiary.Views
{
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
        }

        public void UpdateWindow()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Edit" button
        /// </summary>
        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            Button currentBunnon = (Button)sender;
            ShortReport currentReport = (ShortReport)currentBunnon.DataContext;
            EditWindow editWindow = new EditWindow()
            {
                DataContext = new EditWindowViewModel(currentReport.ReportId),
            };
            editWindow.ShowDialog(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Delete" button
        /// </summary>
        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            var task = MessageBox.Show(this, CommonData.GenLanguages.ViewWindow.sWarnDeletion,
                CommonData.GenLanguages.CommonTexts.sProgramName, MessageBox.MessageBoxButtons.YesNo);

            Button currentBunnon = (Button)sender;
            ShortReport currentReport = (ShortReport)currentBunnon.DataContext;

            Task.Run(() =>
            {
                if (task.Result == MessageBoxResult.Yes)
                {
                    try
                    {
                        ShortReportsList.DeleteReport(currentReport);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                    }
                }
            });

            this.UpdateWindow();

        }
    }
}
