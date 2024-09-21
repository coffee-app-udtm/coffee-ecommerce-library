using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class ProductSize
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int size_id { get; set; }
        public decimal size_price { get; set; }
        public string size_name { get; set; }

    }
}
