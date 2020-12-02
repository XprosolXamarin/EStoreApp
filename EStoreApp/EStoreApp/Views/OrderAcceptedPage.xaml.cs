using EStoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EStoreApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderAcceptedPage : ContentPage
    {
        public OrderAcceptedPage(string orderNumber)
        {
            InitializeComponent();
            BindingContext = new OAViewModel(orderNumber);
        }
    }
}