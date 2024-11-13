using CoffeeLibrary.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Request
{
    public class StoreRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Store>> GetStoresAsync()
        {
            string url = Constant.API_URL + "/store";

            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return null;
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Store> stores = dataArray?.ToObject<List<Store>>() ?? new List<Store>();

                return stores;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
