using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class ProductTopping
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public decimal topping_price { get; set; }
        public string topping_name { get; set; }

        public string display_info
        {
            get { return $"{topping_name} (+ {Util.FormatVNCurrency(topping_price)})"; } 
        }
    }
}
