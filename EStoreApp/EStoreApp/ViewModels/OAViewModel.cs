using EStoreApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EStoreApp.ViewModels
{
    class OAViewModel:BaseViewModel
    {
        private string _orderNumber;
        public string orderNumber
        {
            get { return _orderNumber; }
            set
            {
                _orderNumber = value;

                OnPropertyChanged();
            }
        }
        public OAViewModel(string orderNumber)
        {
            this.orderNumber = orderNumber;
        }
        public Command NavigateBarcodePage
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new BarcodePage());

                });
            }
        }
    }
}
