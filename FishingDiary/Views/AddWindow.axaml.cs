//19.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using FishingDiary.Models;

namespace FishingDiary.Views
{
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
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
            AddWindowViewModel model = (AddWindowViewModel)this.DataContext;
            if (!model.AddCurrentReport())
            {
                MessageBox.Show(this, CommonData.GenLanguages.ErrorTexts.sNullNameWater, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                return;
            }
            Properties.GetInstance().SaveProperties();

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
