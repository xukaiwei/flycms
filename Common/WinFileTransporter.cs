using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Common
{
    /// <summary>
    /// winform形式的文件传输类
    /// </summary>
    public class WinFileTransporter
    {
        /// <summary>
        /// WebClient上传文件至服务器，默认不自动改名
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="uriString">服务器文件夹路径</param>
        public string[] UpLoadFile(string fileNamePath, string uriString)
        {
            return UpLoadFile(fileNamePath, uriString, false);
        }
        /// <summary>
        /// WebClient上传文件至服务器
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="uriString">服务器文件夹路径</param>
        /// <param name="IsAutoRename">是否自动按照时间重命名</param>
        public string[] UpLoadFile(string fileNamePath, string uriString, bool IsAutoRename)
        {
            string[] arr = new string[2];
            arr[0] = "-1";
            arr[1] = "";
            try
            {
                string fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\") + 1);
                string NewFileName = fileName;
                if (IsAutoRename)
                {
                    NewFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + fileNamePath.Substring(fileNamePath.LastIndexOf("."));
                }

                string fileNameExt = fileName.Substring(fileName.LastIndexOf(".") + 1);
                if (uriString.EndsWith("/") == false) uriString = uriString + "/";
                /// 创建WebClient实例
                WebClient myWebClient = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;

                if (File.Exists(fileNamePath))
                {
                    if (!Directory.Exists(uriString))
                    {
                        Directory.CreateDirectory(uriString);
                    }

                    // 要上传的文件
                    FileStream fs = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
                    //FileStream fs = OpenFile();
                    BinaryReader r = new BinaryReader(fs);
                    byte[] postArray = r.ReadBytes((int)fs.Length);
                    Stream postStream = myWebClient.OpenWrite(uriString + NewFileName, "PUT");

                    try
                    {

                        //使用UploadFile方法可以用下面的格式
                        //myWebClient.UploadFile(uriString,"PUT",fileNamePath);

                        if (postStream.CanWrite)
                        {
                            postStream.Write(postArray, 0, postArray.Length);
                            postStream.Close();
                            fs.Dispose();
                            arr[0] = "0";//上传文件成功
                            arr[1] = NewFileName;
                        }
                        else
                        {
                            postStream.Close();
                            fs.Dispose();
                            arr[0] = "1";//上传日志文件失败，文件不可写
                            arr[1] = "上传文件失败，文件不可写";
                        }

                    }
                    catch (Exception err)
                    {
                        postStream.Close();
                        fs.Dispose();
                        arr[0] = "1";
                        arr[1] = "上传文件异常:" + err.ToString();
                    }
                    finally
                    {
                        postStream.Close();
                        fs.Dispose();
                    }
                }
                else
                {
                    arr[0] = "1";
                    arr[1] = "上传文件失败，文件不存在";
                }
            }
            catch (Exception err)
            {
                arr[0] = "1";
                arr[1] = "上传文件异常:" + err.ToString();
            }
            return arr;
        }


        /**/
        /// <summary>
        /// 下载服务器文件至客户端

        /// </summary>
        /// <param name="URL">被下载的文件地址，绝对路径</param>
        /// <param name="Dir">另存放的目录</param>
        public string Download(string URL, string Dir)
        {
            string res = "";
            WebClient client = new WebClient();
            string fileName = URL.Substring(URL.LastIndexOf("\\") + 1);  //被下载的文件名

            string Path = Dir + fileName;   //另存为的绝对路径＋文件名
            try
            {
                WebRequest myre = WebRequest.Create(URL);
            }
            catch (Exception err)
            {
                //MessageBox.Show(exp.Message,"Error"); 
                res = "下载文件异常:" + err.ToString();
            }

            try
            {
                client.DownloadFile(URL, fileName);
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(fs);
                byte[] mbyte = r.ReadBytes((int)fs.Length);

                FileStream fstr = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);

                fstr.Write(mbyte, 0, (int)fs.Length);
                fstr.Close();

            }
            catch (Exception err)
            {
                //MessageBox.Show(exp.Message,"Error");
                res = "下载文件异常:" + err.ToString();
            }
            return res;
        }

    }
}
