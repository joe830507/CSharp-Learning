using System;
using System.Security.Cryptography;
using System.Text;

namespace Example362
{
    public class SHA256Test : ITestService
    {
        public string HashName => "SHA256";

        public string GetResult(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            byte[] contentbytes = Encoding.UTF8.GetBytes(input);
            byte[] computedBytes = null;
            using (SHA256 sha256 = SHA256.Create())
            {
                computedBytes = sha256.ComputeHash(contentbytes);
            }
            return Convert.ToBase64String(computedBytes);
        }
    }
}
