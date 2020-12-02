using EStoreApp.Models;
using EStoreApp.Utlities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EStoreApp.Services
{
    class RegisterApi
    {
        public async Task<clsResponse> RegisterUserAsync(string username, string password)
        {
            var response1 = new clsResponse
            {
                Message = "",
                Status = false
            };

            bool status = false;
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "myapi/insertupdatecustomeraccount";

            var uri = new Uri(string.Format(url, string.Empty));

            var user = new clsAccount
            {
                Username = username,
                Password = password,
                // ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);


            if (response.StatusCode == HttpStatusCode.OK)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseContent);
                //Isbusy = false;
                status = (bool)jObject.GetValue("status");

                //await Application.Current.MainPage.DisplayAlert("Alert", jObject.GetValue("message").ToString(), "OK");

                try
                {
                    await SecureStorage.SetAsync("tokenp", "password");
                    await SecureStorage.SetAsync("tokenn", "username");
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
                response1 = new clsResponse
                {

                    Message = jObject.GetValue("message").ToString(),
                    Status = status
                };
                //if (status)
                //{
                //    Isbusy = false;
                //    Application.Current.MainPage = new NavigationPage(new orderApp.Views.LoginPage());
                //    await Application.Current.MainPage.DisplayAlert("Alert", jObject.GetValue("message").ToString(), "OK");
                //}

            }
            else
            {
                //IsBusy = false;
            }
            return response1;
        }
    }
}
