//09.12.24
using Avalonia.Controls;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using System;
using static FishingDiary.MessageBox;

namespace FishingDiary.Views
{
    public partial class AddParamWindow : Window
    {
        private MessageBoxResult _MessageBoxResult;

        public MessageBoxResult Result => _MessageBoxResult;

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
                if (model.IsAdd)
                {
                    model.AddParam();
                }
                else
                {
                    model.EditParam();
                }
                _MessageBoxResult = MessageBoxResult.Ok;
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
            _MessageBoxResult = MessageBoxResult.Cancel;
            this.Close();
        }
    }
}
