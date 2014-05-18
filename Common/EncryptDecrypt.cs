using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Common
{
    /// <summary>
    /// 利用RSA对字符串进行加密 
    /// </summary>
    public sealed class EncryptDecrypt
    {
        static string[] strKeyValue = {"0", "1","2","3","4","5","6","7","8","9","+","-","*","/", "~","@","#","$","%","^","&","*","(",")","_","=",
                                   "|","\\","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x",
                                   "y","z","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X",
                                   "Y","Z",",",".",";","?","}","{","[","]","<",">"
                               };

        /// <summary>
        /// ASE获取密钥
        /// </summary>
        /// <returns>ASE获取密钥</returns>
        public static string GetAESKey()
        {
            Random rm = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                str.Append(strKeyValue[rm.Next(strKeyValue.Length)]);
            }
            return str.ToString();
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        public static string GetIV()
        {
            Random rm = new Random();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                str.Append(strKeyValue[rm.Next(strKeyValue.Length)]);
            }
            return str.ToString();
        }

        /// <summary>
        /// RSA generate private key and public key arr[0] for private key arr[1] for public key 
        /// </summary>
        /// <returns></returns>
        public static string[] GenerateKeys()
        {
            string[] sKeys = new String[2];
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            sKeys[0] = rsa.ToXmlString(true);
            sKeys[1] = rsa.ToXmlString(false);
            return sKeys;
        }

        /// <summary>
        /// RSA Encrypt,用public key加密
        /// </summary>
        /// <param name="sSource" >Source string</param>
        /// <param name="sPublicKey" >public key</param>
        /// <returns></returns>
        public static string EncryptString(string sSource, string sPublicKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            string plaintext = sSource;
            rsa.FromXmlString(sPublicKey);
            byte[] cipherbytes;
            byte[] byteEn = rsa.Encrypt(Encoding.UTF8.GetBytes("BEMSWeb"), true);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), true);

            StringBuilder sbString = new StringBuilder();
            for (int i = 0; i < cipherbytes.Length; i++)
            {
                sbString.Append(cipherbytes[i] + ",");
            }
            return sbString.ToString();
        }

        /// <summary>
        /// RSA Decrypt,用private Key 解密
        /// </summary>
        /// <param name="sSource">Source string</param>
        /// <param name="sPrivateKey">Private Key</param>
        /// <returns></returns>
        public static string DecryptString(String sSource, string sPrivateKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(sPrivateKey);
            byte[] byteEn = rsa.Encrypt(Encoding.UTF8.GetBytes("BEMSWeb"), true);
            string[] sBytes = sSource.Split(',');

            for (int j = 0; j < sBytes.Length; j++)
            {
                if (sBytes[j] != "")
                {
                    byteEn[j] = Byte.Parse(sBytes[j]);
                }
            }
            byte[] plaintbytes = rsa.Decrypt(byteEn, true);
            return Encoding.UTF8.GetString(plaintbytes);
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="Data">被加密的明文</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">向量</param>
        /// <returns>密文</returns>
        public static Byte[] AESEncrypt(Byte[] Data, string Key, string IV)//, String Key, String Vector
        {
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(IV.PadRight(bVector.Length)), bVector, bVector.Length);

            Byte[] Cryptograph = null; // 加密后的密文

            Rijndael Aes = Rijndael.Create();

            // 开辟一块内存流
            using (MemoryStream Memory = new MemoryStream())
            {
                // 把内存流对象包装成加密流对象
                using (CryptoStream Encryptor = new CryptoStream(Memory,
                  Aes.CreateEncryptor(bKey, bVector),
                  CryptoStreamMode.Write))
                {
                    // 明文数据写入加密流
                    Encryptor.Write(Data, 0, Data.Length);
                    Encryptor.FlushFinalBlock();

                    Cryptograph = Memory.ToArray();
                }
            }

            return Cryptograph;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="Data">被解密的密文</param> 
        /// <param name="Key">密钥</param>
        /// <param name="IV">向量</param>
        /// <returns>明文</returns>
        public static Byte[] AESDecrypt(Byte[] Data, string Key, string IV)//, String Key, String Vector
        {
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(IV.PadRight(bVector.Length)), bVector, bVector.Length);

            Byte[] original = null; // 解密后的明文

            Rijndael Aes = Rijndael.Create();

            // 开辟一块内存流，存储密文
            using (MemoryStream Memory = new MemoryStream(Data))
            {
                // 把内存流对象包装成加密流对象
                using (CryptoStream Decryptor = new CryptoStream(Memory,
                Aes.CreateDecryptor(bKey, bVector),
                CryptoStreamMode.Read))
                {
                    // 明文存储区
                    using (MemoryStream originalMemory = new MemoryStream())
                    {
                        Byte[] Buffer = new Byte[1024];
                        Int32 readBytes = 0;
                        while ((readBytes = Decryptor.Read(Buffer, 0, Buffer.Length)) > 0)
                        {
                            originalMemory.Write(Buffer, 0, readBytes);
                        }

                        original = originalMemory.ToArray();
                    }
                }
            }


            return original;
        }
    }
}
