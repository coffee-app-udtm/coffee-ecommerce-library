using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class Order
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string payment_method { get; set; } // vnpay momo cash
        public decimal total_payment { get; set; }
        public string order_status { get; set; }
        public string order_type { get; set; }
        public DateTime order_date { get; set; }
        public string order_note { get; set; }
        public decimal shipping_cost { get; set; }
        public string receiver_name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public int store_id { get; set; }
        public string voucher_id { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string store_name { get; set; }
        public string voucher_name { get; set; }

    }

}
