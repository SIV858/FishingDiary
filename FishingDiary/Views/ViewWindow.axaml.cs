//07.02.24

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using FishingDiary.ViewModels;

namespace FishingDiary.Views
{
    public partial class ViewWindow : Window
    {
        public ViewWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
