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
    /// <summary>
    /// Adding or editing parameters
    /// </summary>
    internal class AddParamWindowViewModel : ViewModelBase
    {
        private EditTable _Table;

        private uint _AddedId;
        private bool _IsAdd;
        private bool _IsReadOnly;

        private string _txtHead;

        public string txtHead => _txtHead;

        public string txtOKButton => CommonData.GenLanguages.CommonTexts.sButtonOk;
        public string txtCancelButton => CommonData.GenLanguages.CommonTexts.sButtonCancel;

        public double dFontSize => Properties.GetInstance().FontSize;

        public bool IsAdd => _IsAdd;
        public bool IsReadOnly => _IsReadOnly;

        public uint AddedId
        {
            get => _AddedId;
            set
            {
                this.RaiseAndSetIfChanged(ref _AddedId, value);
                foreach (ColumnTable columnTable in _Table.ListColumns)
                {
                    columnTable.CurrentId = value;
                }
            }

        }

        public ObservableCollection<ColumnTable> ListColumns
        {
            get => _Table.ListColumns;
            set => this.RaiseAndSetIfChanged(ref _Table._listColumns, value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Table">Table for editing/adding</param>
        /// <param name="IsAdd">Window for editing or adding</param>
        public AddParamWindowViewModel(EditTable Table, bool IsAdd)
        {
            _Table = Table;
            _IsAdd = IsAdd;
            if (_IsAdd)
            {
                _txtHead = CommonData.GenLanguages.AddParamTexts.sHeadAdd + _Table.TableName;
                _IsReadOnly = false;

                //text cleaning and ID
                AddedId = 0;
                foreach (ColumnTable columnTable in _Table.ListColumns)
                {
                    columnTable.CurrentText = "";
                }
            }
            else
            {
                // Checking the first element
                if (Table.ColumnTableSelect.SelectedIndex != -1)
                {
                    if (Table.ColumnTableSelect.SelectedIndex == 0)
                    {
                        throw new Exception(CommonData.GenLanguages.ErrorTexts.sNullIdEdit);
                    }
                }
                else
                {
                    throw new Exception(CommonData.GenLanguages.ErrorTexts.sNoItemSelected);
                }

                // filling in the fields
                _AddedId = Table.ColumnTableSelect.CurrentId;
                foreach (ColumnTable columnTable in _Table.ListColumns)
                {
                    columnTable.SelectedIndex = Table.ColumnTableSelect.SelectedIndex;
                }

                _txtHead = CommonData.GenLanguages.AddParamTexts.sHeadEdit + _Table.TableName;
                _IsReadOnly = true;
            }
        }

        public void AddParam()
        {
            foreach (ColumnTable columnTable in _Table.ListColumns)
            {
                columnTable.AddCurrentElement();
            }
        }

        public void EditParam()
        {
            foreach (ColumnTable columnTable in _Table.ListColumns)
            {
                columnTable.EditCurrentElement();
            }
        }
    }
}
