
using EStoreApp.Models;
using EStoreApp.Services;
using EStoreApp.Utlities;
using EStoreApp.Views;
using System;
using Xamarin.Forms;

namespace EStoreApp.ViewModels
{
   public class SplashViewModel
    {
        public clsResponse response1 = new clsResponse();
        public readonly LoginApi api = new LoginApi();
        public SplashViewModel()
        {
            LoginExist();
        }

        public async void LoginExist()
        {

            try
            {
                var username = Utilty.GetSecureStorageValueFor(Utilty.UserName);
                var password = Utilty.GetSecureStorageValueFor(Utilty.Password);
                 response1 = await api.LoginUserAsync(username.Result, password.Result);
                if (response1.Status)
                {
                     Application.Current.MainPage = new NavigationPage(new BarcodePage());
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

        }
    }
}

