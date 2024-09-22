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

        public async Task<Order> CreateOrderAsync(CreateOrder createOrderInfo)
        {
            string url = Constant.API_URL + "/order";

            var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(createOrderInfo),
                    Encoding.UTF8,
                    "application/json"
                );
            var response = await client.PostAsync(url, jsonContent);
                

            if (response == null)
            {
                return null;
            }

            try
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                Order order = jsonResponse["data"].ToObject<Order>();

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
