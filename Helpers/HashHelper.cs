using System;
using System.Security.Cryptography;
using System.Text;
namespace RegistrationLogin.Helpers
{
        public static class HashHelper
        {
            public static string GetMD5Hash(string input)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        builder.Append(data[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
}
