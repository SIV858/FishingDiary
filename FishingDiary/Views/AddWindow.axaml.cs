//19.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;
using FishingDiary.Models;
using System.IO;
using System;
using System.Text;

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
        /// Handling the event of clicking the "Load" button
        /// </summary>
        private async void OnLoadClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { 
                Title = CommonData.GenLanguages.AddReport.sHeadLoadWindow,
                AllowMultiple = false
            };
            fileDialog.Filters.Add(new FileDialogFilter() { Name = "txt files", Extensions = { "txt" } });
            var result = await fileDialog.ShowAsync(this);

            string sData = String.Empty;

            if (result.Length > 0)
            {
                using (FileStream file = new FileStream(result[0], FileMode.Open))
                {
                    byte[] data = new byte[file.Length];
                    file.Read(data, 0, (int)file.Length);
                    Encoding encoding =  Encoding.GetEncoding(1251);
                    sData = encoding.GetString(data);
                }
                AddWindowViewModel model = (AddWindowViewModel)this.DataContext;
                model.LoadReport(sData, Path.GetDirectoryName(Path.GetDirectoryName(result[0])));
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
