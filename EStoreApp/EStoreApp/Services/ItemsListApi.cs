using EStoreApp.Models;
using EStoreApp.Utlities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Services
{
    class ItemsListApi
    {
        public async Task<List<clsItem>> GetListofItems()
        {
            List<clsItem> getresponse = new List<clsItem>();
            var Httpclient = new HttpClient();

            var url = Constants.BaseApiAddress + "myapi/getallitems";

            var uri = new Uri(string.Format(url, string.Empty));

            HttpResponseMessage response = null;

            response = await Httpclient.GetAsync(uri);


            if (response.StatusCode == HttpStatusCode.OK)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(responseContent);
                JArray loi = (JArray)jObject.GetValue("itemList");
                getresponse = loi.ToObject<List<clsItem>>();

            }
            return getresponse;

        }
    }
}
