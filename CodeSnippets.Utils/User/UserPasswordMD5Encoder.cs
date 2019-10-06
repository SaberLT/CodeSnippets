using CodeSnippets.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CodeSnippets.Utils.User
{
    public class UserPasswordMD5Encoder : IUserPasswordEncoder
    {
        public string EncodeUserPassword(string password)
        {
            using(var md5 = MD5.Create())
            {
                return GetMd5Hash(md5, password);
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}
