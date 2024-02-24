//03.01.24
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class GeneralReportView : UserControl
    {
        public GeneralReportView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Clear Methods" button
        /// </summary>
        private void OnClearMethodsClick(object sender, RoutedEventArgs e)
        {
            GeneralReportViewModel model = (GeneralReportViewModel)this.DataContext;
            model.ClearMethods();
        }

        /// <summary>
        /// Handling the event of clicking the "Clear FishingTackles" button
        /// </summary>
        private void OnClearTacklesClick(object sender, RoutedEventArgs e)
        {
            GeneralReportViewModel model = (GeneralReportViewModel)this.DataContext;
            model.ClearTackles();
        }

        /// <summary>
        /// Handling the event of clicking the "Clear Groundbaits" button
        /// </summary>
        private void OnClearGroundbaitsClick(object sender, RoutedEventArgs e)
        {
            GeneralReportViewModel model = (GeneralReportViewModel)this.DataContext;
            model.ClearGroundbaits();
        }

        /// <summary>
        /// Handling the event of clicking the "Clear Baits" button
        /// </summary>
        private void OnClearBaitsClick(object sender, RoutedEventArgs e)
        {
            GeneralReportViewModel model = (GeneralReportViewModel)this.DataContext;
            model.ClearBaits();
        }
    }
}
