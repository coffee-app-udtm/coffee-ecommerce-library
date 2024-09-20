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

        public async Task<List<Category>> getCategoriesAsync() { 
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
    }
}
