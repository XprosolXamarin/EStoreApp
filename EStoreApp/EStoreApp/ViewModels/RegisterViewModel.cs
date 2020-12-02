using EStoreApp.Models;
using EStoreApp.Services;
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
    class RegisterViewModel : BaseViewModel
    {
        private INavigation navigation;

        public RegisterViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        private readonly RegisterApi _registerapi = new RegisterApi();

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
        public clsResponse response1 = new clsResponse();
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand NavigateToSigninCommand
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());

                });
            }
        }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {


                    Isbusy = true;
                    var current = Connectivity.NetworkAccess;

                    if (current == NetworkAccess.Internet)
                    {
                        response1 = await _registerapi.RegisterUserAsync(Username, Password);
                        Isbusy = false;
                        //  await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        if (response1.Status)
                        {
                            try
                            {
                                await SecureStorage.SetAsync("tokenp", Password);
                                await SecureStorage.SetAsync("tokenn", Username);
                            }
                            catch (Exception ex)
                            {
                                // Possible that device doesn't support secure storage on device.
                            }

                            // Isbusy = false;
                            Application.Current.MainPage = new NavigationPage(new BarcodePage());
                            //await Application.Current.MainPage.DisplayAlert("Alert", jObject.GetValue("message").ToString(), "OK");
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Alert", response1.Message, "ok");
                        }
                        // await Application.Current.MainPage.Navigation.PushPopupAsync(new IndicatorActity());
                        // await RegisterUserAsync(Username, Password);
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
