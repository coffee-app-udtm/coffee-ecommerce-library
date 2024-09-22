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
    public class CartRequest
    {
        HttpClient client = new HttpClient();
        public async Task<bool> AddToCartAsync(int productId, string userId, int quantity, int? sizeId, List<int> toppings)
        {
            try
            {
                string url = Constant.API_URL + "/cart";

                var requestBody = new object();

                if (toppings.Count > 0)
                {
                    requestBody = new
                    {
                        product_id = productId,
                        user_id = userId,
                        quantity = quantity,
                        size_id = sizeId,
                        toppings = toppings  // Nếu danh sách toppings là dạng List<int>
                    };
                } else
                {
                    requestBody = new
                    {
                        product_id = productId,
                        user_id = userId,
                        quantity = quantity,
                        size_id = sizeId,
                    };
                }

                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Cart>> GetCartsAsync(string userId)
        {
            try
            {
                string url = Constant.API_URL + "/cart/" + userId;
                var response = await client.GetStringAsync(url);

                if (response == null)
                {
                    return new List<Cart>();
                }

                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Cart> carts = dataArray?.ToObject<List<Cart>>() ?? new List<Cart>();

                return carts;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCartAsync(int id)
        {

            try
            {
                string url = Constant.API_URL + "/cart/" + id;
                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
