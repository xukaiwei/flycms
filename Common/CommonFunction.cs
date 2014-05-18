using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace Common
{
    public class CommonFunction
    {
        public static string GetSmallestChild(string TableName, string ClassID)
        {
            DataTable dt = DBUtility.OleDbHelper.Query("SELECT [SortID],[ParentID] FROM [" + TableName + "] ").Tables[0];
            string Str = "";
            if (HasChild(dt, ClassID))
            {
                Str = GetSmallestChild_Sub(dt, ClassID, "");
            }
            else
            {
                Str = ClassID + ",";
            }
            return Str.TrimEnd(',');
        }
        public static string GetSmallestChild_Sub(DataTable  dt, string ClassID, string TmpStr)
        {
            if (HasChild(dt, ClassID))
            {
                DataRow[] drs = dt.Select(" [ParentID]=" + ClassID); 
                foreach (DataRow dr in drs)
                {
                    string TmpClassID = dr[0].ToString();

                    if (HasChild(dt, TmpClassID))
                    {
                        TmpClassID += GetSmallestChild_Sub(dt, TmpClassID, TmpStr);
                    }
                    TmpStr += TmpClassID.TrimEnd(',') + ",";
                }
            }
            return TmpStr;
        }

        public static bool HasChild(DataTable  dt, string ClassID)
        {
            DataRow[] drs =dt.Select("[ParentID]=" + ClassID);
            if (drs.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static string GetLevel(string Num)
        {
            string temp = "";
            int NumLevel = 0;
            try
            {
                NumLevel = int.Parse(Num);
                if (NumLevel < 1)
                {
                    return "";
                }
                else
                {
                    for (int i = 1; i < NumLevel; i++)
                    {
                        temp += "&nbsp;&nbsp;";
                    }

                }
            }
            catch
            {

            }
            if (NumLevel != 1)
            {
                temp += "├";
            }
            return temp;
        }



        public static string GetIP()
        {
            string strIPAddr, actForIp;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]==null||HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == "" || HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0)
            {
                strIPAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                strIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
           // strIPAddr = HttpContext.Current.Request.UserHostAddress.ToString();
            return strIPAddr;
        }
    }
}
