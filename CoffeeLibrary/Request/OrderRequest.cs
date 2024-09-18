using CoffeeLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace CoffeeLibrary.Request
{
    public class OrderRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Order>> GetOrdersAsync()
        {
            string url = Constant.API_URL + "/order";
            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<Order>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Order> orders = dataArray?.ToObject<List<Order>>() ?? new List<Order>();

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
