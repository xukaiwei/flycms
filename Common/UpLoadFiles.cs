using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;

namespace Common
{
    public class UpLoadFiles
    {
        /// <summary>
        /// 文件上传基类
        /// </summary>
        public class upfile
        {
            private string path = null;
            private string fileType = null;
            private int sizes = 0;
            /// <summary>
            /// 初始化变量
            /// </summary>
            public upfile()
            {
                path = "";  //上传路径

                fileType = ""; //上传文件类型限制
                sizes = 400000 * 1024;             //传文件的大小,默认40000KB
            }

            /// <summary>
            /// 设置上传路径,如:uploadimages/
            /// </summary>
            public string Path
            {
                set
                {
                    path = "/" + value + "/";
                }
            }

            /// <summary>
            /// 设置上传文件大小,单位为KB
            /// </summary>
            public int Sizes
            {
                set
                {
                    sizes = value * 1024;
                }
            }

            /// <summary>
            /// 设置上传文件的类型,如:jpg|gif|bmp
            /// </summary>
            public string FileType
            {
                set
                {
                    fileType = value;
                }
            }

            /// <summary>
            /// 文件上传基类
            /// </summary>
            /// <param name="name">控件名称</param>
            /// <param name="dept">部门名称</param>
            /// <returns>文件路径</returns>
            public string fileSaveAs(System.Web.UI.HtmlControls.HtmlInputFile name, string dept)
            {
                string filePath = null;
                try
                {

                    //待文件上传路径
                    string upLoadPath = null;
                    //所属以当前月份的文件夹名称
                    string monthFiles = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();
                    string mappathinfo = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + path;
                    if (!Directory.Exists(mappathinfo + dept + "\\" + monthFiles.Trim()))
                    {
                        Directory.CreateDirectory(mappathinfo + dept + "\\" + monthFiles.Trim());
                    }

                    upLoadPath = mappathinfo + dept + "\\" + monthFiles.Trim();
                    //获得文件的上传的路径
                    string sourcePath = name.Value.Trim();
                    //判断上传文件是否为空
                    if (sourcePath == "" || sourcePath == null)
                    {
                        message("您没有上传数据!");
                        return null;
                    }
                    int start = sourcePath.LastIndexOf("\\") + 1;
                    int end = sourcePath.Length;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + sourcePath.Substring(start, end - start);
                    filePath = upLoadPath + "\\" + filename;
                    FileInfo _file = new FileInfo(filePath);
                    if (_file.Exists)
                    {
                        message("该文件已存在，请查验或修改文件名称");

                        return null;
                    }
                    // 获得文件扩展名
                    string tFileType = sourcePath.Substring(sourcePath.LastIndexOf(".") + 1);
                    //获得上传文件的大小
                    long strLen = name.PostedFile.ContentLength;
                    //分解允许上传文件的格式
                    string[] temp = fileType.Split('|');
                    //设置上传的文件是否是允许的格式
                    bool flag = false;
                    //判断上传文件大小
                    if (strLen >= sizes)
                    {

                        message("上传的数据不能大于" + sizes + "KB");
                        return null;
                    }
                    //判断上传的文件是否是允许的格式
                    foreach (string data in temp)
                    {
                        if (data == tFileType)
                        {
                            flag = true;
                            break;
                        }
                    }
                    //如果为真允许上传,为假则不允许上传
                    if (!flag)
                    {
                        message("目前本系统支持的格式为:" + fileType);
                        return null;
                    }
                    name.PostedFile.SaveAs(filePath);
                    filePath = monthFiles + "/" + filename;
                    message("上传成功");

                }
                catch
                {
                    //异常
                    message("出现未知错误！");
                    return null;
                }
                return filePath;
            }

            private void message(string msg, string url)
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + msg + "');window.location='" + url + "'</script>");
            }

            private void message(string msg)
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + msg + "');</script>");
            }

        }

    }
}