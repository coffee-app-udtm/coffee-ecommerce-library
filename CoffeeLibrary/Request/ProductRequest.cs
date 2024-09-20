using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoffeeLibrary.Model;
using Newtonsoft.Json.Linq;

namespace CoffeeLibrary.Request
{
    public class ProductRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Product>> getProductsAsync(string searchValue, int categoryId)
        {
            string url = Constant.API_URL + "/product";

            if (!string.IsNullOrEmpty(searchValue))
            {
                url += "?search=" + searchValue;
            }

            if (categoryId > 0)
            {
                url += string.IsNullOrEmpty(searchValue) ? "?" : "&";
                url += "category_id=" + categoryId;
            }

            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<Product>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Product> products = dataArray?.ToObject<List<Product>>() ?? new List<Product>();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
