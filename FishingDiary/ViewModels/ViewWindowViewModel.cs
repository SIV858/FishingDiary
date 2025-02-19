//07.02.24

using System.Collections.Generic;
using System.Collections.ObjectModel;

using FishingDiary.Models;
using ReactiveUI;

namespace FishingDiary.ViewModels
{
    public class ViewWindowViewModel : ViewModelBase
    {
        public string txtHead => CommonData.GenLanguages.ViewWindow.sHead;

        public double dFontSize => Properties.GetInstance().FontSize;

        public bool IsEnabledPrev => !ShortReportsList.FirstPage;
        public bool IsEnabledNext => !ShortReportsList.EndPage;

        public uint CurrentPage
        {
            get => ShortReportsList.CurrentPage;
            set
            {
                uint Value = 0;
                this.RaiseAndSetIfChanged(ref Value, value);
                ShortReportsList.SetPage(Value);
            }

        }

        public string txtPageInfo
        {
            get => ShortReportsList.StartElement.ToString() + "-" 
                + ShortReportsList.EndElement.ToString() + " " 
                + CommonData.GenLanguages.CommonTexts.sFrom + " " 
                + ShortReportsList.Count;
        }


        public ObservableCollection<ShortReport> Reports => ShortReportsList.ListReports;

        public ViewWindowViewModel()
        {
        }

        public void IncrementPage()
        {
            ShortReportsList.IncrementPage();
        }

        public void DecrementPage()
        {
            ShortReportsList.DecrementPage();
        }


    }
}
