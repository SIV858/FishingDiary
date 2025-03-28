//31.01.24

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Avalonia.Interactivity;
using Avalonia.Controls.Utils;
using FishingDiary.ViewModels;
using System;
using FishingDiary.Models;
using static FishingDiary.MessageBox;
using System.Threading.Tasks;
using Avalonia.Threading;
using Avalonia.Media.Imaging;

namespace FishingDiary.Views
{
    public partial class EditorWindow : Window
    {

        public EditorWindow()
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

        // When closing the window for adding/editing a parameter, we update this window
        private void AddParamWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;
            model.IsEnabledApply = model.IsEnabledApply | ((AddParamWindow)sender).Result == MessageBox.MessageBoxResult.Ok;

            if (((AddParamWindow)sender).Result == MessageBox.MessageBoxResult.Ok)
                this.UpdateWindow();
        }


        /// <summary>
        /// Handling the event of clicking the "Add row" button
        /// </summary>
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;

            try
            {
                AddParamWindow addParamWindow = new AddParamWindow()
                {
                    DataContext = new AddParamWindowViewModel(model.SelectedTab, true),
                };
                addParamWindow.Unloaded += AddParamWindow_Unloaded;
                addParamWindow.ShowDialog(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
            }

        }

        /// <summary>
        /// Handling the event of clicking the "Edit row" button
        /// </summary>
        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;

            try
            {
                AddParamWindow addParamWindow = new AddParamWindow()
                {
                    DataContext = new AddParamWindowViewModel(model.SelectedTab, false),
                };
                addParamWindow.Unloaded += AddParamWindow_Unloaded;
                addParamWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
            }
        }
        /// <summary>
        /// Handling the event of clicking the "Delete row" button
        /// </summary>
        private async void OnDeleteClick(object sender, RoutedEventArgs e)
        {
            EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;
            if (model.CheckDelItem())
            {
                var result = await MessageBox.Show(this, CommonData.GenLanguages.EditorTexts.sWarnDeletion,
                    CommonData.GenLanguages.CommonTexts.sProgramName, MessageBox.MessageBoxButtons.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    model.DeleteItem();
                    this.UpdateWindow();
                }
            }
            else
            {
                await MessageBox.Show(this, CommonData.GenLanguages.ErrorTexts.sNoItemSelected,
                    CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
            }
        }

        /// <summary>
        /// Handling the event of clicking the "Ok" button
        /// </summary>
        private void OnOkClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;
                if (model.IsEnabledApply)
                {
                    model.SaveTables();
                    CommonData.EditableTexts.Parse();
                }
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

        /// <summary>
        /// Handling the event of clicking the "Apply" button
        /// </summary>
        private void OnApplyClick(object sender, RoutedEventArgs e)
        {
            try
            {
                EditorWindowViewModel model = (EditorWindowViewModel)this.DataContext;
                model.SaveTables();
                model.IsEnabledApply = false;
                CommonData.EditableTexts.Parse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
            }
        }
    }
}
