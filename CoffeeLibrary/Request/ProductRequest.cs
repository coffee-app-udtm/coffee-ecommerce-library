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

        public async Task<List<Product>> GetProductsAsync(string searchValue, int categoryId)
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

        public async Task<List<ProductTopping>> GetProductToppingsAsync(int productId)
        {
            try
            {
                string url = Constant.API_URL + "/product/product-toppings/" + productId;
                var response = await client.GetStringAsync(url);

                if (response == null)
                {
                    return new List<ProductTopping>();
                }

                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<ProductTopping> productToppings = dataArray?.ToObject<List<ProductTopping>>() ?? new List<ProductTopping>();

                return productToppings;

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductSize>> GetProductSizesAsync(int productId)
        {
            try
            {
                string url = Constant.API_URL + "/product/product-sizes/" + productId;
                var response = await client.GetStringAsync(url);

                if (response == null)
                {
                    return new List<ProductSize>();
                }

                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<ProductSize> productSizes = dataArray?.ToObject<List<ProductSize>>() ?? new List<ProductSize>();

                return productSizes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
