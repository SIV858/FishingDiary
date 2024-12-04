//28.11.24
using Avalonia.Controls;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handling the event of clicking the "Paint" button
        /// </summary>
        private void OnPaintClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            model.PaintStat();
        }


        /// <summary>
        /// Handling the event of clicking the "Save" button
        /// </summary>
        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            StatisticsWindowViewModel model = (StatisticsWindowViewModel)this.DataContext;
            model.SaveStat();
        }
    }
}
