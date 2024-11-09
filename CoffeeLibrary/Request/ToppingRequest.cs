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
    public class ToppingRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Topping>> GetToppingsAsync()
        {
            string url = Constant.API_URL + "/topping";
            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<Topping>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Topping> toppings = dataArray?.ToObject<List<Topping>>() ?? new List<Topping>();

                return toppings;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Topping> CreateToppingAsync(string topping_name, decimal topping_price)
        {

            try
            {
                string url = Constant.API_URL + "/topping";


                var jsonContent = new StringContent(
                                       Newtonsoft.Json.JsonConvert.SerializeObject(new Topping
                                       {
                                           topping_name = topping_name,
                                           topping_price = topping_price
                                       }),Encoding.UTF8,"application/json");

                var response = await client.PostAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(responseData);

                Topping topping = jsonResponse["data"].ToObject<Topping>();

                return topping;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateToppingAsync(int id, string topping_name, decimal topping_price)
        {
            try
            {
                string url = Constant.API_URL + "/topping/" + id;

                var jsonContent = new StringContent(
                                       Newtonsoft.Json.JsonConvert.SerializeObject(new Topping
                                       {
                                           topping_name = topping_name,
                                           topping_price = topping_price
                                       }), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, jsonContent);

                if (response == null || !response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteToppingAsync(string id)
        {
            try
            {
                string url = Constant.API_URL + "/topping/" + id;

                var response = await client.DeleteAsync(url);

                if (response == null)
                {
                    return false;
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
