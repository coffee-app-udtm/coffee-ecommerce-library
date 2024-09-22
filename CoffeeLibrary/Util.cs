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

        public static bool IsEmail(string email)
        {
            return email.Contains("@");
        }

        public static bool IsPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10;
        }

        private static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

        public static string GenerateOrderId()
        {
            string prefix = "ORDER"; // 5 chars

            string randomNumbers = DateTime.Now.Ticks.ToString().Substring(0, 10);

            string randomChars = GenerateRandomString(5);

            return $"{prefix}{randomNumbers}{randomChars}";
        }
    }
}
