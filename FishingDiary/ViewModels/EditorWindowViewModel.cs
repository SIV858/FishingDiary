//31.01.24

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using FishingDiary.Models;
using ReactiveUI;

namespace FishingDiary.ViewModels
{


    public class EditorWindowViewModel : ViewModelBase
    {
        private DataTables _dateTables;
        private bool _IsEnabledApply = false;


        public double dFontSize => Properties.GetInstance().FontSize;
        public string txtHead => CommonData.GenLanguages.EditorTexts.sHead;

        public string txtAddButton => CommonData.GenLanguages.CommonTexts.sButtonAddRow;
        public string txtEditButton => CommonData.GenLanguages.CommonTexts.sButtonEditRow;
        public string txtDeleteButton => CommonData.GenLanguages.CommonTexts.sButtonDeleteRow;

        public string txtOkButton => CommonData.GenLanguages.CommonTexts.sButtonOk;
        public string txtCancelButton => CommonData.GenLanguages.CommonTexts.sButtonCancel;
        public string txtApplyButton => CommonData.GenLanguages.CommonTexts.sButtonApply;

        public bool IsEnabledApply
        {
            get => _IsEnabledApply;
            set => this.RaiseAndSetIfChanged(ref _IsEnabledApply, value);
        }


        private EditTable _currentDataTable;
        public EditTable SelectedTab
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


        public bool CheckDelItem()
        {
            if (SelectedTab.ColumnTableSelect.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteItem()
        {
            _currentDataTable.ColumnTableSelect.DeleteCurrentElement();
        }

        public void SaveTables()
        {
            _dateTables.WriteTables();
        }

    }
}
