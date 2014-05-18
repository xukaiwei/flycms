using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
namespace Common
{

    #region 自定义结构体
    /// <summary>
    /// 文件目录属性
    /// </summary>
    public struct DirectoryStruct
    {
        public DirectoryInfo DI;
        public long Size;
    }
    /// <summary>
    /// 文件属性
    /// </summary>
    public struct FileStruct
    {
        public FileInfo FI;
        public long Size;
    }

    #endregion

    /// <summary>
    /// 专门处理文件及文件夹,所有异常均未捕捉,需在外部捕捉
    /// </summary>
    public class FileOpeartorFunction
    {

        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetAbsPath()
        {
            return GetAbsPath("/");

        }

        /// <summary>
        /// 获取绝对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetAbsPath(string path)
        {
            //#if DEBUG

            //            return @"E:\亿安软件\亿安cms\Web" + path;

            //#else
            if (path.StartsWith("/"))
            {
                return HttpContext.Current.Server.MapPath("/") + path;
            }
            return HttpContext.Current.Server.MapPath("/") + "/" + path;
            //#endif


        }

        #region 文件操作
        public static FileInfo GetFile(string _fileName)
        {
            return new System.IO.FileInfo(GetAbsPath(_fileName));

        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileDir"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ReadFile(string fileDir, Encoding e)
        {
            string content = "";
            fileDir = fileDir.Replace("\\", "/");
            try
            {
                //createfolder(fileDir,"filedir");
                using (System.IO.StreamReader fs = new System.IO.StreamReader(GetAbsPath(fileDir), e))
                {
                    content = fs.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return content;

        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileDir"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool createFile(string content, string fileDir, Encoding e)
        {
            fileDir = fileDir.Replace("\\", "/");
            try
            {
                //createfolder(fileDir,"filedir");
                using (System.IO.StreamWriter fs = new System.IO.StreamWriter(GetAbsPath(fileDir), false, e))
                {
                    fs.Write(content);
                    fs.Flush();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileDir">绝对路径</param>
        /// <returns></returns>
        public static bool isExistFile(string fileDir)
        {
            if (File.Exists(GetAbsPath(fileDir)))
            {
                return true;
            }
            return false;
        }

        public static bool delFile(string fileDir)
        {
            if (isExistFile(GetAbsPath(fileDir)))
            {
                File.Delete(GetAbsPath(fileDir));
                return true;
            }
            else
            {
                throw new Exception("文件不存在");
            }
        }

        public static bool moveFile(string oldFile, string newFile)
        {
            if (isExistFile(GetAbsPath(oldFile)))
            {
                File.Move(GetAbsPath(oldFile), GetAbsPath(newFile));
                return true;
            }
            else
            {
                throw new Exception("要移动文件不存在");
            }
        }

        public static FileStruct[] getFileList(string dir)
        {
            FileInfo[] fis = new System.IO.DirectoryInfo(GetAbsPath(dir)).GetFiles();
            FileStruct[] fi = new FileStruct[fis.Length];
            for (int i = 0; i < fis.Length; i++)
            {
                fi[i].FI = fis[i];
                fi[i].Size = fis[i].Length;
            }
            return fi;
        }

        public static string loadFile(string filePath, Encoding e)
        {
            using (StreamReader sr = new StreamReader(GetAbsPath(filePath), e))
            {
                return sr.ReadToEnd();
            }
        }

        public static string loadFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetAbsPath(filePath), Encoding.Default))
                {
                    return sr.ReadToEnd();
                }
            }
            catch
            {
                throw new Exception("读取文件时失败,请检查文件是否存在!" + filePath);
            }
        }
        #endregion



        #region 文件夹操作

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dirType"></param>
        /// <returns></returns>
        public static bool createFolder(string dir)
        {
            dir = dir.Replace("\\", "/");
            string s = GetAbsPath() + dir.Replace(GetAbsPath(), "");
            if (!Directory.Exists(s))
            {
                Directory.CreateDirectory(s);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileDir"></param>
        /// <returns></returns>
        public static bool isExistFolder(string folderDir)
        {
            if (Directory.Exists(GetAbsPath(folderDir)))
            {
                return true;
            }
            return false;
        }

        public static bool delFolder(string folderDir)
        {
            if (isExistFolder(GetAbsPath(folderDir)))
            {
                Directory.Delete(GetAbsPath(folderDir), true);
                return true;
            }
            else
            {
                throw new Exception("文件夹不存在");
            }
        }

        public static bool moveFolder(string oldFolder, string newFolder)
        {
            if (isExistFolder(GetAbsPath(oldFolder)))
            {
                Directory.Move(GetAbsPath(oldFolder), GetAbsPath(newFolder));
                return true;
            }
            else
            {
                throw new Exception("要移动目录不存在");
            }

        }

        public static DirectoryStruct[] getFolderList(string dir)
        {
            DirectoryInfo[] dis = new System.IO.DirectoryInfo(GetAbsPath(dir)).GetDirectories();
            DirectoryStruct[] ds = new DirectoryStruct[dis.Length];
            for (int i = 0; i < dis.Length; i++)
            {
                ds[i].DI = dis[i];
                ds[i].Size = GetDirectorySize(dis[i]);
            }
            return ds;
        }

        public static long GetDirectorySize(DirectoryInfo DI)
        {

            long size = 0;

            foreach (System.IO.FileInfo fi in DI.GetFiles())
            {
                size += fi.Length;
            }
            foreach (System.IO.DirectoryInfo di in DI.GetDirectories())
            {
                size += GetDirectorySize(di);
            }
            return size;

        }
        #endregion
    }

}