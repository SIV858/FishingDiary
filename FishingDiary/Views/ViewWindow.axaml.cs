//07.02.24

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using FishingDiary.Models;

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
    }
}
