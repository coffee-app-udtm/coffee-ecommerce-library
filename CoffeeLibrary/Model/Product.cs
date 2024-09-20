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
        public string status {get; set;}
        public int category_id {get; set;}
        public string category_name {get; set;}

    }
}
