//07.02.24

using System.Collections.Generic;
using System.Collections.ObjectModel;

using FishingDiary.Models;
using ReactiveUI;

namespace FishingDiary.ViewModels
{
    public class ViewWindowViewModel : ViewModelBase
    {
        public ViewWindowViewModel()
        {
        }

        public string txtHead => CommonData.GenLanguages.ViewWindow.sHead;

        public ObservableCollection<ShortReport> Reports => ShortReportsList.ListReports;
    }
}
