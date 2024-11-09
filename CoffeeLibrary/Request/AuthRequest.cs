using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using CoffeeLibrary.Model;

namespace CoffeeLibrary.Request
{
    public class AuthRequest
    {
        HttpClient client = new HttpClient();

        public async Task<StoreLogin> loginToStore(string store_login_name, string password)
        {
            string url = Constant.API_URL + "/auth/login-to-store";

            // Create JSON object
            var json = new JObject();
            json.Add("store_login_name", store_login_name);
            json.Add("password", password);

            // Convert JSON object to string
            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            if (response == null)
            {
                return null;
            }

            try
            {
                JObject jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());

                // Check if response has field data
                if (jsonResponse["data"] == null)
                {
                    return null;
                }

                StoreLogin storeLogin = jsonResponse["data"].ToObject<StoreLogin>();
                return storeLogin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> loginToAdmin(string email, string password)
        {
            string url = Constant.API_URL + "/auth/login-to-admin";

            // Create JSON object
            var json = new JObject();
            json.Add("email", password);
            json.Add("password", password);

            // Convert JSON object to string
            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);

            if (response == null)
            {
                return null;
            }

            try
            {
                JObject jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());

                // Check if response has field data
                if (jsonResponse["data"] == null)
                {
                    return null;
                }

                User admin = jsonResponse["data"].ToObject<User>();
                return admin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
