using EStoreApp.Models;
using EStoreApp.Services;
using EStoreApp.Utlities;
using EStoreApp.Views;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EStoreApp.ViewModels
{
   public class LoginViewModel:BaseViewModel
    {
        private readonly LoginApi _loginapi = new LoginApi();
        private bool _Isbusy;

        public  bool Isbusy
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
        public clsResponse response1 = new clsResponse();
        private readonly INavigation navigation;

        public LoginViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public ICommand NavigateToSignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new RegisterPage());

                });
            }
        }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {


                    Isbusy = true;
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        response1 = await _loginapi.LoginUserAsync(Username, Password);
                        Isbusy = false;
                      //  await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        if (response1.Status)
                        {
                            try
                            {

                                await Utilty.SetSecureStorageValue(Utilty.UserName, Username);
                                await Utilty.SetSecureStorageValue(Utilty.Password, Password);
                            }
                            catch (Exception ex)
                            {
                                // Possible that device doesn't support secure storage on device.
                            }

                             //Isbusy = false;
                            Application.Current.MainPage = new NavigationPage(new BarcodePage());
                            //await Application.Current.MainPage.DisplayAlert("Alert", jObject.GetValue("message").ToString(), "OK");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Please Connect with Internet.", "ok");
                        Isbusy = false;

                    }
                });
            }
        }
    }
}
