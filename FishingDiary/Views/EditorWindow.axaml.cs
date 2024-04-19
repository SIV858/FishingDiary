//31.01.24

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using Avalonia.Interactivity;
using Avalonia.Controls.Utils;

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
    }
}
