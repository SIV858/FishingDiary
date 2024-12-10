//09.12.24
using Avalonia.Controls;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using System;

namespace FishingDiary.Views
{
    public partial class AddParamWindow : Window
    {
        public AddParamWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handling the event of clicking the "OK" button
        /// </summary>
        private void OnOKClick(object sender, RoutedEventArgs e)
        {
            try
            {
                AddParamWindowViewModel model = (AddParamWindowViewModel)this.DataContext;
                model.AddParam();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
            }
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
