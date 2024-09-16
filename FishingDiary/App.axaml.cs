//10.09.20
using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FishingDiary.ViewModels;
using FishingDiary.Views;
using FishingDiary.Models;

namespace FishingDiary
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                try
                {
                    CommonData.GenLanguages = new GeneralLaguages();

                    // if a file exist then read it
                    CommonData.CurrentLang = new CurrentLanguage();

                    if (CommonData.CurrentLang.LoadCurrentLanguage())
                    {
                        // Load MainWindow
                        desktop.MainWindow = new MainWindow
                        {
                            DataContext = new MainWindowViewModel(),
                        };
                    }
                    // else create a form SelectLanguages
                    else
                    {
                        desktop.MainWindow = new SelectLanguageWindow
                        {
                            DataContext = new SelectLanguagesViewModel(),
                        };
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(null, ex.Message, CommonData.GenLanguages.ErrorTexts.sTextError, MessageBox.MessageBoxButtons.Ok);
                }
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
