using System;
using System.Security.Cryptography;
using System.Text;

namespace Example362
{
    public class MD5CrtTest : ITestService
    {
        public string HashName => "MD5";

        public string GetResult(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            byte[] data = Encoding.UTF8.GetBytes(input);
            string result = null;
            using (MD5 md5 = MD5.Create())
            {
                byte[] output = md5.ComputeHash(data);
                result = Convert.ToBase64String(output);
            }
            return result;
        }
    }
}
