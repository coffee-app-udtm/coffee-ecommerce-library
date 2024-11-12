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
    public class RevenueRequest
    {
        HttpClient client = new HttpClient();

        public async Task<List<Revenue>> GetRevenuesAsync(int day, int month, int year, int storeId)
        {
            string url = Constant.API_URL;

            if (storeId > 0)
            {
                url += "/revenue/store?storeId=" + storeId + "&";
            }
            else
            {
                url += "/revenue/admin?";
            }

            url += "day=" + day + "&month=" + month + "&year=" + year;

            var response = await client.GetStringAsync(url);

            if (response == null)
            {
                return null;
            }

            try
            {
                JObject jsonResponse = JObject.Parse(response);

                // Nullable
                JArray dataArray = jsonResponse["data"] as JArray;

                List<Revenue> revenues = dataArray?.ToObject<List<Revenue>>() ?? new List<Revenue>();

                return revenues;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
