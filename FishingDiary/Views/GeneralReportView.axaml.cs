//03.01.24
using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FishingDiary.ViewModels;
using System.Threading.Tasks;

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


        /// <summary>
        /// Handling the event of clicking the "Add photo" button
        /// </summary>
        private void OnAddPhoto(object sender, RoutedEventArgs e)
        {
            GeneralReportViewModel model = (GeneralReportViewModel)this.DataContext;

            OpenPhotoFile(model);
        }

        private async void OpenPhotoFile(GeneralReportViewModel model)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Solution";

            Window window = (Window)this.VisualRoot;

            openFileDialog.Filters.Add(new FileDialogFilter
            {
                Name = "Photo Files",
                Extensions = { "jpg" }
            });


            openFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            var result = await openFileDialog.ShowAsync(window);

            model.SetPhoto(result[0]);
        }
    }
}
