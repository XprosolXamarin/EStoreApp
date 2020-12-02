using Android.App;
using EStoreApp.Models;
using EStoreApp.Utlities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Services
{
    class InvoiceApi
    {
      
        internal async Task<clsitemresponse> PlaceOrder(clsInvoice items)
        {
            clsitemresponse response1 = new clsitemresponse();
          
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "myapi/insertupdatesaleorder";

            var uri = new Uri(string.Format(url, string.Empty));

            var json = JsonConvert.SerializeObject(items);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await Httpclient.PostAsync(uri, content);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var jObject = JObject.Parse(responseContent);



                response1 = new clsitemresponse
                {
                    Status = (bool)jObject.GetValue("Status"),

                    Message = jObject.GetValue("Message").ToString(),
                    OrderNumber = jObject.GetValue("orderNumber").ToString(),

                };
               


            }
           
             return response1;
        }

    }
}

