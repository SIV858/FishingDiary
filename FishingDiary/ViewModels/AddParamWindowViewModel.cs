//09.12.24;
using FishingDiary.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FishingDiary.ViewModels
{
    internal class AddParamWindowViewModel : ViewModelBase
    {
        private EditTable _Table;

        private uint _AddedId;

        public string txtHead => CommonData.GenLanguages.AddParamTexts.sHead + _Table.TableName;

        public string txtOKButton => CommonData.GenLanguages.CommonTexts.sButtonOk;
        public string txtCancelButton => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        public double dFontSize => Properties.GetInstance().FontSize;


        public uint AddedId
        {
            get => _AddedId;
            set
            {
                this.RaiseAndSetIfChanged(ref _AddedId, value);
                foreach(ColumnTable columnTable in _Table.ListColumns)
                {
                    columnTable.AddedId = value;
                }
            }

        }

        public ObservableCollection<ColumnTable> ListColumns
        {
            get => _Table.ListColumns;
            set => this.RaiseAndSetIfChanged(ref _Table._listColumns, value);
        }


        public AddParamWindowViewModel(EditTable Table) 
        {
            _Table = Table;
        }

        public void AddParam()
        {
            foreach (ColumnTable columnTable in _Table.ListColumns)
            {
                columnTable.AddCurrentElement();
            }
        }
    }
}
