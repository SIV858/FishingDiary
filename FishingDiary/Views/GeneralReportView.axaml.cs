//03.01.24
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FishingDiary.Views
{
    public partial class GeneralReportView : UserControl
    {
        public GeneralReportView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
