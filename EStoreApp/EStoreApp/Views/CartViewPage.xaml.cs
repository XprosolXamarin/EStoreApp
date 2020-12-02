using EStoreApp.Models;
using EStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartViewPage : ContentPage
    {
        public CartViewPage(ObservableCollection<clsInvoice> items, TBillCount tbill)
        {
            InitializeComponent();
            BindingContext = new CartViewModel(Navigation, items, tbill);
        }
    }
}