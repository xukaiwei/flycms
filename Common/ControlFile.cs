using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Common
{
    public class ControlFile
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="strPath">文件夹路径</param>
        public static void CreateDirectory(string strPath)
        {
           if(!Directory.Exists(strPath))
           {
               Directory.CreateDirectory(strPath);
           }   

        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="strValue">要写入的内容</param>
        /// <param name="strPath">文件路径</param>
        public static void WriteFile(string strValue, string strPath)
        {
            FileStream fs = null;
            try
            {

                if (File.Exists(strPath))
                {
                    fs = new FileStream(strPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite, 2048);
                }
                else
                {
                    fs = File.Create(strPath, 2048);
                }
                byte[] bt = Encoding.Default.GetBytes(strValue);
                fs.Write(bt, 0, bt.Length);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="strPath">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string strPath)
        {
            string result = "";
            StreamReader strRead = null;
            try
            {
                if (File.Exists(strPath))//文件存在
                {

                    strRead = new StreamReader(strPath, Encoding.GetEncoding("GB18030"));
                   
                    result = strRead.ReadToEnd();

                }
            }
            finally
            {
                if (strRead != null)
                {
                    strRead.Close();
                }

            }
            return result;
        }


    }
}
