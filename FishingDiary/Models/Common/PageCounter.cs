// 22.11.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{

    public class PageCounter
    {
        private uint _TotalElements = 0;
        private uint _ElementsPerPage = 1;
        private uint _CurrentPage = 1;
        private uint _TotalPages = 1;
        private uint _StartElement = 0;
        private uint _EndElement = 0;

        private uint ElementsPerPage => (_ElementsPerPage == 0 ? _TotalElements : _ElementsPerPage);


        public uint TotalElements => _TotalElements;
        public uint CurrentElements => _EndElement - _StartElement + 1;
        public uint StartElement => _StartElement;
        public uint EndElement => _EndElement;
        public uint CurrentPage => _CurrentPage;
        public uint TotalPages => _TotalPages;
        public uint PerPageElements => _ElementsPerPage;
        public bool FirstPage => CurrentPage == 1;
        public bool EndPage => CurrentPage == TotalPages;

        public PageCounter(uint totalElements, uint elementsPerPage) 
        {
            _TotalElements = totalElements;
            _ElementsPerPage = elementsPerPage;

            if (TotalElements > 0)
            {
                _StartElement = 1;
                if (ElementsPerPage > TotalElements)
                {
                    _TotalPages = 1;
                    _EndElement = TotalElements;
                }
                else
                {
                    _TotalPages = TotalElements / ElementsPerPage + 1;
                    if (TotalElements % ElementsPerPage == 0)
                    {
                        _TotalPages--;
                    }
                    _EndElement = ElementsPerPage;
                }
            }
        }

        public void AddElement()
        {
            _TotalElements++;
            _TotalPages = TotalElements / ElementsPerPage + 1;
            if (TotalElements % ElementsPerPage == 0)
            {
                _TotalPages--;
            }

            if (CurrentPage == TotalPages)
            {
                _EndElement = TotalElements;
            }
        }

        public bool DeleteElement()
        {
            if (TotalElements > 0)
            {
                _TotalElements--;
                _TotalPages = TotalElements / ElementsPerPage + 1;
                if (TotalElements % ElementsPerPage == 0)
                {
                    _TotalPages--;
                }
                if (CurrentPage > TotalPages) 
                {
                    _CurrentPage = TotalPages;
                    _StartElement = (CurrentPage - 1) * ElementsPerPage + 1;
                }
                if (_CurrentPage == TotalPages)
                {
                    _EndElement = TotalElements;
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IncrementPage()
        {
            if (CurrentPage < TotalPages)
            {
                _StartElement = CurrentPage * ElementsPerPage + 1;
                _CurrentPage++;
                if (CurrentPage == TotalPages)
                {
                    _EndElement = TotalElements;
                }
                else
                {
                    _EndElement = CurrentPage * ElementsPerPage;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetPage(uint page)
        {
            if (page < 0 || page > TotalPages)
            {
                return false;
            }
            else
            {
                _CurrentPage = page;
                _StartElement = (CurrentPage - 1) * ElementsPerPage + 1;
                if (CurrentPage == TotalPages)
                {
                    _EndElement = TotalElements;
                }
                else
                {
                    _EndElement = CurrentPage * ElementsPerPage;
                }

                return true;
            }

        }

        public bool DecrementPage()
        {
            if (CurrentPage > 1)
            {
                _CurrentPage--;
                _StartElement = (CurrentPage - 1) * ElementsPerPage + 1;
                _EndElement = CurrentPage * ElementsPerPage;

                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
