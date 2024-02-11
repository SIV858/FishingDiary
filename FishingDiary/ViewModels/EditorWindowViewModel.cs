//31.01.24

using System.Collections.ObjectModel;

using FishingDiary.Models;

namespace FishingDiary.ViewModels
{


    public class EditorWindowViewModel : ViewModelBase
    {
        private DataTables _dateTables;

        public string txtHead => CommonData.GenLanguages.EditorTexts.sHead;
        public ObservableCollection<EditTable> EditTables => _dateTables.Tables;

        public EditorWindowViewModel()
        {
            _dateTables = new DataTables();
            _dateTables.ReadTables();
        }

    }
}
