using System;
using System.Collections.Generic;

using System.Text;
using System.Security.Cryptography;

namespace Common
{
    /// <summary>
    /// 利用MD5对字符串进行加密 
    /// </summary>
   public class MD5Encrypt
    {
        ///
        /// 利用MD5对字符串进行加密 
        /// </summary>
        public static string EncryptMD5(string encryptString)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(encryptString));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }
    }
}
