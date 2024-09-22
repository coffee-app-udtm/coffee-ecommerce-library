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
    public class UserRequest
    {
        HttpClient client = new HttpClient();

        public async Task<User> GetUserByEmailOrPhoneNumberAsync(string value)
        {

            string url = Constant.API_URL + "/user/email-or-phone";

            // Check value is email or phone number
            if (value.Contains("@"))
            {
                url += "?email=" + value;
            }
            else
            {
                url += "?phone_number=" + value;
            }

            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return null;
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                JObject data = jsonResponse["data"] as JObject;

                if (data == null)
                {
                    return null;
                }

                User user = data?.ToObject<User>();

                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
