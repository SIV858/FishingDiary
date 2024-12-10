//31.01.24

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Avalonia.Interactivity;
using Avalonia.Controls.Utils;
using FishingDiary.ViewModels;
using System;

namespace FishingDiary.Views
{
    public partial class EditorWindow : Window
    {

        public EditorWindow()
        {
            InitializeComponent();

            //DataGrid dataGrid = new DataGrid();
            //DataGridTextColumn dataGridColumn = new DataGridTextColumn();
            //dataGridColumn.Header = "qwe";

            //dataGridColumn.
            //dataGrid.Columns.Add(dataGridColumn);

            //dataGrid.e
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
            EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;

            AddParamWindow addParamWindow = new AddParamWindow()
            {
                DataContext = new AddParamWindowViewModel(model.SelectedItem),
            };
            addParamWindow.ShowDialog(this);
        }

        /// <summary>
        /// Handling the event of clicking the "Apply" button
        /// </summary>
        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;
                model.SaveTables();
                this.Close();
            }
            catch (Exception ex)
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
