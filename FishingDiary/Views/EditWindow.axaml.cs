//15.09.24

using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FishingDiary.Models;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Change" button
        /// </summary>
        private void OnChangeClick(object sender, RoutedEventArgs e)
        {
            EditWindowViewModel model = (EditWindowViewModel)this.DataContext;
            model.EditCurrentReport();
            Properties.GetInstance().SaveProperties();

            // Updating the owner window
            ViewWindow view = (ViewWindow)this.Owner;
            view.UpdateWindow();

            this.Close();
        }

        /// <summary>
        /// Handling the event of clicking the "Cancel" button
        /// </summary>
        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
