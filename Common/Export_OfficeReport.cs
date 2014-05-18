using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace Common
{
    /// <summary>
    /// 自动生成WROD/Excel表格类
    /// </summary>
    public class Export_OfficeReport
    {
        //换页符XML代码
        public static string changepaper = "<w:p w:rsidR=\"006D6B5B\" w:rsidRDefault=\"006D6B5B\"><w:pPr><w:widowControl/><w:jc w:val=\"left\"/><w:rPr><w:b/><w:sz w:val=\"28\"/><w:szCs w:val=\"28\"/></w:rPr></w:pPr><w:r><w:rPr><w:b/><w:sz w:val=\"28\"/><w:szCs w:val=\"28\"/></w:rPr><w:br w:type=\"page\"/></w:r></w:p>";
        //输入模版文件路径
        public static string addr = System.IO.Directory.GetCurrentDirectory() + "\\Templates\\";
        //换页行数
        public static int line = 1;

        #region 设置模板路径

        /// <summary>
        /// 设置模板路径
        /// </summary>
        /// <param name="path"></param>
        public void SetTemplatesPath(string path)
        {
            addr = path;
        }

        #endregion

        #region 根据HTML导出,WORD,EXCEL,TXT,HTML
        
        /// <summary>
        /// 根据HTML导出,WORD,EXCEL,TXT,HTML
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <param name="table">数据</param>
        /// <param name="filetype">文件格式</param>
        /// <returns>文件内容</returns>
        public string ExportOfficeFile(string name,DataTable table,string filetype)
        {
            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".htm");

            //获取重复项文件内容(Body2是单行模版Body2)
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Data.htm");
            string Body4 = "";
            StringBuilder Body = new StringBuilder();


            for (int j = 0; j < table.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table.Columns)
                {
                    string vstr = "$" + table.Columns[k].ColumnName + "$";
                    //if (Body4.IndexOf(vstr) >= 0)
                    //{
                        string str = table.Rows[j][k].ToString().Replace("<", "(").Replace(">", ")");
                        Body4 = Body4.Replace(vstr, str).Replace("$序号$", (j + 1).ToString());
                    //}
                    k++;
                }
                Body.Append(Body4);
            }
            string paperxml = Frame0.Replace("<!--datastart--><!--dataend-->", Body.ToString());
            return paperxml;
        }

        /// <summary>
        /// 根据HTML导出,WORD,EXCEL,TXT,HTML
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <param name="table">数据</param>
        /// <param name="filetype">文件格式</param>
        /// <returns>文件内容</returns>
        public string ExportOfficeFile(string name, DataTable table,DataTable childtable,string keyname, string filetype)
        {
            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".htm");

            //获取重复项文件内容(Body2是单行模版Body2)
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Data.htm");
            string ChildBodyHead = Export_FileOutIn.FileIn(addr + name + "_Child_Head.htm");
            string ChildBodyData = Export_FileOutIn.FileIn(addr + name + "_Child_Data.htm");
            string ChildBodyBottom = Export_FileOutIn.FileIn(addr + name + "_Child_Bottom.htm");
            string Body4 = "";
            StringBuilder Body = new StringBuilder();

            for (int j = 0; j < table.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table.Columns)
                {
                    string vstr = "$" + table.Columns[k].ColumnName + "$";
                    //if (Body4.IndexOf(vstr) >= 0)
                    //{
                    string str = table.Rows[j][k].ToString().Replace("<", "(").Replace(">", ")");
                    Body4 = Body4.Replace(vstr, str).Replace("$序号$", (j + 1).ToString());
                    //}
                    k++;
                }
                Body.Append(Body4);
                if (childtable != null)
                {
                    int c = 0;
                    DataRow[] arrrow = childtable.Select(" " + keyname + "='" + table.Rows[j][keyname].ToString().Trim() + "' ");
                    if (arrrow != null)
                    {
                        if (arrrow.Length > 0)
                        {
                            Body.Append(ChildBodyHead);
                        }
                        foreach (DataRow row in arrrow)
                        {
                            int m = 0;
                            Body4 = ChildBodyData;
                            foreach (DataColumn column in childtable.Columns)
                            {
                                string vstr = "$" + childtable.Columns[m].ColumnName + "$";
                                //if (Body4.IndexOf(vstr) >= 0)
                                //{
                                string str = row[m].ToString().Replace("<", "(").Replace(">", ")");
                                Body4 = Body4.Replace(vstr, str).Replace("$序号$", (c + 1).ToString());
                                //}
                                m++;
                            }
                            c++;
                            Body.Append(Body4);
                        }
                        //if (arrrow.Length > 0)
                        //{
                            Body.Append(ChildBodyBottom);
                        //}
                    }
                }

            }
            string paperxml = Frame0.Replace("<!--datastart--><!--dataend-->", Body.ToString());
            return paperxml;
        }

        /// <summary>
        /// 根据HTML导出,WORD,EXCEL,TXT,HTML
        /// </summary>
        /// <param name="name">文件名称</param>
        /// <param name="table">数据</param>
        /// <param name="filetype">文件格式</param>
        /// <returns>文件内容</returns>
        public string ExportOfficeFile_Attendance(string name, DataTable table, string filetype,string Title)
        {
            //获取文件头Frame

            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".htm");

            string strTitle="";
            string strBody = "";
            if (table != null)
            {
                if (table.Columns.Count > 0)
                {
                    strTitle = "<tr class=xl24 height=26 style='mso-height-source:userset;height:20.1pt'>";
                    strTitle += "<td class=xl26 style='width:81pt' colspan='" + table.Columns.Count + "'>" + Title;
                    strTitle += "</td>";
                    strTitle += "</tr>";
                }
                
                strBody = "<tr class=xl24 height=26 style='mso-height-source:userset;height:20.1pt'>";
                
                foreach (DataColumn column in table.Columns)
                {
                    strBody += "<td class=xl26 width=108 style='width:81pt'>" + column.ColumnName + "</td>";
                }
                strBody += "</tr>";

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    string str = "<tr height=\"26\" style='mso-height-source: userset; height: 20.1pt'>";

                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        str += "<td class=\"xl26\" style='border-top: none; border-left: none'>" + table.Rows[j][k].ToString().Replace("<", "(").Replace(">", ")") + "</td>";
                    }
                    str += "</tr>";
                    strBody += str;
                }
            }
            strBody = strTitle + strBody;
            return Frame0.Replace("<!--datastart--><!--dataend-->",strBody);

        }
        #endregion


        #region 生成无重复项表格DATAROW
        public string GetOfficeRpt(string name, DataRow row)
        {
            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");
            //string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            //string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");
            //获取文件内容Body
            string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
            string Body0 = Body1;
            //循环替换表格内容
            int i = 0;
            foreach (DataColumn column in row.Table.Columns)
            {
                bool IsDate = false;
                try
                {
                    Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                    IsDate = true;
                }
                catch
                {
                    IsDate = false;
                }
                if (IsDate)
                {
                    try
                    {
                        DateTime TempTime = Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                        Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempTime.ToString("yyyy-MM-dd"));
                    }
                    catch
                    {
                        Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "");
                    }
                }
                else
                {
                    if (row.Table.Columns[i].DataType.ToString() == "System.Decimal")
                    {
                        try
                        {
                            decimal TempDeci = Convert.ToDecimal(row.Table.Rows[0][i].ToString());
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempDeci.ToString());
                        }
                        catch
                        {
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "0");
                        }

                    }
                    else
                    {
                        Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());
                    }
                }
                //Console.WriteLine(row.Table.Rows[0][i]);
                i++;
                // Console.WriteLine(i);
            }

            string paperxml = Frame0.Replace(Body0, Body1);
            return paperxml;
        }
        #endregion


        #region 生成无重复项表格HASHTABLE
        public string GetOfficeRpt(string name, Hashtable hashtable)
        {
            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");
            //string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            //string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");
            //获取文件内容Body
            string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
            string Body0 = Body1;
            //循环替换表格内容
            foreach (DictionaryEntry de in hashtable)
                Body1 = Body1.Replace("$" + de.Key + "$", de.Value.ToString());



            string paperxml = Frame0.Replace(Body0, Body1);
            return paperxml;
        }
        #endregion


        #region 生成混合项表格DATAROW & DATATABLE 带排序
        //
        public string GetOfficeRpt(string name, DataRow row, DataTable TempTable, string OrderStr)
        {
            DataView dv = TempTable.DefaultView;
            dv.Sort = OrderStr;
            DataTable table = dv.ToTable();



            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");
            //string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            //string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");

            if (null != row)
            {
                //获取无重复项文件内容Body1
                string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
                string Body0 = Body1;




                int i = 0;
                //foreach (DataColumn column in row.Table.Columns)
                //{
                //    //Console.WriteLine(row.Table.Columns[i].ColumnName);
                //    Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());

                //    //Console.WriteLine(row.Table.Rows[0][i]);
                //    i++;
                //    //Console.WriteLine(i);
                //}
                foreach (DataColumn column in row.Table.Columns)
                {
                    bool IsDate = false;
                    try
                    {
                        Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                        IsDate = true;
                    }
                    catch
                    {
                        IsDate = false;
                    }
                    if (IsDate)
                    {
                        try
                        {
                            DateTime TempTime = Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempTime.ToString("yyyy-MM-dd"));
                        }
                        catch
                        {
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "");
                        }
                    }
                    else
                    {
                        if (row.Table.Columns[i].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {
                                decimal TempDeci = Convert.ToDecimal(row.Table.Rows[0][i].ToString());
                                Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempDeci.ToString(""));
                            }
                            catch
                            {
                                Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "0");
                            }

                        }
                        else
                        {
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());
                        }
                    }
                    i++;
                }

                Frame0 = Frame0.Replace(Body0, Body1);
            }


            //获取重复项文件内容(Body2是单行模版Body2)
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2.xml");
            string Body3 = "";
            string Body4 = "";
            int t = 0;

            for (int j = 0; j < table.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table.Columns)
                {
                    bool IsDate = false;
                    try
                    {
                        Convert.ToDateTime(table.Rows[j][k].ToString());
                        IsDate = true;
                    }
                    catch
                    {
                        IsDate = false;
                    }
                    if (IsDate)
                    {
                        try
                        {
                            DateTime TempTime = Convert.ToDateTime(table.Rows[j][k].ToString());
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", TempTime.ToString("yyyy-MM-dd"));
                        }
                        catch
                        {
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", "");
                        }
                    }
                    else
                    {


                        if (table.Columns[k].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {
                                decimal TempDeci = Convert.ToDecimal(table.Rows[j][k].ToString());
                                Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", TempDeci.ToString(""));
                            }
                            catch
                            {
                                Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", "0");
                            }

                        }
                        else
                        {
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", table.Rows[j][k].ToString());
                        }
                    }
                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            string paperxml = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();
            return paperxml;
        }
        #endregion

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="TempTable"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public decimal SumColumns(DataTable TempTable, string ColumnName)
        {
            decimal ReturnValue = 0;
            for (int i = 0; i < TempTable.Rows.Count; i++)
            {
                decimal TempValue = 0;
                try
                {
                    TempValue = Convert.ToDecimal(TempTable.Rows[i][ColumnName].ToString());
                }
                catch
                {
                    TempValue = 0;
                }
                ReturnValue = ReturnValue + TempValue;
            }
            return ReturnValue;
        }

        #region 生成混合项表格DATAROW & DATATABLE
        //
        public string GetOfficeRpt(string name, DataRow row, DataTable table)
        {

            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");

            if (null != row)
            {
                //获取无重复项文件内容Body1
                #region 获取无重复项文件内容Body1
                string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
                string Body0 = Body1;
                int i = 0;
                foreach (DataColumn column in row.Table.Columns)
                {
                    bool IsDate = false;
                    try
                    {
                        Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                        IsDate = true;
                    }
                    catch
                    {
                        IsDate = false;
                    }
                    if (IsDate)
                    {
                        try
                        {
                            DateTime TempTime = Convert.ToDateTime(row.Table.Rows[0][i].ToString());
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempTime.ToString("yyyy-MM-dd"));
                        }
                        catch
                        {
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "");
                        }
                    }
                    else
                    {
                        if (row.Table.Columns[i].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {
                                decimal TempDeci = Convert.ToDecimal(row.Table.Rows[0][i].ToString());
                                Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", TempDeci.ToString(""));
                            }
                            catch
                            {
                                Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", "0");
                            }

                        }
                        else
                        {
                            Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());
                        }
                    }
                    i++;

                }

                Frame0 = Frame0.Replace(Body0, Body1);
                #endregion
            }

            //获取重复项文件内容(Body2是单行模版Body2)
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2.xml");
            string Body3 = "";
            string Body4 = "";


            for (int j = 0; j < table.Rows.Count; j++)
            {
                if (table.Rows[j].RowState == DataRowState.Deleted)
                {
                    continue;
                }
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table.Columns)
                {
                    bool IsDate = false;
                    try
                    {
                        Convert.ToDateTime(table.Rows[j][k].ToString());
                        IsDate = true;
                    }
                    catch
                    {
                        IsDate = false;
                    }
                    if (IsDate)
                    {
                        try
                        {
                            DateTime TempTime = Convert.ToDateTime(table.Rows[j][k].ToString());
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", TempTime.ToString("yyyy-MM-dd"));
                        }
                        catch
                        {
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", "");
                        }
                    }
                    else
                    {
                        if (table.Columns[k].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {

                                decimal TempDeci = Convert.ToDecimal(table.Rows[j][k].ToString());
                                Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", TempDeci.ToString(""));
                            }
                            catch
                            {
                                Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", "0");
                            }

                        }
                        else
                        {
                            string str = table.Rows[j][k].ToString().Replace("<", "(");
                            str = str.Replace(">", ")");
                            Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", str);
                        }
                    }
                    k++;
                }
                Body3 = Body3 + Body4;
                Body3 = Body3.Replace("$序号$", (j + 1).ToString());

            }
            // decimal YJHJ = SumColumns(table, "总金额");
            // Frame0 = Frame0.Replace("$合计$", YJHJ.ToString("N"));
            string paperxml = Frame0.Replace(Body2, Body3);
            return paperxml;
        }
        #endregion


        #region 生成混合项表格HASHTABLE & DATATABLE
        //
        public string GetOfficeRpt(string name, Hashtable hashtable, DataTable table, int line)
        {

            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");
            //string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            //string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");



            if (null != hashtable)
            {
                //获取无重复项文件内容Body1
                string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
                string Body0 = Body1;



                foreach (DictionaryEntry de in hashtable)
                    Body1 = Body1.Replace("$" + de.Key + "$", de.Value.ToString());

                Frame0 = Frame0.Replace(Body0, Body1);


            }




            //获取重复项文件内容Body2
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2.xml");
            string Body3 = "";
            string Body4 = "";

            for (int j = 0; j < table.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", table.Rows[j][k].ToString());



                    k++;
                }
                if (j == line)
                {
                    Body3 = Body3 + changepaper;
                }

                Body3 = Body3 + Body4;

            }
            //Console.ReadLine();
            string paperxml = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();
            return paperxml;
        }
        #endregion

        #region 生成混合项表格DATAROW & DATATABLE[]
        //
        public string GetOfficeRpt(string name, DataRow row, DataTable[] tablearray)
        {

            //获取文件头Frame
            string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");
            //获取无重复项文件内容Body
            string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");


            # region 单一部分
            int i = 0;
            foreach (DataColumn column in row.Table.Columns)
            {
                //Console.WriteLine(row.Table.Columns[i].ColumnName);
                Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());

                //Console.WriteLine(row.Table.Rows[0][i]);
                i++;
                //Console.WriteLine(i);
            }
            # endregion


            # region 复杂部分

            string Body3 = "";
            i = 1;
            foreach (DataTable table in tablearray)
            {
                string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2_" + i + ".xml");

                string Body4 = "";

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    int k = 0;
                    Body4 = Body2;
                    foreach (DataColumn column in table.Columns)
                    {
                        // Console.WriteLine(table.Columns[k].ColumnName);


                        Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", table.Rows[j][k].ToString());



                        k++;
                    }


                    Body3 = Body3 + Body4;

                }
            }
            // Console.ReadLine();
            string paperxml = Frame1 + Body1 + Body3 + Frame2;
            // Console.WriteLine(paperxml);
            //Console.ReadLine();
            return paperxml;
            # endregion


        }

        #endregion

        #region 生成混合项表格HASHTABLE & DATATABLE[]
        //
        public string GetOfficeRpt(string name, Hashtable hashtable, DataTable[] tablearray)
        {

            //获取文件头Frame
            string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");
            //获取无重复项文件内容Body
            string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");


            # region 单一部分
            foreach (DictionaryEntry de in hashtable)
                Body1 = Body1.Replace("$" + de.Key + "$", de.Value.ToString());
            # endregion


            #region 复杂部分
            string Body3 = "";
            int i = 1;
            foreach (DataTable table in tablearray)
            {
                string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2_" + i + ".xml");

                string Body4 = "";

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    int k = 0;
                    Body4 = Body2;
                    foreach (DataColumn column in table.Columns)
                    {
                        //Console.WriteLine(table.Columns[k].ColumnName);


                        Body4 = Body4.Replace("$" + table.Columns[k].ColumnName + "$", table.Rows[j][k].ToString());



                        k++;
                    }


                    Body3 = Body3 + Body4;

                }
            }
            //Console.ReadLine();
            string paperxml = Frame1 + Body1 + Body3 + Frame2;
            // Console.WriteLine(paperxml);
            //Console.ReadLine();
            return paperxml;

            #endregion

        }
        #endregion

        #region 产生表格生成时间
        public string GetRptTime(string Frame)
        {


            Frame = Frame.Replace("$X1$", System.DateTime.Now.Year.ToString());
            Frame = Frame.Replace("$X2$", System.DateTime.Now.Month.ToString());
            Frame = Frame.Replace("$X3$", System.DateTime.Now.Day.ToString());

            return Frame;
        }
        #endregion


        #region 产生封面
        public string GetRpt(string name)
        {

            string Frame = Export_FileOutIn.FileIn(addr + name + ".xml");
            Frame = Frame.Replace("$X1$", System.DateTime.Now.Year.ToString());
            Frame = Frame.Replace("$X2$", System.DateTime.Now.Month.ToString());
            return Frame;
        }
        #endregion

        #region 生成变动审批表
        //
        public string GetOfficeRpt5(string name, DataRow row, DataTable table1, DataTable table2, DataTable table3, DataTable table4, DataTable table5)
        {

            //获取文件头Frame
            string Frame0 = Export_FileOutIn.FileIn(addr + name + ".xml");
            //string Frame1 = Export_FileOutIn.FileIn(addr + name + "_Frame1.xml");
            //string Frame2 = Export_FileOutIn.FileIn(addr + name + "_Frame2.xml");

            if (null != row)
            {
                //获取无重复项文件内容Body1
                string Body1 = Export_FileOutIn.FileIn(addr + name + "_Body1.xml");
                string Body0 = Body1;



                int i = 0;
                foreach (DataColumn column in row.Table.Columns)
                {
                    //Console.WriteLine(row.Table.Columns[i].ColumnName);
                    Body1 = Body1.Replace("$" + row.Table.Columns[i].ColumnName + "$", row.Table.Rows[0][i].ToString());

                    //Console.WriteLine(row.Table.Rows[0][i]);
                    i++;
                    //Console.WriteLine(i);
                }
                Frame0 = Frame0.Replace(Body0, Body1);
            }

            //----------------------------------------------------------------------------------------------
            //获取重复项文件内容(Body2是单行模版Body2)
            string Body2 = Export_FileOutIn.FileIn(addr + name + "_Body2.xml");
            string Body3 = "";
            string Body4 = "";
            int t = 0;

            for (int j = 0; j < table1.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table1.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table1.Columns[k].ColumnName + "$", table1.Rows[j][k].ToString());



                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            Frame0 = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();
            //------------------------------------------------------------------------------------------------------
            //获取重复项文件内容(Body2是单行模版Body2)
            Body2 = Export_FileOutIn.FileIn(addr + name + "_Body3.xml");
            Body3 = "";
            Body4 = "";
            t = 0;

            for (int j = 0; j < table2.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table2.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table2.Columns[k].ColumnName + "$", table2.Rows[j][k].ToString());



                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            Frame0 = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();



            //----------------------------------------------------------------------------------------------------------------------------

            //获取重复项文件内容(Body2是单行模版Body2)
            Body2 = Export_FileOutIn.FileIn(addr + name + "_Body4.xml");
            Body3 = "";
            Body4 = "";
            t = 0;

            for (int j = 0; j < table3.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table3.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table3.Columns[k].ColumnName + "$", table3.Rows[j][k].ToString());



                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            Frame0 = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();

            //-----------------------------------------------------------------------------------------------
            //获取重复项文件内容(Body2是单行模版Body2)
            Body2 = Export_FileOutIn.FileIn(addr + name + "_Body5.xml");
            Body3 = "";
            Body4 = "";
            t = 0;

            for (int j = 0; j < table4.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table1.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table4.Columns[k].ColumnName + "$", table4.Rows[j][k].ToString());



                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            Frame0 = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();
            //--------------------------------------------------------------------------------------------------------------------------

            //获取重复项文件内容(Body2是单行模版Body2)
            Body2 = Export_FileOutIn.FileIn(addr + name + "_Body6.xml");
            Body3 = "";
            Body4 = "";
            t = 0;

            for (int j = 0; j < table5.Rows.Count; j++)
            {
                int k = 0;
                Body4 = Body2;
                foreach (DataColumn column in table1.Columns)
                {
                    //Console.WriteLine(table.Columns[k].ColumnName);


                    Body4 = Body4.Replace("$" + table5.Columns[k].ColumnName + "$", table5.Rows[j][k].ToString());



                    k++;
                }


                Body3 = Body3 + Body4;
                t++;

            }
            //Console.ReadLine();
            string paperxml = Frame0.Replace(Body2, Body3);
            //Console.WriteLine(paperxml);
            //Console.ReadLine();
            return paperxml;
        }
        #endregion
    }
}
