using System;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Services.Infrastructure
{
    public static class CryptoExtension
    {
        public static string ToMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(hashData).Replace("-", "").ToLower();
        }
    }
}
