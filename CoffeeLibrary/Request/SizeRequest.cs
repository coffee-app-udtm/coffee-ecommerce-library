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
    public class SizeRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Size>> GetSizesAsync()
        {
            string url = Constant.API_URL + "/size";
            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<Size>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Size> sizes = dataArray?.ToObject<List<Size>>() ?? new List<Size>();

                return sizes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Size> CreateSizeAsync(string size_name)
        {
            try
            {
                string url = Constant.API_URL + "/size";


                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(new Size
                    {
                        size_name = size_name
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

                Size size = jsonResponse["data"].ToObject<Size>();

                return size;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Size> UpdateSizeAsync(int sizeId, string newSizeName)
        {
            try
            {
                string url = Constant.API_URL + "/size/" + sizeId;

                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(new { category_name = newSizeName }),
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

                Size updatedSize = jsonResponse["data"].ToObject<Size>();

                return updatedSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSizeAsync(string sizeId)
        {
            try
            {
                string url = Constant.API_URL + "/size/" + sizeId;

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
