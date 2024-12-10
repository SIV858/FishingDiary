//31.01.24

using System.Collections.ObjectModel;
using System.Data;
using FishingDiary.Models;
using ReactiveUI;

namespace FishingDiary.ViewModels
{


    public class EditorWindowViewModel : ViewModelBase
    {
        private DataTables _dateTables;



        public double dFontSize => Properties.GetInstance().FontSize;
        public string txtHead => CommonData.GenLanguages.EditorTexts.sHead;

        public string txtAddButton => CommonData.GenLanguages.CommonTexts.sButtonAdd;
        public string txtApplyButton => CommonData.GenLanguages.CommonTexts.sButtonApply;
        public string txtCancelButton => CommonData.GenLanguages.CommonTexts.sButtonCancel;


        private EditTable _currentDataTable;
        public EditTable SelectedItem
        {
            get => _currentDataTable;
            set => this.RaiseAndSetIfChanged(ref _currentDataTable, value);
        }


        public ObservableCollection<EditTable> EditTables => _dateTables.Tables;

        public EditorWindowViewModel()
        {
            _dateTables = new DataTables();
            _dateTables.ReadTables();
        }

        public void SaveTables()
        {
            _dateTables.WriteTables();
        }

    }
}
