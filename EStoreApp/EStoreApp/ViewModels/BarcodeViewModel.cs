using EStoreApp.Models;
using EStoreApp.Services;
using EStoreApp.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZXing;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EStoreApp.ViewModels
{
    class BarcodeViewModel:BaseViewModel
    {
        private INavigation navigation;

        public BarcodeViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            IsVisisble = false;
            Total = new TBillCount();
            Total.TCount = 0;
            Total.TBill = 0;
            Items = new ObservableCollection<clsInvoice>();


            _itemlistapi = new ItemsListApi();
            
           _= GetListOfItemsAsync();
        }
        private bool _IsVisisble;

        public bool IsVisisble
        {
            get
            {
                return _IsVisisble;
            }
            set
            {
                _IsVisisble = value;


                OnPropertyChanged();
            }
        }
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
                    navigation.PushPopupAsync(new IndicatorActity());

                }
                else
                {
                    navigation.PopPopupAsync();

                }

                OnPropertyChanged();
            }
        }
        public TBillCount Total { get; set; }
        private List<clsItem> _lst { get; set; }

        public List<clsItem> lst
        {
            get { return _lst; }
            set
            {
                _lst = value;

                OnPropertyChanged();
            }
        }
        private readonly ItemsListApi _itemlistapi;
        public ObservableCollection<clsInvoice> Items { get; set; }
        public clsInvoice Invoice = new clsInvoice();
        private async Task GetListOfItemsAsync()
        {
            Isbusy = true;
            lst = new List<clsItem>();
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                lst = await _itemlistapi.GetListofItems();
                Isbusy = false;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                Isbusy = false;
            }
        }
        public Command<Result> AddProductCommand
        {

            get
            {
                return new Command<Result>(async (Result result) =>
                {
                   
                    var duration = TimeSpan.FromSeconds(0.1);
                    Vibration.Vibrate(duration);

                    var res = result.Text;
                    bool chk = Items.Where(c => c.Barcode == res).Any(c => c.Barcode == res);
                    if (!chk)
                    {

                        bool chk1 = lst.Where(c => c.Barcode == res).Any(c => c.Barcode == res);
                        if (!chk1)
                        {
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                await Application.Current.MainPage.DisplayAlert("Alert", "Item does not Exist!", "Ok");
                            });
                            
                        }
                        else
                        {
                            var g = await SecureStorage.GetAsync("UserId");
                            int m = Convert.ToInt32(g);

                            var ite = (from c in lst
                                       where c.Barcode == res
                                       select new clsInvoice
                                       {
                                           AccountId = m,
                                           Barcode = c.Barcode,
                                           ItemName = c.ItemName,
                                           // CategoryName = c.CategoryName,
                                           Rate = c.CostPrice,
                                           FRate = c.CostPrice,
                                           SRate = c.CostPrice,
                                           Quantity2 = 1,
                                           LineDiscRate = 0,
                                           WarehouseId = 5009,
                                           LineGrossValue = c.CostPrice,
                                           ImagePath = c.ImagePath,
                                           LineNetAmount = c.CostPrice,
                                           ItemId = c.ItemId,
                                           Quantity1 = 1,
                                       }).FirstOrDefault();
                            Total.TBill = Total.TBill + ite.FRate;
                            Total.TCount++;
                            Items.Add(ite);
                            IsVisisble = true;
                        }
                    }
                    else
                    {
                        var abc = Items.Where(c => c.Barcode == res).FirstOrDefault();
                        abc.Quantity2++;
                        abc.SRate = abc.FRate * abc.Quantity2;
                        abc.LineGrossValue = abc.FRate * abc.Quantity2;
                        Total.TBill = Total.TBill + abc.FRate;
                    }
                });
            }
        }
        public Command<clsInvoice> RemoveItem
        {
            get
            {
                return new Command<clsInvoice>((clsInvoice product) =>
                {
                    Items.Remove(product);
                    Total.TBill = Total.TBill - product.SRate;
                    Total.TCount--;
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

                    product.SRate = product.FRate * product.Quantity2;
                    Total.TBill = Items.Sum(s => s.SRate);
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
                        Total.TBill = Items.Sum(s => s.SRate);
                    }
                    else
                    {
                        Total.TBill = Total.TBill - product.FRate;

                        product.LineGrossValue = product.SRate - product.FRate;
                        product.SRate = product.SRate - product.FRate;
                        Total.TBill = Items.Sum(s => s.SRate);
                    }
                });
            }
        }
        public Command ViewCart
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new CartViewPage(Items, Total));
                });
            }
        }
    }
}
