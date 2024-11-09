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
    public class CategoryRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Category>> GetCategoriesAsync() { 
            string url = Constant.API_URL + "/category";
            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<Category>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Category> categories = dataArray?.ToObject<List<Category>>() ?? new List<Category>();

                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<Category> CreateCategoryAsync(string category_name)
        {
            try
            {
                string url = Constant.API_URL + "/category";


                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(new Category
                    {
                        category_name = category_name
                    }),
                    Encoding.UTF8,
                    "application/json"
                ); ;
                var response = await client.PostAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                Category category = jsonResponse["data"].ToObject<Category>();

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> UpdateCategoryAsync(int categoryId, string newCategoryName)
        {
            try
            {
                string url = Constant.API_URL + "/category/" + categoryId;

                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(new { category_name = newCategoryName }),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PutAsync(url, jsonContent);

                if (response == null || !response.IsSuccessStatusCode)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                Category updatedCategory = jsonResponse["data"].ToObject<Category>();

                return updatedCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoryAsync(string categoryId)
        {
            try
            {
                string url = Constant.API_URL + "/category/" + categoryId;

                var response = await client.DeleteAsync(url);

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
    }
}
