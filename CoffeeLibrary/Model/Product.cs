using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price {get; set;}
        public string description {get; set;}
        public string image {get; set;}
        public int status {get; set;}
        public int category_id {get; set;}
        public string category_name {get; set;}

    }

    public class CreateProductSize
    {
        public int size_id { get; set; }
        public decimal size_price { get; set; }
    }

    public class CreateProduct : Product
    {
        public List<int> product_toppings { get; set; }
        public List<ProductSize> product_sizes { get; set; }
    }
}
