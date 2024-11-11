using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            }
            catch (Exception ex)
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

        public async Task<string> uploadProductImageAsync(string filePath)
        {
            try
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(fileContent, "file", Path.GetFileName(filePath));

                    string url = Constant.API_URL + "/product/upload-image";
                    var response = await client.PostAsync(url, formData);

                    if (response == null)
                    {
                        return null;
                    }

                    string responseData = await response.Content.ReadAsStringAsync();
                    JObject jsonResponse = JObject.Parse(responseData);

                    string imageUrl = jsonResponse["data"]["image_url"].ToString();

                    return imageUrl;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> CreateProductAsync(CreateProduct product)
        {
            try
            {
                string url = Constant.API_URL + "/product";

                // Send data
                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(product),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                Product newProduct = jsonResponse["data"].ToObject<Product>();

                return newProduct;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateProductAsync(CreateProduct product)
        {
            try
            {
                string url = Constant.API_URL + "/product/" + product.id;

                // Send data
                var jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(product),Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                Product updatedProduct = jsonResponse["data"].ToObject<Product>();

                return updatedProduct;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                string url = Constant.API_URL + "/product/" + productId;

                var response = await client.DeleteAsync(url);

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
    }
}
