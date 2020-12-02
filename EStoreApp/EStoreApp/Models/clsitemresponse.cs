using EStoreApp.Models;
using EStoreApp.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreApp.Models
{
    public class clsitemresponse:BaseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public List<clsItem> _ItemList { get; set; }
       
        public List<clsItem> ItemList
        {
            get { return _ItemList; }
            set
            {
                _ItemList = value;

                OnPropertyChanged();
            }
        }
        private string _OrderNumber { get; set; }

        public string OrderNumber
        {
            get { return _OrderNumber; }
            set
            {
                _OrderNumber = value;

                OnPropertyChanged();
            }
        } 
    }
   

}
