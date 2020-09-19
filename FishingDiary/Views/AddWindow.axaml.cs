//19.09.20
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FishingDiary.Views
{
    public class AddWindow : Window
    {
        public AddWindow()
        {
            this.InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
