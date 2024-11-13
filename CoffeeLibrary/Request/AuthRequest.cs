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

        public async Task<List<StoreAccount>> GetStoreAccountsAsync()
        {
            string url = Constant.API_URL + "/auth/store-account";


            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return new List<StoreAccount>();
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<StoreAccount> accounts = dataArray?.ToObject<List<StoreAccount>>() ?? new List<StoreAccount>();

                return accounts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StoreAccount> CreateStoreAccountAsync(StoreAccount storeAccount)
        {
            try
            {
                string url = Constant.API_URL + "/auth/create-store-account";

                // Send data
                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(storeAccount),
                    Encoding.UTF8,
                    "application/json");

                var response = await client.PostAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                StoreAccount account = jsonResponse["data"].ToObject<StoreAccount>();

                return account;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StoreAccount> UpdateStoreAccountAsync(StoreAccount storeAccount)
        {
            try
            {
                string url = Constant.API_URL + "/auth/edit-store-account";

                // Send data
                var jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(storeAccount), Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, jsonContent);

                if (response == null)
                {
                    return null;
                }

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonResponse = JObject.Parse(responseData);

                StoreAccount updatedStoreAccount = jsonResponse["data"].ToObject<StoreAccount>();

                return updatedStoreAccount;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteStoreAccountAsync(int id)
        {
            try
            {
                string url = Constant.API_URL + "/auth/delete-store-account/" + id;

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
