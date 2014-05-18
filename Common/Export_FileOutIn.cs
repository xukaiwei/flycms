using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// 文件的读取和产生类
    /// </summary>
    public class Export_FileOutIn
    {
        //是否自选路径
        public static bool IsSaveDialog = true;

        #region 存储路径

        /// <summary>
        /// 存储路径
        /// </summary>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public static string SaveFilePath(string defaultname, string DirPath)
        {
            string path = "";
            if (IsSaveDialog)
            {
                SaveFileDialog newdailog = new SaveFileDialog();
                newdailog.FileName = defaultname;
                if (newdailog.ShowDialog() == DialogResult.OK)
                {
                    path = newdailog.FileName;
                }
            }
            else
            {
                if (!System.IO.Directory.Exists(DirPath))
                {
                    System.IO.Directory.CreateDirectory(DirPath);
                }
                path = DirPath + defaultname;
            }
            return path;
        }

        #endregion

        #region 读取给定文件

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="addr">文件路径</param>
        /// <returns></returns>
        public static string FileIn(string addr)
        {
            String code = "";
            if (File.Exists(addr))
            {
                StreamReader sr = new System.IO.StreamReader(addr, System.Text.Encoding.GetEncoding("UTF-8"));
                code = sr.ReadToEnd();
                sr.Close();
            }
            return code;
        }

        #endregion


        #region 输出生成的表格文件到指定位置
        /// <summary>
        /// 输出生成的表格文件到指定位置
        /// </summary>
        /// <param name="output">文件内容</param>
        /// <param name="addr">文件地址</param>
        public static void FileOut(string output, string addr)
        {
            string outpaper = output;

            FileStream fs = new FileStream(addr, FileMode.Create, FileAccess.Write);
            //通过指定字符编码方式可以实现对汉字的支持，否则在用记事本打开查看会出现乱码
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));

            sw.Flush();
            sw.BaseStream.Seek(0, SeekOrigin.Begin);
            sw.WriteLine(outpaper);
            sw.Flush();
            sw.Close();
        }

        #endregion
    }
}
