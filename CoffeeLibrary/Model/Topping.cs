using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class Topping
    {
        public int id { get; set; }
        public string topping_name { get; set; }

        public decimal topping_price { get; set; }
    }
}
