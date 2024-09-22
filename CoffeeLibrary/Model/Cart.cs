using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class Cart
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public int product_status { get; set; }
        public string product_image { get; set; }
        public int size_id { get; set; }
        public string size_name { get; set; }
        public double size_price { get; set; }
        public int quantity { get; set; }
        public List<CartTopping> toppings { get; set; }
        public double order_item_price { get; set; }
    }

    public class CartTopping
    {
        public int topping_storage_id;
        public int topping_id;
        public string topping_name;
        public double topping_price;
    }
}
