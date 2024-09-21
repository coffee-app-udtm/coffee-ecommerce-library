using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeLibrary
{
    public class Util
    {
        public static string FormatVNCurrency(decimal value)
        {
            return value.ToString("N0") + " đ";
        }
    }
}
