using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary.Model
{
    public class Store
    {
        public int id { get; set; }

        public string store_name { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string district { get; set; }

        public string ward { get; set; }

        public string google_map_location { get; set; }

        public string open_time { get; set; }

        public string close_time { get; set; }
    }
    
    public class StoreLogin : Store
    {
        public string store_login_name { get; set; }

        public string password { get; set; }
    }
}
