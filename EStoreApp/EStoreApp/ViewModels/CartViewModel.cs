using EStoreApp.Models;
using EStoreApp.Services;
using EStoreApp.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EStoreApp.ViewModels
{
    class CartViewModel:BaseViewModel
    {
        private bool _Isbusy;

        public bool Isbusy
        {
            get
            {
                return _Isbusy;
            }
            set
            {
                _Isbusy = value;
                if (_Isbusy)
                {
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushPopupAsync(new IndicatorActity());

                }
                else
                {
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PopPopupAsync();

                }

                OnPropertyChanged();
            }
        }
        public TBillCount total { get; set; }
        public ObservableCollection<clsInvoice> _Items { get; set; }
        public ObservableCollection<clsInvoice> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged();


            }
        }
        private readonly InvoiceApi _InvoiceApi;
        public ObservableCollection<clsInvoice> CartItems { get; set; } = new ObservableCollection<clsInvoice>();

        public INavigation navigation1;
        public CartViewModel(INavigation navigation, ObservableCollection<clsInvoice> items, TBillCount tbill)
        {
            total = new TBillCount();
            this.Items = items;
            _InvoiceApi = new InvoiceApi();
            this.total = tbill;
            this.navigation1 = navigation;


        }
        public Command<clsInvoice> RemoveItem
        {
            get
            {
                return new Command<clsInvoice>((clsInvoice product) =>
                {
                    Items.Remove(product);
                    total.TBill = total.TBill - product.SRate;
                    total.TCount--;
                });
            }
        }
        public Command<clsInvoice> IncreaseQtyCommand
        {

            get
            {

                return new Command<clsInvoice>((clsInvoice product) =>
                {
                    product.Quantity2 += 1;
                    product.LineGrossValue = product.Quantity2 * product.FRate;
                    total.TBill = total.TBill + product.FRate;
                    product.SRate = product.FRate * product.Quantity2;
                });
            }
        }
        public Command<clsInvoice> DecreaseQtyCommand
        {

            get
            {
                return new Command<clsInvoice>((clsInvoice product) =>
                {

                    product.Quantity2 -= 1;
                    if (product.Quantity2 == 1)
                    {
                        product.SRate = product.FRate;
                        total.TBill = Items.Sum(s => s.SRate);
                        //TBill = TBill - product.FRate;

                    }
                    else
                    {
                        // TBill = TBill - product.FRate;

                        product.LineGrossValue = product.SRate - product.FRate;
                        product.SRate = product.SRate - product.FRate;
                        total.TBill = Items.Sum(s => s.SRate);
                        // product.TotalAmount += product.LineGrossValue;
                    }

                });
            }
        }
        public Command PlaceOrder
        {
            get
            {
                return new Command(async () =>
                {
                    clsInvoice list = new clsInvoice();
                    list.TotalAmount = total.TBill;
                    list.SaleLineList = Items.ToList();
                    Isbusy = true;
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        var res = await _InvoiceApi.PlaceOrder(list);
                        Isbusy = false;
                        if (res.Status)
                        {
                            Xamarin.Forms.Application.Current.MainPage = new Xamarin.Forms.NavigationPage(new OrderAcceptedPage(res.OrderNumber));
                        }
                    }
                    else
                    {
                        await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                        Isbusy = false;
                    }
                });
            }
        }
    }
}
