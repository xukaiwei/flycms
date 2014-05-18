using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using DBUtility;
namespace Common
{
    public class TemplateClass
    {
        private Regex regExpObj;
        public string content;
        //public static string loadFile = "";
        //public static string sitePath = "";
        private string _sitePath;
        public string sitePath
        {
            get { return _sitePath; }
            set { _sitePath = value; }
        }
        public string defaultTemplate = "default";
        public string htmlFilePath = "html";
        public string srcTemplate = "";
        public string FileExt = ".html";
        public string upLoadPath = "/upload/";
        public string runstr = "index.aspx?";
        bool runMode = false;
        string siteLogoUrl = "";
        string companyName = "";
        string additionTitle = "";
        public string siteTitle = "";
        string companyAddress = "";
        string companyPostCode = "";
        string companyContact = "";
        string companyPhone = "";
        string companyMobile = "";
        string companyFax = "";
        string companyEmail = "";
        string companyICP = "";
        string statisticalCode = "";
        string siteUrl = "";
        string copyRight = "";
        string siteDesc = "";
        public string siteNotice = "";
        public string siteMode = "";
        public string switchFaq = "";//评论开关
        public string switchComments = "";
        string switchBBS = "";
        string waterMark = "";
        string waterMarkFont = "";
        string waterMarkLocation = "";
        string textFilter = "";
        string siteKeyWords = "";
        //static string getslide = "";
        //static string getkf = "";
        //static string getonlineservice = "";
        string slideTextStatus;
        string slideTexts;
        string slideWidth;
        string slideHeight;
        string slideImgs;
        string slideLinks;
        string adStatus;
        string servicekfStatus;
        string serviceQQ;
        string serviceWangWang;
        static string serviceContact;
        static string servicekf;
        static string adLink;
        static string adImagePath;
        static string adImgWidth;
        static string adImgHeight;
        static string keys;
        string serviceStyle;
        string serviceStatus;
        public static Dictionary<string, string> strDictionary = new Dictionary<string, string>();
        public TemplateClass()
        {
            GetWebSetting();

        }
        public void GetWebSetting()
        {
            string cpath = FileOpeartorFunction.GetAbsPath("/config/companySetting.config");
            siteTitle = XmlHelper.Read(cpath, "/companySetting/siteTitle", "");//. dt.Rows[0]["siteTitle"].ToString();
            siteLogoUrl = XmlHelper.Read(cpath, "/companySetting/siteLogoUrl", "");// dt.Rows[0]["siteLogoUrl"].ToString();
            siteUrl = XmlHelper.Read(cpath, "/companySetting/siteUrl", "");// dt.Rows[0]["siteUrl"].ToString();
            companyName = XmlHelper.Read(cpath, "/companySetting/companyName", "");// dt.Rows[0]["companyName"].ToString();
            companyAddress = XmlHelper.Read(cpath, "/companySetting/companyAddress", "");// dt.Rows[0]["companyAddress"].ToString();
            companyPostCode = XmlHelper.Read(cpath, "/companySetting/companyPostCode", "");// dt.Rows[0]["companyPostCode"].ToString();
            companyContact = XmlHelper.Read(cpath, "/companySetting/companyContact", "");// dt.Rows[0]["companyContact"].ToString();
            companyPhone = XmlHelper.Read(cpath, "/companySetting/companyPhone", "");// dt.Rows[0]["companyPhone"].ToString();
            companyMobile = XmlHelper.Read(cpath, "/companySetting/companyMobile", "");// dt.Rows[0]["companyMobile"].ToString();
            companyFax = XmlHelper.Read(cpath, "/companySetting/companyFax", "");// dt.Rows[0]["companyFax"].ToString();
            companyEmail = XmlHelper.Read(cpath, "/companySetting/companyEmail", "");// dt.Rows[0]["companyEmail"].ToString();
            statisticalCode = XmlHelper.Read(cpath, "/companySetting/statisticalCode", "");// dt.Rows[0]["statisticalCode"].ToString();
            companyICP = XmlHelper.Read(cpath, "/companySetting/companyICP", "");// dt.Rows[0]["companyICP"].ToString();
            //DataTable dt = DBUtility.OleDbHelper.Query("select * from companySetting").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    siteTitle = dt.Rows[0]["siteTitle"].ToString();
            //    siteLogoUrl = dt.Rows[0]["siteLogoUrl"].ToString();
            //    siteUrl = dt.Rows[0]["siteUrl"].ToString();
            //    companyName = dt.Rows[0]["companyName"].ToString();
            //    companyAddress = dt.Rows[0]["companyAddress"].ToString();
            //    companyPostCode = dt.Rows[0]["companyPostCode"].ToString();
            //    companyContact = dt.Rows[0]["companyContact"].ToString();
            //    companyPhone = dt.Rows[0]["companyPhone"].ToString();
            //    companyMobile = dt.Rows[0]["companyMobile"].ToString();
            //    companyFax = dt.Rows[0]["companyFax"].ToString();
            //    companyEmail = dt.Rows[0]["companyEmail"].ToString();
            //    statisticalCode = dt.Rows[0]["statisticalCode"].ToString();
            //    companyICP = dt.Rows[0]["companyICP"].ToString();
            //}

            cpath = FileOpeartorFunction.GetAbsPath("/config/onlineServiceSetting.config");
            serviceStatus = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceStatus", "");
            serviceStyle = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceStyle", "");
            //serviceLocation = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceLocation", "");
            serviceQQ = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceQQ", "");
            serviceWangWang = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceWangWang", "");
            //serviceEmail = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceEmail", "");
            //servicePhone = XmlHelper.Read(cpath, "/onlineServiceSetting/servicePhone", "");
            serviceContact = XmlHelper.Read(cpath, "/onlineServiceSetting/serviceContact", "");
            servicekfStatus = XmlHelper.Read(cpath, "/onlineServiceSetting/servicekfStatus", "");
            servicekf = XmlHelper.Read(cpath, "/onlineServiceSetting/servicekf", "");

            //DataTable  dt = DBUtility.OleDbHelper.Query("select * from onlineServiceSetting").Tables[0];
            //  if (dt.Rows.Count > 0)
            //  {
            //      serviceStatus = dt.Rows[0]["serviceStatus"].ToString();
            //      serviceStyle = dt.Rows[0]["serviceStyle"].ToString();
            //      //serviceLocation = dt.Rows[0]["serviceLocation"].ToString();
            //      serviceQQ = dt.Rows[0]["serviceQQ"].ToString();
            //      serviceWangWang = dt.Rows[0]["serviceWangWang"].ToString();
            //      // serviceEmail = dt.Rows[0]["serviceEmail"].ToString();
            //      // servicePhone = dt.Rows[0]["servicePhone"].ToString();
            //      serviceContact = dt.Rows[0]["serviceContact"].ToString();
            //      servicekfStatus = dt.Rows[0]["servicekfStatus"].ToString();
            //      servicekf = dt.Rows[0]["servicekf"].ToString();
            //  }
            cpath = FileOpeartorFunction.GetAbsPath("config/systemSetting.config");
            sitePath = XmlHelper.Read(cpath, "/systemSetting/sitePath", "");
            defaultTemplate = XmlHelper.Read(cpath, "/systemSetting/defaultTemplate", "");
            //accessFilePath = XmlHelper.Read(cpath, "/systemSetting/accessFilePath", "");
            htmlFilePath = XmlHelper.Read(cpath, "/systemSetting/htmlFilePath", "");

            defaultTemplate = XmlHelper.Read(cpath, "/systemSetting/defaultTemplate", "");
            FileExt = XmlHelper.Read(cpath, "/systemSetting/FileExt", "");
            //databaseType = XmlHelper.Read(cpath, "/systemSetting/databaseType", "");

            //databaseServer = XmlHelper.Read(cpath, "/systemSetting/databaseServer", "");
            //databaseName = XmlHelper.Read(cpath, "/systemSetting/databaseName", "");
            //databaseUser = XmlHelper.Read(cpath, "/systemSetting/databaseUser", "");
            //databasepwd = XmlHelper.Read(cpath, "/systemSetting/databasepwd", "");
            siteNotice = XmlHelper.Read(cpath, "/systemSetting/siteNotice", "");
            siteMode = XmlHelper.Read(cpath, "/systemSetting/siteMode", "");
            switchFaq = XmlHelper.Read(cpath, "/systemSetting/SwitchFaq", "");

            switchComments = XmlHelper.Read(cpath, "/systemSetting/SwitchComments", "");
            switchBBS = XmlHelper.Read(cpath, "/systemSetting/SwitchBBS", "");
            waterMark = XmlHelper.Read(cpath, "/systemSetting/waterMark", "");

            waterMarkFont = XmlHelper.Read(cpath, "/systemSetting/waterMarkFont", "");
            //waterMarkFontSize = XmlHelper.Read(cpath, "/systemSetting/waterMarkFontSize", "");
            //waterMarkFontColor = XmlHelper.Read(cpath, "/systemSetting/waterMarkFontColor", "");
            waterMarkLocation = XmlHelper.Read(cpath, "/systemSetting/waterMarkLocation", "");
            upLoadPath = XmlHelper.Read(cpath, "/systemSetting/upLoadPath", "");
            textFilter = XmlHelper.Read(cpath, "/systemSetting/textFilter", "");
            //DataTable    dt = DBUtility.OleDbHelper.Query("select * from systemSetting").Tables[0];
            //   if (dt.Rows.Count > 0)
            //   {
            //       sitePath = dt.Rows[0]["sitePath"].ToString();
            //       defaultTemplate = dt.Rows[0]["defaultTemplate"].ToString();
            //       //accessFilePath = dt.Rows[0]["accessFilePath"].ToString();
            //       htmlFilePath = dt.Rows[0]["htmlFilePath"].ToString();
            //       FileExt = dt.Rows[0]["FileExt"].ToString();
            //       //databaseType = dt.Rows[0]["databaseType"].ToString();
            //       //databaseServer = dt.Rows[0]["databaseServer"].ToString();
            //       //databaseName = dt.Rows[0]["databaseName"].ToString();
            //       //databaseUser = dt.Rows[0]["databaseUser"].ToString();
            //       //databasepwd = dt.Rows[0]["databasepwd"].ToString();
            //       siteNotice = dt.Rows[0]["siteNotice"].ToString();
            //       siteMode = dt.Rows[0]["siteMode"].ToString();
            //       switchFaq = dt.Rows[0]["SwitchFaq"].ToString();
            //       switchComments = dt.Rows[0]["SwitchComments"].ToString();
            //       switchBBS = dt.Rows[0]["SwitchBBS"].ToString();
            //       waterMark = dt.Rows[0]["waterMark"].ToString();
            //       waterMarkFont = dt.Rows[0]["waterMarkFont"].ToString();
            //       waterMarkLocation = dt.Rows[0]["waterMarkLocation"].ToString();
            //       upLoadPath = dt.Rows[0]["upLoadPath"].ToString();
            //       textFilter = dt.Rows[0]["textFilter"].ToString();
            //       copyRight = dt.Rows[0]["copyRight"].ToString();
            //   }

            cpath = FileOpeartorFunction.GetAbsPath("config/seoSetting.config");
            runMode = XmlHelper.Read(cpath, "/seoSetting/runMode", "") == "1" ? true : false; ;
            additionTitle = XmlHelper.Read(cpath, "/seoSetting/additionTitle", "");
            siteKeyWords = XmlHelper.Read(cpath, "/seoSetting/siteKeyWords", "");
            siteDesc = XmlHelper.Read(cpath, "/seoSetting/siteDesc", "");
            //dt = DBUtility.OleDbHelper.Query("select * from seoSetting").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    runMode = dt.Rows[0]["runMode"].ToString() == "1" ? true : false;
            //    if (runMode == true)
            //    {
            //        runstr = "";
            //    }
            //    else
            //    {
            //        runstr = "index.aspx?";
            //    }
            //    additionTitle = dt.Rows[0]["additionTitle"].ToString();
            //    siteKeyWords = dt.Rows[0]["siteKeyWords"].ToString();
            //    siteDesc = dt.Rows[0]["siteDesc"].ToString();

            //}
            slideImgs = "";
            slideLinks = "";
            slideTexts = "";
            slideWidth = "250";
            slideHeight = "250";
            DataTable dt = DBUtility.OleDbHelper.Query("select * from slide where slideStatus=True ").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                slideImgs += dr["slideImg"].ToString() + "|";
                slideLinks += dr["slideLink"].ToString() + "|";
                slideTexts += dr["slideText"].ToString() + "|";
                slideWidth = dr["slideWidth"].ToString();
                slideHeight = dr["slideHeight"].ToString();
            }
            slideImgs = slideImgs.TrimEnd('|');
            slideLinks = slideLinks.TrimEnd('|');
            slideTexts = slideTexts.TrimEnd('|');
        }

        public void Load(string filePath)
        {
            content = FileOpeartorFunction.loadFile(filePath);
        }


        public void parseTopAndFoot()
        {
            content = content.Replace("{aspcms:top}", FileOpeartorFunction.loadFile("/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/head.html"));
            content = content.Replace("{aspcms:foot}", "<script type=\"text/javascript\" src=\"/" + sitePath + "inc/statistics.ashx\"></script>" + FileOpeartorFunction.loadFile("/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/foot.html", Encoding.Default));
        }

        public void parseAuxiliaryTemplate()
        {
            string labelRuleRuxiliaryTemplate = @"\{aspcms:template(([\s\S]*?))\}";
            regExpObj = new Regex(labelRuleRuxiliaryTemplate);
            MatchCollection mc = regExpObj.Matches(content);
            foreach (Match m in mc)
            {
                srcTemplate = parseArr(m.Groups[1].Value)["src"]; ;
                content = content.Replace("{aspcms:template src=" + srcTemplate + "}", FileOpeartorFunction.loadFile("/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + srcTemplate));
            }
        }

        public void parseGlobal()
        {

            content = content.Replace("{aspcms:sitelogo}", siteLogoUrl);
            content = content.Replace("{aspcms:companyname}", companyName);
            content = content.Replace("{aspcms:additiontitle}", additionTitle);
            content = content.Replace("{aspcms:companyaddress}", companyAddress);
            content = content.Replace("{aspcms:companypostcode}", companyPostCode);
            content = content.Replace("{aspcms:companycontact}", companyContact);
            content = content.Replace("{aspcms:companyphone}", companyPhone);
            content = content.Replace("{aspcms:companymobile}", companyMobile);
            content = content.Replace("{aspcms:companyfax}", companyFax);
            content = content.Replace("{aspcms:companyemail}", companyEmail);
            content = content.Replace("{aspcms:companyicp}", companyICP);
            content = content.Replace("{aspcms:statisticalcode}", statisticalCode);
            content = content.Replace("{aspcms:sitetitle}", siteTitle);
            content = content.Replace("{aspcms:siteurl}", siteUrl);
            content = content.Replace("{aspcms:sitepath}", sitePath);
            content = content.Replace("{aspcms:defaulttemplate}", defaultTemplate);
            content = content.Replace("{aspcms:copyright}", StringUtil.DecodeHtml(copyRight));
            content = content.Replace("{aspcms:sitedesc}", StringUtil.DecodeHtml(siteDesc));
            content = content.Replace("{aspcms:sitenotice}", StringUtil.DecodeHtml(siteNotice));
            content = content.Replace("{aspcms:sitekeywords}", siteKeyWords);
            content = content.Replace("{aspcms:companyqq}", serviceQQ);
            content = content.Replace("{aspcms:floatad}", getFloatAD());
            content = content.Replace("{aspcms:slide}", getSlide());
            content = content.Replace("{aspcms:53kf}", getKf());
            content = content.Replace("images/", "/" + sitePath + "templates/" + defaultTemplate + "/images/");
            content = content.Replace("{aspcms:onlineservice}", getOnlineservice());
        }

        public Dictionary<string, string> parseArr(string attr)
        {
            string[] singleAttr;
            string singleAttrKey = "";
            string singleAttrValue = "";
            string attrStr = regExpReplace(attr, @"[\s]+", ((char)32).ToString()).Trim();
            string[] attrArray = attrStr.Split(new char[] { ((char)32) }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < attrArray.Length; i++)
            {
                singleAttr = attrArray[i].Split(new char[] { (char)61 }, StringSplitOptions.RemoveEmptyEntries);

                if (singleAttr.Length > 1)
                {
                    singleAttrKey = singleAttr[0];
                    singleAttrValue = singleAttr[1];
                    if (strDictionary.ContainsKey(singleAttrKey))
                    {
                        strDictionary[singleAttrKey] = singleAttrValue;
                    }
                    else
                    {
                        strDictionary.Add(singleAttrKey, singleAttrValue);
                    }
                }
            }
            return strDictionary;

        }
        public string regExpReplace(string contentstr, string patternstr, string replacestr)
        {
            regExpObj = new Regex(patternstr);
            return regExpObj.Replace(contentstr, replacestr);

        }

        public string getUrl(string sortStyle, string sortID, string sortUrl)
        {
            if (runMode)
            {
                runstr = "";
            }

            string url = "";
            switch (sortStyle)
            {
                case "0":
                    url = "/" + sitePath + "newslist/" + runstr + sortID + "_1" + FileExt;
                    break;
                case "1":
                    url = "/" + sitePath + "piclist/" + runstr + sortID + "_1" + FileExt;
                    break;
                case "2":
                    url = "/" + sitePath + "about/" + runstr + sortID + FileExt;
                    break;
                case "3":
                    url = "/" + sitePath + "productlist/" + runstr + sortID + "_1" + FileExt;
                    break;
                case "4":
                    url = "/" + sitePath + "downlist/" + runstr + sortID + "_1" + FileExt;
                    break;
                case "6":
                    url = "/" + sitePath + "joblist/" + runstr + sortID + "_1" + FileExt;
                    break;
                default:
                    if (sortUrl.StartsWith("http://"))
                    {
                        url = sortUrl;
                    }
                    else
                    {
                        url = "/" + sitePath + sortUrl;
                    }
                    break;
            }
            return url;
        }

        public void parseNavList(string str)
        {

            if (content.IndexOf(str) < 0)
            {
                return;
            }
            string labelRule = @"{aspcms:" + str + @"navlist([\s\S]*?)}([\s\S]*?){/aspcms:" + str + "navlist}";
            string labelRuleField = @"\[" + str + @"navlist:([\s\S]+?)\]";
            string loopstrLinklistNew = "";
            regExpObj = new Regex(labelRule);
            MatchCollection matchs = regExpObj.Matches(content);
            foreach (Match match in matchs)
            {
                int vnum = -1;
                string labelAttrLinklist = match.Groups[1].Value;
                string loopstrLinklist = match.Groups[2].Value;
                string vtype = "";
                if (parseArr(labelAttrLinklist).ContainsKey("type"))
                    vtype = parseArr(labelAttrLinklist)["type"];

                if (vtype.ToLower() == "all" || vtype.Trim() == "")
                {
                    vtype = "0";
                }
                DataTable linkArray = DBUtility.OleDbHelper.Query("select SortName,SortStyle,SortURL,sortID ,(select count (*) from Aspcms_NewsSort as a where a.ParentID=b.sortID) as subcount from Aspcms_NewsSort as b  where SortStatus and ParentID=" + vtype + " order by SortOrder asc").Tables[0];
                if (linkArray.Rows.Count < 0)
                {
                    vnum = -1;
                }
                else
                {
                    vnum = linkArray.Rows.Count;
                }
                regExpObj = new Regex(labelRuleField);
                MatchCollection matchesfield = regExpObj.Matches(content);
                string loopstrTotal = "";
                string fieldNameAndAttr = "";
                for (int i = 0; i < vnum; i++)
                {
                    int m;
                    string fieldName = "";
                    string fieldAttr = "";
                    loopstrLinklistNew = loopstrLinklist;
                    foreach (Match matchfield in matchesfield)
                    {
                        fieldNameAndAttr = regExpReplace(matchfield.Groups[1].Value, @"[\s]+", ((char)32).ToString());
                        fieldNameAndAttr = fieldNameAndAttr.Trim(new char[] { (char)32 });
                        m = fieldNameAndAttr.IndexOf((char)32); ;
                        if (m > 0)
                        {
                            fieldName = fieldNameAndAttr.Substring(0, m - 1);
                            fieldAttr = fieldNameAndAttr.Substring(fieldNameAndAttr.Length - m);
                        }
                        else
                        {
                            fieldName = fieldNameAndAttr;
                            fieldAttr = "";
                        }
                        switch (fieldName)
                        {
                            case "name":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][0].ToString());
                                break;
                            case "link":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, getUrl(linkArray.Rows[i][1].ToString(), linkArray.Rows[i][3].ToString(), linkArray.Rows[i][2].ToString()));
                                break;
                            case "sortid":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][3].ToString());
                                break;
                            case "subcount":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][4].ToString());
                                break;
                            case "desc":
                                string m_des = StringUtil.DecodeHtml(linkArray.Rows[i][3].ToString());
                                string deslen = parseArr(fieldAttr)["len"].ToString();
                                if (string.IsNullOrEmpty(deslen))
                                {
                                    deslen = "100";
                                }
                                if (m_des.Length > int.Parse(deslen))
                                {
                                    m_des = StringUtil.cutstring(m_des, int.Parse(deslen) - 1);
                                }
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, m_des);
                                break;
                            case "i":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, (i + 1).ToString());
                                break;
                        }
                    }
                    loopstrTotal = loopstrTotal + loopstrLinklistNew;
                }
                content = content.Replace(match.Value, loopstrTotal);
                strDictionary.Clear();
            }
            if (content.IndexOf("{aspcms:subnavlist") > 0)
            {
                parseNavList("sub");
            }

        }

        public void parseLoop(string str)
        {
            string labelRule = "{aspcms:" + str + @"([\s\S]*?)}([\s\S]*?){/aspcms:" + str + "}";
            string labelRuleField = @"\[" + str + @":([\s\S]+?)\]";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string labelStr = match.Groups[1].Value;
                string loopStr = match.Groups[2].Value;
                Dictionary<string, string> labelArr = parseArr(labelStr);
                int lnum = 10;
                string ltype = "";
                string whereType = "";
                string lsort = "";
                string sortStr = "";
                string whereSort = "";
                string lorder = "";
                string orderStr = "";
                string whereTime = "";
                if (!labelArr.ContainsKey("num") || string.IsNullOrEmpty(labelArr["num"]))
                {
                    lnum = 10;
                }
                else
                {
                    lnum = int.Parse(labelArr["num"]);
                }
                if (!labelArr.ContainsKey("type") || string.IsNullOrEmpty(labelArr["type"]))
                {
                    ltype = "all";
                }
                else
                {
                    ltype = labelArr["type"];
                }
                if (ltype != "all")
                {
                    if (int.Parse(ltype) == 1)
                    {
                        whereType = " and len(ImagePath)=0 ";
                    }
                    else if (int.Parse(ltype) == 2)
                    {
                        whereType = " and len(ImagePath)>0";
                    }
                }
                else
                {
                    whereType = "";
                }
                if (!labelArr.ContainsKey("sort") || string.IsNullOrEmpty(labelArr["sort"]))
                {
                    lsort = "all";
                }
                else
                {
                    lsort = labelArr["sort"];
                }
                if (lsort != "all")
                {
                    if (lsort.IndexOf(",") > 0)
                    {
                        string[] lsortlist = lsort.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in lsortlist)
                        {
                            sortStr += CommonFunction.GetSmallestChild("Aspcms_NewsSort", s) + ",";
                        }
                        sortStr = sortStr.Trim(',');
                    }
                    else
                    {
                        sortStr = CommonFunction.GetSmallestChild("Aspcms_NewsSort", lsort);
                    }
                    whereSort = " and SortID in (" + sortStr + ")";
                }
                else
                {
                    whereSort = "";
                }

                if (!labelArr.ContainsKey("order") || string.IsNullOrEmpty(labelArr["order"]))
                {
                    lorder = "time";
                }
                else
                {
                    lorder = labelArr["order"];
                }
                switch (lorder)
                {
                    case "id":
                        orderStr = " order by IsTop,isrecommend,NewsID desc";
                        break;
                    case "visits":
                        orderStr = " order by IsTop,isrecommend,Visits desc";
                        break;
                    case "time":
                        orderStr = " order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "top":
                        orderStr = " order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "recommend":
                        orderStr = " order by  isrecommend,IsTop,AddTime desc";
                        break;
                    case "isrecommend":
                        orderStr = " and isrecommend=true order by IsTop,AddTime desc";
                        break;
                    case "istop":
                        orderStr = " and IsTop=true order by  isrecommend,AddTime desc";
                        break;

                    case "order":
                        orderStr = " order by IsTop,isrecommend, NewsOrder,AddTime desc";
                        break;
                }
                if (labelArr.ContainsKey("time"))
                {
                    switch (labelArr["time"])
                    {
                        case "day": whereTime = " and  DateDiff('d',AddTime,date())=0";
                            break;
                        case "week": whereTime = " and  DateDiff('w',AddTime,date())=0";
                            break;
                        case "month": whereTime = " and  DateDiff('m',AddTime,date())=0";
                            break;
                        default: whereTime = "";
                            break;
                    }
                }
                string Sql = "";
                if (str == "news" || str == "product" || str == "down" || str == "pic")
                {
                    Sql = "select top " + lnum + " * from Aspcms_News where NewsStatus=true " + whereType + whereSort + whereTime + orderStr;

                }
                else if (str == "about")
                {
                    Sql = "select top 1 Content,NewsID,SortID,Title from Aspcms_News where SortID=" + lsort;
                }
                else if (str == "type")
                {
                    Sql = "select SortName,SortURL,SortStyle from Aspcms_NewsSort where  SortID=" + lsort;
                }
                else if (str == "job")
                {
                    Sql = "select top " + lnum + " JobID,SortID,Title,Title2,JobTag,Content,JobStatus,AddTime from Aspcms_Job where JobStatus order by AddTime";
                }
                else if (str == "gbook")
                {
                    Sql = "select top " + lnum + " FaqID,FaqTitle,Contact,ContactWay,Content,Reply,AddTime,ReplyTime,FaqStatus,AuditStatus from Aspcms_Faq where FaqStatus order by AddTime";
                }
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                regExpObj = new Regex(labelRuleField);
                MatchCollection matchesfield = regExpObj.Matches(loopStr);
                string loopstrTotal = "";
                if (dt.Rows.Count > 0)
                {
                    lnum = dt.Rows.Count;
                }
                else
                {
                    lnum = -1;
                }
                string nloopstr, fieldNameArr, fieldName, fieldArr, timestyle;
                int namelen = 8;
                int infolen = 200;
                #region 查找扩展字段
                string sperStr = "";
                string sperCol = "";
                string sortStyle = str;
                DataTable dt1 = DBUtility.OleDbHelper.Query("select SpecField from  Aspcms_SpecSet where SpecType='" + sortStyle + "'   Order by SpecOrder Asc,SpecID").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        sperStr += "," + dt1.Rows[i]["SpecField"].ToString();
                        sperCol += "," + sortStyle + "_" + dt1.Rows[i]["SpecField"].ToString();
                    }
                }
                #endregion
                for (int i = 0; i < lnum; i++)
                {
                    nloopstr = loopStr;
                    foreach (Match matchfield in matchesfield)
                    {
                        fieldNameArr = regExpReplace(matchfield.Groups[1].Value, @"[\s]+", ((char)32).ToString()).Trim();
                        int m = fieldNameArr.IndexOf((char)32);
                        if (m > 0)
                        {
                            fieldName = fieldNameArr.Substring(0, m);
                            fieldArr = fieldNameArr.Substring(m + 1);
                        }
                        else
                        {
                            fieldName = fieldNameArr;
                            fieldArr = "";
                        }

                        #region if (str == "news" || str == "product" || str == "down" || str == "pic")
                        if (str == "news" || str == "product" || str == "down" || str == "pic")
                        {

                            if (dt1.Rows.Count > 0)
                            {
                                string[] sperStrArray = sperStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                string[] sperColArray = sperCol.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                for (int c = 0; c < sperStrArray.Length; c++)
                                {
                                    nloopstr = nloopstr.Replace("[" + str + ":" + sperStrArray[c] + "]", StringUtil.ClearHtmlCode(dt.Rows[i][sperColArray[c]].ToString()));
                                }
                            }

                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    if (dt.Rows[i]["IsOutLink"].ToString() == "1")
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["OutLink"].ToString());
                                    }
                                    else
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt.Rows[i]["SortID"].ToString(), dt.Rows[i]["NewsID"].ToString(), str));
                                    }
                                    break;
                                case "title":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 8;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }
                                    string title = "";

                                    title = StringUtil.cutstring(dt.Rows[i]["Title"].ToString(), namelen);

                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "tag":
                                    Dictionary<string, string> direction1 = parseArr(fieldArr);
                                    if (!direction1.ContainsKey("len") || string.IsNullOrEmpty(direction1["len"]))
                                    {
                                        namelen = 8;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction1["len"]);
                                    }
                                    string title1 = "";

                                    title1 = StringUtil.cutstring(dt.Rows[i]["NewsTag"].ToString(), namelen);

                                    nloopstr = nloopstr.Replace(matchfield.Value, title1);
                                    break;
                                case "titlecolor":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["titlecolor"].ToString());
                                    break;
                                case "istop":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["istop"].ToString());
                                    break;
                                case "isrecommend":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["isrecommend"].ToString());
                                    break;
                                case "desc":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        infolen = 200;
                                    }
                                    else
                                    {
                                        infolen = int.Parse(parseArr(fieldArr)["len"]);
                                    }

                                    nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(StringUtil.DecodeHtml(dt.Rows[i]["Content"].ToString()), "html"), infolen));
                                    break;
                                case "visits":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Visits"].ToString());
                                    break;
                                case "sortname":
                                    nloopstr = nloopstr.Replace(matchfield.Value, plSort(dt.Rows[i]["SortID"].ToString()));
                                    break;
                                case "pic":
                                    if (!string.IsNullOrEmpty(dt.Rows[i]["ImagePath"].ToString()))
                                    {
                                        if (dt.Rows[i]["ImagePath"].ToString().IndexOf("http://") > 0)
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["ImagePath"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["ImagePath"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, "/" + sitePath + "images_sys/nopic.gif");
                                    }
                                    break;
                                case "date":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }
                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                                default:
                                    if (dt.Columns.Contains(fieldName))
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i][fieldName].ToString());
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #region else if (str == "type")
                        else if (str == "type")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    nloopstr = nloopstr.Replace(matchfield.Value, getUrl(dt.Rows[i]["SortStyle"].ToString(), lsort, dt.Rows[i]["SortURL"].ToString()));
                                    break;
                                case "name":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 200;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(parseArr(fieldArr)["len"]);
                                    }
                                    nloopstr = nloopstr.Replace(matchfield.Value, Common.StringUtil.cutstring(dt.Rows[i]["SortName"].ToString(), namelen));
                                    break;
                            }
                        }
                        #endregion

                        #region else if (str == "about")
                        else if (str == "about")
                        {
                            switch (fieldName)
                            {
                                case "info":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        infolen = 200;
                                    }
                                    else
                                    {
                                        infolen = int.Parse(parseArr(fieldArr)["len"]);
                                    }
                                    nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(StringUtil.ClearHtmlCode(StringUtil.DecodeHtml(dt.Rows[i]["Content"].ToString())), "html"), infolen));
                                    break;
                                case "link":
                                    break;
                                case "title":
                                    break;
                            }
                        }
                        #endregion

                        #region  else if (str == "job")
                        else if (str == "job")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt.Rows[i]["SortID"].ToString(), dt.Rows[i]["JobID"].ToString(), str));
                                    break;
                                case "title":
                                    string title = "";
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 15;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }
                                    title = StringUtil.cutstring(dt.Rows[i]["Title"].ToString(), namelen);
                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "name":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Contact"].ToString());
                                    break;
                                case "status":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["JobStatus"].ToString());
                                    break;
                                case "winfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Content"].ToString());
                                    break;
                                case "wdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "mm-dd";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }

                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #region  else if (str == "gbook")
                        else if (str == "gbook")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    //                                'if rsObj(5)=1 then nloopstr = replace(nloopstr,matchfield.value,rsObj(9)) : else nloopstr = replace(nloopstr,matchfield.value,getShowLink(DateArray(0,i),DateArray(0,i),showType))
                                    break;
                                case "title":
                                    string title = "";
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 15;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }

                                    title = StringUtil.cutstring(dt.Rows[i]["FaqTitle"].ToString(), namelen);


                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "name":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Contact"].ToString());
                                    break;
                                case "status":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["FaqStatus"].ToString());
                                    break;
                                case "winfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Content"].ToString());
                                    break;
                                case "rinfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Reply"].ToString());
                                    break;
                                case "wdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }

                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                                case "rdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }
                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                            }
                        }
                        #endregion
                    }
                    loopstrTotal = loopstrTotal + nloopstr;
                }
                content = content.Replace(match.Value, loopstrTotal);
                strDictionary.Clear();
            }
        }

        public void parseAd(string str)
        {
            string labelRule = "{aspcms:" + str + @"([\s\S]*?)}([\s\S]*?){/aspcms:" + str + "}";
            string labelRuleField = @"\[" + str + @":([\s\S]+?)\]";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string labelStr = match.Groups[1].Value;
                string loopStr = match.Groups[2].Value;
                Dictionary<string, string> labelArr = parseArr(labelStr);
                string lsort = "";
                if (!labelArr.ContainsKey("id") || string.IsNullOrEmpty(labelArr["id"]))
                {
                    lsort = "0";
                }
                else
                {
                    lsort = labelArr["id"];
                }
                string Sql = "select top 1 AdID,Title,Content from Aspcms_Ad where ADStatus=true and AdID=" + lsort;
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    content = content.Replace(match.Value, dt.Rows[0]["Content"].ToString());
                }
                else
                {
                    content = content.Replace(match.Value, "<!--此处广告不存在或都禁用，广告：" + lsort + "-->");
                }
            }
        }




        public string getShowLink(string SortID, string Id, string ShowType)
        {
            if (runMode)
            {
                runstr = "";
            }
            return "/" + sitePath + ShowType + "/" + runstr + SortID + "_" + Id + FileExt;
        }

        public void parseList(string typeIds, int currentPage, string pageListType, string keys, string sortStyle)
        {
            string labelRule = "{aspcms:" + pageListType + @"([\s\S]*?)}([\s\S]*?){/aspcms:" + pageListType + "}";
            string labelRuleField = @"\[" + pageListType + @":([\s\S]+?)\]";
            string labelRulePagelist = @"\[" + pageListType + @":pagenumber([\s\S]*?)\]";
            string orderStr = "";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string labelStr = match.Groups[1].Value;
                string loopStr = match.Groups[2].Value;
                Dictionary<string, string> labelArr = parseArr(labelStr);
                int lsize = 0;
                if (string.IsNullOrEmpty(labelArr["size"]))
                {
                    lsize = 12;
                }
                else
                {
                    lsize = int.Parse(labelArr["size"]);
                }
                string lorder = "";
                string orderAsc = "";

                if (!labelArr.ContainsKey("order") || string.IsNullOrEmpty(labelArr["order"]))
                {
                    lorder = "time";
                }
                else
                {
                    lorder = labelArr["order"];
                }

                switch (lorder)
                {
                    case "id":
                        orderStr = " order by IsTop,isrecommend,newsID desc";
                        break;
                    case "visits":
                        orderStr = " order by IsTop,isrecommend,visits,newsID desc";
                        break;
                    case "time":
                        orderStr = " order by IsTop,isrecommend,AddTime desc,newsID desc";
                        break;
                    case "order":
                        orderStr = " order by IsTop,isrecommend, NewsOrder " + orderAsc + ",AddTime desc,newsID desc";
                        break;
                    default:
                        orderStr = " order by AddTime desc";
                        break;
                }
                labelArr = null;
                string sperStr = "";
                string sperCol = "";
                string Sql = "";
                string SqlCount = "";

                #region 查找扩展字段
                DataTable dt = DBUtility.OleDbHelper.Query("select SpecField from  Aspcms_SpecSet where SpecType='" + sortStyle + "'   Order by SpecOrder Asc,SpecID").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sperStr += "," + dt.Rows[i]["SpecField"].ToString();
                        sperCol += "," + sortStyle + "_" + dt.Rows[i]["SpecField"].ToString();
                    }
                }
                #endregion

                #region if (pageListType.ToLower().Trim() == "newslist" || pageListType.ToLower().Trim() == "productlist" || pageListType.ToLower().Trim() == "downlist" || pageListType.ToLower().Trim() == "piclist" || pageListType.ToLower().Trim() == "searchlist")
                if (pageListType.ToLower().Trim() == "newslist" || pageListType.ToLower().Trim() == "productlist" || pageListType.ToLower().Trim() == "downlist" || pageListType.ToLower().Trim() == "piclist" || pageListType.ToLower().Trim() == "searchlist")
                {
                    if (string.IsNullOrEmpty(keys))
                    {
                        if (pageListType.ToLower().Trim() != "searchlist")
                        {
                            if (currentPage == 1)
                            {
                                Sql = "select top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") " + orderStr;
                                SqlCount = "select count(1) from Aspcms_News where NewsStatus and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") ";
                            }
                            else
                            {
                                Sql = "select  top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") and NewsID not in(select top " + lsize * (currentPage - 1) + " NewsID from  Aspcms_News where NewsStatus  and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") " + orderStr + ") " + orderStr;
                                SqlCount = "select count(1) from Aspcms_News where NewsStatus and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") ";
                            }
                        }
                        else
                        {
                            if (currentPage == 1)
                            {
                                Sql = "select top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and  SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  " + orderStr;
                                SqlCount = "select count(1) from Aspcms_News where NewsStatus and  SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  ";
                            }
                            else
                            {
                                Sql = "select  top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and  SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  and NewsID not in(select top " + lsize * (currentPage - 1) + " NewsID from  Aspcms_News where NewsStatus  and  SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  " + orderStr + ") " + orderStr;
                                SqlCount = "select count(1) from Aspcms_News where NewsStatus and  SortID in (select sortid from Aspcms_NewsSort where SortStyle=3) ";
                            }
                        }
                    }
                    else
                    {
                        if (currentPage == 1)
                        {
                            Sql = "select  top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and Title like '%" + keys + "%' and SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  " + orderStr;
                            SqlCount = "select  count(1) from Aspcms_News where NewsStatus and Title like '%" + keys + "%' and SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  ";
                        }
                        else
                        {
                            Sql = "select  top " + lsize + " NewsID,Title,Title2,TitleColor,ImagePath,Content,NewsTag,IsOutLink,DownURL,Visits,AddTime,SortID,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_News where NewsStatus and Title like '%" + keys + "%' and SortID in (select sortid from Aspcms_NewsSort where SortStyle=3) and  NewsID not in(select top " + lsize * (currentPage - 1) + " NewsID from  Aspcms_News where NewsStatus  and Title like '%" + keys + "%'  and SortID in (select sortid from Aspcms_NewsSort where SortStyle=3) " + orderStr + ") " + orderStr;
                            SqlCount = "select  count(1) from Aspcms_News where NewsStatus and Title like '%" + keys + "%' and SortID in (select sortid from Aspcms_NewsSort where SortStyle=3)  ";
                        }
                    }
                    // System.Web.HttpContext.Current.Response.Write(Sql+SqlCount);

                }
                #endregion

                #region else if (pageListType.ToLower().Trim() == "gbooklist")
                else if (pageListType.ToLower().Trim() == "gbooklist")
                {
                    switch (lorder)
                    {
                        case "id":
                            orderStr = " order by FaqID desc";
                            break;
                        case "time":
                            orderStr = " order by AddTime desc";
                            break;
                        default:
                            orderStr = " order by FaqID desc";
                            break;
                    }
                    if (currentPage == 1)
                    {
                        Sql = "select  top " + lsize + "  FaqID,FaqTitle,Contact,ContactWay,Content,Reply,AddTime,ReplyTime,FaqStatus,AuditStatus from Aspcms_Faq where FaqStatus " + orderStr;
                        SqlCount = "select count(1) from Aspcms_Faq where FaqStatus ";
                    }
                    else
                    {
                        Sql = "select  top " + lsize + "  FaqID,FaqTitle,Contact,ContactWay,Content,Reply,AddTime,ReplyTime,FaqStatus,AuditStatus from Aspcms_Faq where FaqStatus and FaqID not in(select top " + lsize * (currentPage - 1) + " FaqID from Aspcms_Faq where FaqStatus " + orderStr + " ) " + orderStr;
                        SqlCount = "select count(1) from Aspcms_Faq where FaqStatus ";
                    }
                }
                #endregion

                #region else if (pageListType.ToLower().Trim() == "joblist")
                else if (pageListType.ToLower().Trim() == "joblist")
                {
                    switch (lorder)
                    {
                        case "id":
                            orderStr = " order by JobID desc";
                            break;
                        case "time":
                            orderStr = " order by AddTime desc";
                            break;
                        default:
                            orderStr = " order by JobID desc";
                            break;
                    }
                    if (string.IsNullOrEmpty(keys))
                    {
                        if (currentPage == 1)
                        {
                            Sql = "select  top " + lsize + " JobID,Title,TitleColor,ImagePath,Content,IsOutLink,Visits,SortID,AddTime,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_Job where JobStatus=True  and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ")" + orderStr;
                            SqlCount = "select  count(1) from Aspcms_Job where JobStatus=True ";
                        }
                        else
                        {
                            Sql = "select  top " + lsize + " JobID,Title,TitleColor,ImagePath,Content,IsOutLink,Visits,SortID,AddTime,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_Job where JobStatus=True   and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") and  JobID not in(select top " + lsize * (currentPage - 1) + " JobID from  Aspcms_Job where JobStatus=True   and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") " + orderStr + ") " + orderStr;
                            SqlCount = "select  count(1) from Aspcms_Job where JobStatus=True  ";
                        }
                    }
                    else
                    {
                        if (currentPage == 1)
                        {
                            Sql = "select  top " + lsize + " JobID,Title,TitleColor,ImagePath,Content,IsOutLink,Visits,SortID,AddTime,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_Job where JobStatus  and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") and Title like '%" + keys + "%'  " + orderStr;
                            SqlCount = "select  count(1) from Aspcms_Job where JobStatus=True and Title like '%" + keys + "%' ";
                        }
                        else
                        {
                            Sql = "select  top " + lsize + " JobID,Title,TitleColor,ImagePath,Content,IsOutLink,Visits,SortID,AddTime,OutLink,IsTop,isrecommend " + sperCol + " from Aspcms_Job where JobStatus=True  and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") and Title like '%" + keys + "%'   and  JobID not in(select top " + lsize * (currentPage - 1) + " JobID from  Aspcms_Job where JobStatus=True   and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", typeIds) + ") and Title like '%" + keys + "%' ) " + orderStr + ") " + orderStr;
                            SqlCount = "select  count(1) from Aspcms_Job where JobStatus=True and Title like '%" + keys + "%'  ";
                        }
                    }
                }
                #endregion

                regExpObj = new Regex(labelRuleField);
                MatchCollection matchesfield = regExpObj.Matches(loopStr);
                string loopstrTotal, nloopstr, fieldNameArr, fieldName, fieldArr, timestyle;
                int m = 0;
                int infolen = 0;
                int currentrow = 0;
                int namelen = 0;
                int SumCount = int.Parse(DBUtility.OleDbHelper.GetSingle(SqlCount).ToString());
                int pageCount = 1;
                if (SumCount % lsize == 0)
                {
                    pageCount = SumCount / lsize;
                }
                else
                {
                    pageCount = SumCount / lsize + 1;
                }
                DataTable dt1 = DBUtility.OleDbHelper.Query(Sql).Tables[0];

                #region if (dt1.Rows.Count <= 0)
                if (dt1.Rows.Count <= 0)
                {
                    if (string.IsNullOrEmpty(keys))
                    {
                        if (pageListType == "gbooklist")
                        {
                            loopstrTotal = "暂无留言！";
                        }
                        else if (pageListType == "joblist")
                        {
                            loopstrTotal = "暂无招聘信息！";
                        }
                        else
                        {
                            loopstrTotal = "对不起，该分类无任何记录";
                        }
                    }
                    else
                    {
                        loopstrTotal = "对不起，关键字 <font color='red'>" + keys + "</font> 无任何记录";
                    }
                }
                #endregion

                #region else
                else
                {
                    loopstrTotal = "";
                    #region
                    for (int i = 1; i <= lsize; i++)
                    {
                        nloopstr = loopStr;
                        foreach (Match matchfield in matchesfield)
                        {

                            fieldNameArr = regExpReplace(matchfield.Groups[1].Value, @"[\s]+", ((char)32).ToString()).Trim();
                            m = fieldNameArr.IndexOf((char)32);
                            if (m > 0)
                            {
                                fieldName = fieldNameArr.Substring(0, m);
                                fieldArr = fieldNameArr.Substring(m + 1);
                            }
                            else
                            {
                                fieldName = fieldNameArr;
                                fieldArr = "";
                            }
                            #region if (pageListType.ToLower().Trim() == "newslist" || pageListType.ToLower().Trim() == "productlist" || pageListType.ToLower().Trim() == "downlist" || pageListType.ToLower().Trim() == "piclist" || pageListType.ToLower().Trim() == "searchlist")
                            if (pageListType.ToLower().Trim() == "newslist" || pageListType.ToLower().Trim() == "productlist" || pageListType.ToLower().Trim() == "downlist" || pageListType.ToLower().Trim() == "piclist" || pageListType.ToLower().Trim() == "searchlist")
                            {
                                if (pageListType.ToLower().Trim() == "productlist" || pageListType.ToLower().Trim() == "newslist" || pageListType.ToLower().Trim() == "searchlist")
                                {
                                    if (dt1.Rows.Count > 0)
                                    {
                                        string[] sperStrArray = sperStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        string[] sperColArray = sperCol.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                        for (int c = 0; c < sperStrArray.Length; c++)
                                        {
                                            nloopstr = nloopstr.Replace("[" + pageListType + ":" + sperStrArray[c] + "]", StringUtil.ClearHtmlCode(dt1.Rows[currentrow][sperColArray[c]].ToString()));
                                        }
                                    }
                                }

                                switch (fieldName)
                                {
                                    case "i":
                                        nloopstr = nloopstr.Replace(matchfield.Value, i.ToString()); break;
                                    case "link":
                                        if (dt1.Rows[currentrow][5].ToString() == "1")
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["OutLink"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt1.Rows[currentrow]["SortID"].ToString(), dt1.Rows[currentrow]["NewsID"].ToString(), sortStyle));
                                        }
                                        break;
                                    case "title":
                                        Dictionary<string, string> direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 8;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        string title = "";

                                        title = StringUtil.cutstring(dt1.Rows[currentrow]["Title"].ToString(), namelen);

                                        nloopstr = nloopstr.Replace(matchfield.Value, title);
                                        break;
                                    case "desc":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 100;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        string desc = "";

                                        desc = StringUtil.cutstring(StringUtil.FilterStr(StringUtil.DecodeHtml(dt1.Rows[currentrow]["Content"].ToString()), "html"), namelen);

                                        nloopstr = nloopstr.Replace(matchfield.Value, desc);
                                        break;
                                    case "tag":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 100;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        string tag = "";

                                        tag = StringUtil.DecodeHtml(dt1.Rows[currentrow]["NewsTag"].ToString());

                                        nloopstr = nloopstr.Replace(matchfield.Value, tag);
                                        break;
                                    case "titlecolor":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["TitleColor"].ToString()); break;
                                    case "author":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Author"].ToString()); break;
                                    case "source":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["NewsSource"].ToString()); break;
                                    case "istop":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["istop"].ToString()); break;
                                    case "isrecommend":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["isrecommend"].ToString()); break;
                                    case "sortname":
                                        nloopstr = nloopstr.Replace(matchfield.Value, plSort(dt1.Rows[currentrow]["SortID"].ToString())); break;

                                    case "info":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            infolen = 8;
                                        }
                                        else
                                        {
                                            infolen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(dt1.Rows[currentrow]["Content"].ToString(), "html"), infolen));
                                        break;
                                    case "pic":
                                        if (dt1.Rows[currentrow]["ImagePath"].ToString().Trim() != "")
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["ImagePath"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, "/" + sitePath + "images_sys/nopic.gif");
                                        }
                                        break;
                                    case "visits":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Visits"].ToString()); break;
                                    case "typename":
                                        nloopstr = nloopstr.Replace(matchfield.Value, plSort(dt1.Rows[currentrow]["SortID"].ToString()));
                                        break;
                                    case "downurl":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["DownURL"].ToString()); break;

                                    case "date":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                        {
                                            timestyle = "m-d";
                                        }
                                        else
                                        {
                                            timestyle = parseArr(fieldArr)["style"];
                                        }
                                        switch (timestyle)
                                        {
                                            case "yy-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("yy-m-d")); break;
                                            case "y-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("y-m-d")); ; break;
                                            case "m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("m-d")); break;
                                            default:
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString(timestyle)); break;
                                        }
                                        break;
                                    default:

                                        break;
                                }
                            }
                            #endregion

                            #region  else if (pageListType == "gbooklist")
                            else if (pageListType == "gbooklist")
                            {
                                switch (fieldName)
                                {
                                    case "i":
                                        nloopstr = nloopstr.Replace(matchfield.Value, i.ToString());
                                        break;
                                    case "link":
                                        if (dt1.Rows[currentrow]["Reply"].ToString() == "1")
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["AuditStatus"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt1.Rows[currentrow]["ReplyTime"].ToString(), dt1.Rows[currentrow]["FaqID"].ToString(), sortStyle));
                                        }
                                        break;
                                    case "title":
                                        string title = "";
                                        Dictionary<string, string> direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 8;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        title = StringUtil.cutstring(dt1.Rows[currentrow]["FaqTitle"].ToString(), namelen);


                                        nloopstr = nloopstr.Replace(matchfield.Value, title);
                                        break;

                                    case "name":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Contact"].ToString());
                                        break;
                                    case "status":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["AuditStatus"].ToString());
                                        break;
                                    case "winfo":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Content"].ToString());
                                        break;
                                    case "rinfo":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Reply"].ToString());
                                        break;
                                    case "wdate":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                        {
                                            timestyle = "m-d";
                                        }
                                        else
                                        {
                                            timestyle = parseArr(fieldArr)["style"];
                                        }
                                        switch (timestyle)
                                        {
                                            case "yyyy-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("yy-m-d"));
                                                break;
                                            case "yy-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("y-m-d"));
                                                break;
                                            case "m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("m-d"));
                                                break;
                                            default:
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString(timestyle)); break;
                                        }
                                        break;
                                    case "rdate":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                        {
                                            timestyle = "m-d";
                                        }
                                        else
                                        {
                                            timestyle = parseArr(fieldArr)["style"];
                                        }
                                        switch (timestyle)
                                        {
                                            case "yy-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["ReplyTime"].ToString()).ToString("yy-m-d"));
                                                break;
                                            case "y-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["ReplyTime"].ToString()).ToString("y-m-d"));
                                                break;
                                            case "m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["ReplyTime"].ToString()).ToString("m-d"));
                                                break;
                                            default:
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["ReplyTime"].ToString()).ToString(timestyle)); break;
                                        }
                                        break;
                                }
                            }
                            #endregion

                            #region else if (pageListType == "joblist")
                            else if (pageListType == "joblist")
                            {
                                switch (fieldName)
                                {
                                    case "i":
                                        nloopstr = nloopstr.Replace(matchfield.Value, i.ToString());
                                        break;
                                    case "link":
                                        if (dt1.Rows[currentrow]["IsOutLink"].ToString() == "1")
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["OutLink"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt1.Rows[currentrow]["SortID"].ToString(), dt1.Rows[currentrow]["JobID"].ToString(), sortStyle));
                                        }
                                        break;
                                    case "title":
                                        Dictionary<string, string> direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 8;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        string title = "";

                                        title = StringUtil.cutstring(dt1.Rows[currentrow]["Title"].ToString(), namelen);

                                        nloopstr = nloopstr.Replace(matchfield.Value, title);
                                        break;
                                    case "desc":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            namelen = 100;
                                        }
                                        else
                                        {
                                            namelen = int.Parse(parseArr(fieldArr)["len"]);
                                        }

                                        string desc = "";

                                        desc = StringUtil.cutstring(StringUtil.FilterStr(StringUtil.DecodeHtml(dt1.Rows[currentrow]["Content"].ToString()), "html"), namelen);

                                        nloopstr = nloopstr.Replace(matchfield.Value, desc);
                                        break;
                                    case "titlecolor":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["TitleColor"].ToString()); break;
                                    case "istop":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["istop"].ToString()); break;
                                    case "isrecommend":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["isrecommend"].ToString()); break;
                                    case "info":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                        {
                                            infolen = 8;
                                        }
                                        else
                                        {
                                            infolen = int.Parse(parseArr(fieldArr)["len"]);
                                        }
                                        nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(dt1.Rows[currentrow]["Content"].ToString(), "html"), infolen));
                                        break;
                                    case "pic":
                                        if (dt1.Rows[currentrow]["ImagePath"].ToString().Trim() != "")
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["ImagePath"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, "/" + sitePath + "images_sys/nopic.gif");
                                        }
                                        break;
                                    case "visits":
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt1.Rows[currentrow]["Visits"].ToString()); break;
                                    case "date":
                                        direction = parseArr(fieldArr);
                                        if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                        {
                                            timestyle = "m-d";
                                        }
                                        else
                                        {
                                            timestyle = parseArr(fieldArr)["style"];
                                        }
                                        switch (timestyle)
                                        {
                                            case "yy-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("yy-m-d")); break;
                                            case "y-m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("y-m-d")); ; break;
                                            case "m-d":
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString("m-d")); break;
                                            default:
                                                nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt1.Rows[currentrow]["AddTime"].ToString()).ToString(timestyle)); break;
                                        }
                                        break;
                                }
                            }
                            #endregion


                        }
                        loopstrTotal = loopstrTotal + nloopstr;
                        currentrow++;
                        if (dt1.Rows.Count <= currentrow)
                        {
                            break;
                        }
                    }
                    #endregion
                }
                #endregion

                content = content.Replace(match.Value, loopstrTotal);
                regExpObj = new Regex(labelRulePagelist);
                MatchCollection matchesPagelist = regExpObj.Matches(content);
                foreach (Match matchPagelist in matchesPagelist)
                {
                    if (dt1.Rows.Count <= 0)
                    {
                        content = content.Replace(matchPagelist.Value, "");
                    }
                    else
                    {
                        int lenPagelist;
                        Dictionary<string, string> direction = parseArr(matchPagelist.Groups[0].Value);
                        if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                        {
                            lenPagelist = 10;
                        }
                        else
                        {
                            lenPagelist = int.Parse(parseArr(matchPagelist.Groups[1].Value)["len"]);
                        }
                        string TypeId = "";
                        if (typeIds.IndexOf(",") > 0)
                        {
                            TypeId = typeIds.Split(',')[0];
                        }
                        else
                        {
                            TypeId = typeIds;
                        }
                        string strPagelist = pageNumberLinkInfo(currentPage, lenPagelist, pageCount, pageListType, TypeId);
                        content = content.Replace(matchPagelist.Value, strPagelist);
                    }
                }
                strDictionary.Clear();
            }
        }
        public void parseLinkList()
        {
            if (content.IndexOf("{aspcms:linklist") <= 0)
            {
                return;
            }
            string labelRule = @"{aspcms:linklist([\s\S]*?)}([\s\S]*?){/aspcms:linklist}";
            string labelRuleField = @"\[linklist:([\s\S]+?)\]";
            string fieldNameAndAttr = "";
            string fieldAttr = "";
            string fieldName = "";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string labelAttrLinklist = match.Groups[1].Value;
                string loopstrLinklist = match.Groups[2].Value;
                string vtype = "";// parseArr(labelAttrLinklist)["type"];
                string whereStr = "";
                if (string.IsNullOrEmpty(parseArr(labelAttrLinklist)["type"]))
                {
                    vtype = "0";
                }
                else
                {
                    vtype = parseArr(labelAttrLinklist)["type"];
                }
                switch (vtype)
                {
                    case "font":
                        whereStr = (char)32 + "LinkType=0 and LinkStatus" + (char)32;
                        break;
                    case "pic":
                        whereStr = (char)32 + "LinkType=1 and LinkStatus" + (char)32;
                        break;
                    default:
                        whereStr = (char)32 + "LinkStatus" + (char)32;
                        break;
                }

                DataTable linkArray = DBUtility.OleDbHelper.Query("select LinkText,ImageURL,LinkURL,LinkDesc from Aspcms_Links  where " + whereStr + " order by LinkOrder asc").Tables[0];
                regExpObj = new Regex(labelRuleField);
                MatchCollection matchesfield = regExpObj.Matches(loopstrLinklist);
                string loopstrTotal = "";
                for (int i = 0; i < linkArray.Rows.Count; i++)
                {
                    string loopstrLinklistNew = loopstrLinklist;
                    foreach (Match matchfield in matchesfield)
                    {

                        fieldNameAndAttr = matchfield.Groups[1].Value.Replace(@"[\s]+", ((char)32).ToString()).Trim();
                        int m = fieldNameAndAttr.IndexOf((char)32);
                        if (m > 0)
                        {
                            fieldName = fieldNameAndAttr.Substring(0, m - 1);
                            fieldAttr = fieldNameAndAttr.Substring(fieldNameAndAttr.Length - m);
                        }
                        else
                        {
                            fieldName = fieldNameAndAttr;
                            fieldAttr = "";
                        }
                        switch (fieldName)
                        {
                            case "name":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][0].ToString());
                                break;
                            case "link":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][2].ToString());
                                break;
                            case "pic":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray.Rows[i][1].ToString());
                                break;
                            case "des":
                                string m_des = StringUtil.DecodeHtml(linkArray.Rows[i][3].ToString());
                                int deslen = 0;
                                if (string.IsNullOrEmpty(parseArr(fieldAttr)["len"]))
                                {
                                    deslen = 100;
                                }
                                else
                                {
                                    deslen = int.Parse(parseArr(fieldAttr)["len"]);
                                }
                                if (m_des.Length > deslen)
                                {
                                    m_des = StringUtil.cutstring(m_des, deslen - 1);
                                }
                                break;
                            case "i":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, (i + 1).ToString());
                                break;
                        }

                    }
                    loopstrTotal = loopstrTotal + loopstrLinklistNew;
                }
                content = content.Replace(match.Value, loopstrTotal);
                strDictionary.Clear();
            }
        }

        public void parseIf()
        {
            if (content.IndexOf("{if:") < 0)
            {
                return;
            }
            string labelRule = @"{if:([\s\S]+?)}([\s\S]*?){end\s+if}";
            string labelRule2 = "{elseif";
            string labelRule3 = "{else}";
            bool elseIfFlag = false;
            string strIf = "";
            string strThen = "";
            string resultStr = "";
            int elseIfLen = 1;
            regExpObj = new Regex(labelRule);
            MatchCollection matchesIf = regExpObj.Matches(content);
            foreach (Match matchIf in matchesIf)
            {
                strIf = matchIf.Groups[1].Value;
                strThen = matchIf.Groups[2].Value;
                if (strThen.IndexOf(labelRule2) > 0)
                {

                    string[] elseIfArray = strThen.Split(new string[] { labelRule2 }, StringSplitOptions.RemoveEmptyEntries);
                    int elseIfArrayLen = elseIfArray.Length;
                    string[] elseIfSubArray = elseIfArray[elseIfArrayLen - 1].Split(new string[] { labelRule3 }, StringSplitOptions.RemoveEmptyEntries);

                    resultStr = elseIfSubArray[1];
                    if (parseToBool(strIf))
                    {
                        resultStr = elseIfArray[0];
                    }
                    for (elseIfLen = 1; elseIfLen < elseIfArray.Length; elseIfLen++)
                    {
                        string strElseIf = getSubStrByFromAndEnd(elseIfArray[elseIfLen], ":", "}", "");
                        string strElseIfThen = getSubStrByFromAndEnd(elseIfArray[elseIfLen], "}", "", "start");
                        if (parseToBool(strElseIf))
                        {
                            resultStr = strElseIfThen;
                            elseIfFlag = true;
                        }
                        else
                        {
                            elseIfFlag = false;
                        }
                        if (elseIfFlag)
                        {
                            break;
                        }

                    }
                    if (parseToBool(getSubStrByFromAndEnd(elseIfSubArray[0], ":", "}", "")))
                    {
                        resultStr = getSubStrByFromAndEnd(elseIfSubArray[0], "}", "", "start");
                    }
                    else
                    {
                        elseIfFlag = true;
                    }

                    content = content.Replace(matchIf.Value, resultStr);
                }
                else
                {
                    bool ifFlag = false;
                    if (strThen.IndexOf("{else}") > 0)
                    {
                        string strThen1 = strThen.Split(new string[] { labelRule3 }, StringSplitOptions.RemoveEmptyEntries)[0];
                        string strElse1 = strThen.Split(new string[] { labelRule3 }, StringSplitOptions.RemoveEmptyEntries)[1];
                        if (parseToBool(strIf))
                        {
                            ifFlag = true;
                        }
                        else
                        {
                            ifFlag = false;
                        }

                        if (ifFlag)
                        {
                            content = content.Replace(matchIf.Value, strThen1);
                        }
                        else
                        {
                            content = content.Replace(matchIf.Value, strElse1);
                        }
                    }
                    else
                    {
                        if (parseToBool(strIf))
                        {
                            ifFlag = true;
                        }
                        else
                        {
                            ifFlag = false;
                        }
                        if (ifFlag)
                        {
                            content = content.Replace(matchIf.Value, strThen);
                        }
                        else
                        {
                            content = content.Replace(matchIf.Value, "");
                        }
                    }
                }
            }
        }
        public string getSubStrByFromAndEnd(string str, string startStr, string endStr, string operType)
        {
            int location1;
            int location2;
            switch (operType)
            {
                case "start":
                    location1 = str.IndexOf(startStr) + startStr.Length;
                    location2 = str.Length + 1;

                    break;
                case "end":
                    location1 = 1;
                    location2 = str.IndexOf(endStr);

                    break;
                default:
                    location1 = str.IndexOf(startStr) + startStr.Length;
                    location2 = str.IndexOf(endStr);
                    break;
            }
            return str.Substring(location1, location2 - location1);

        }

        public static object praseToObj(string str)
        {
            if (str.IndexOf("%") > 0)
            {
                try
                {
                    string[] arr = str.Split(new string[] { "%" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    return (v1 % v2).ToString();
                }
                catch
                {
                    return str;
                }
            }
            
            else
            {
                return str;
            }

        }
        public static bool parseToBool(string str)
        {
            try
            {

                if (str.IndexOf(">=") > 0)
                {
                    string[] arr = str.Split(new string[] { ">=" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 >= v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.IndexOf("=>") > 0)
                {
                    string[] arr = str.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 >= v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.IndexOf(">") > 0)
                {
                    string[] arr = str.Split('>');
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 > v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (str.IndexOf("<=") > 0)
                {
                    string[] arr = str.Split(new string[] { "<=" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 <= v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.IndexOf("=<") > 0)
                {
                    string[] arr = str.Split(new string[] { "=<" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 <= v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.IndexOf("<") > 0)
                {
                    string[] arr = str.Split(new string[] { "<" }, StringSplitOptions.RemoveEmptyEntries);
                    decimal v1 = decimal.Parse(praseToObj(arr[0]).ToString());
                    decimal v2 = decimal.Parse(praseToObj(arr[1]).ToString());
                    if (v1 < v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.IndexOf("=") > 0)
                {
                    string[] arr = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    string v1 = praseToObj(arr[0]).ToString();
                    string v2 = praseToObj(arr[1]).ToString();
                    if (v1 == v2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (str.ToUpper() == "TRUE")
                {
                    return true;
                }
                else if (decimal.Parse(str) > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            return false;
        }
        //public static void parseGbook()
        //{
        //    string gbook = "";
        //    gbook = "<div id=\"faqbox\">" + "\r\n" +
        //    "<form action=\"save.asp?action=add\" method=\"post\">" + "\r\n" +
        //    "    <div class=\"faqline\">" + "\r\n" +
        //    "        <span class=\"faqtit\">问题：</span>" + "\r\n" +
        //    "        <input name=\"FaqTitle\" type=\"text\" /><font color=\"#FF0000\">*</font>" + "\r\n" +
        //    "    </div>    " + "\r\n" +
        //    "    <div class=\"Content\">" + "\r\n" +
        //    "        <span class=\"faqtit\">内容：</span>" + "\r\n" +
        //    "        <textarea name=\"Content\" cols=\"60\" rows=\"5\"></textarea><font color=\"#FF0000\">*</font>" + "\r\n" +
        //    "    </div>" + "\r\n" +
        //    "   <div class=\"faqline\">" + "\r\n" +
        //    "        <span class=\"faqtit\">联系人：</span>" + "\r\n" +
        //    "        <input name=\"Contact\" type=\"text\" /><font color=\"#FF0000\">*</font>" + "\r\n" +
        //    "    </div>" + "\r\n" +
        //    "   <div class=\"faqline\">" + "\r\n" +
        //    "        <span class=\"faqtit\">联系方式：</span>" + "\r\n" +
        //    "        <input name=\"ContactWay\" type=\"text\" /> <font color=\"#FF0000\">*</font> 请注明是手机、电话、QQ、Email,方便我们和您联系" + "\r\n" +
        //    "    </div>" + "\r\n" +
        //    "  <div class=\"faqline\">" + "\r\n" +
        //    "        <span class=\"faqtit\">验证码：</span>" + "\r\n" +
        //    "        <input name=\"code\" type=\"text\" class=\"login_verification\" id=\"verification\" size=\"6\" maxlength=\"6\"/><font color=\"#FF0000\">*</font>" + "\r\n" +
        //    "        <img src=\"../inc/checkcode.asp\" alt=\"看不清验证码?点击刷新!\" onClick=\"this.src='../inc/checkcode.asp'\" />" + "\r\n" +
        //    "    </div>" + "\r\n" +
        //    "   <div class=\"faqline\">" + "\r\n" +
        //    "        <span class=\"faqtit\">&nbsp;</span>" + "\r\n" +
        //    "        <input type=\"submit\" value=\" 提交 \"/>" + "\r\n" +
        //    "    </div>" + "\r\n" +
        //    "</form>" + "\r\n" +
        //    "</div>" + "\r\n";
        //    content = content.Replace("{aspcms:gbook}", gbook);
        //}

        public string getSlide()
        {
            string Str;
            Str = "<SCRIPT language=JavaScript type=text/javascript>" + "\r\n" +
                "var swf_width='" + slideWidth + "';" + "\r\n" +
                "var swf_height='" + slideHeight + "';" + "\r\n" +
                "var files='" + slideImgs.Replace(",", "|").Replace(" ", "") + "';" + "\r\n" +
                "var links='" + slideLinks.Replace(",", "|").Replace(" ", "") + "';" + "\r\n" +
                "var texts='" + slideTexts.Replace(",", "|").Replace(" ", "") + "';" + "\r\n" +
                "document.write('<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\">');" + "\r\n" +
                "document.write('<param name=\"movie\" value=\"/" + sitePath + "flash/slideflash.swf\"><param name=\"quality\" value=\"high\">');" + "\r\n" +
                "document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">');" + "\r\n" +
                "document.write('<param name=\"FlashVars\" value=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'\">');" + "\r\n" +
                "document.write('<embed src=\"/" + sitePath + "flash/slideflash.swf\" wmode=\"opaque\" FlashVars=\"bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'& menu=\"false\" quality=\"high\" width=\"'+ swf_width +'\" height=\"'+ swf_height +'\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />'); document.write('</object>'); " + "\r\n" +
                "</SCRIPT>";
            return Str;
        }
        public string getFloatAD()
        {

            if (adStatus == "0")
            {
                return "";
            }
            string Str = "";
            Str = "<div id=\"img\" style=\"position:absolute;\"> <a href=\"" + adLink + "\" target=\"_blank\"> <img src=\"" + adImagePath + "\" width=\"" + adImgWidth + "\" height=\"" + adImgHeight + "\" border=\"0\"></a> </div>" + "\r\n" +
              "<script type=\"text/javascript\" language=\"JavaScript\"> " + "\r\n" +
              "<!-- " + "\r\n" +
              "var xPos = 20; " + "\r\n" +
              "var yPos = document.body.clientHeight; " + "\r\n" +
              "var step = 1; " + "\r\n" +
              "var delay = 30; " + "\r\n" +
              "var height = 0; " + "\r\n" +
              "var Hoffset = 0; " + "\r\n" +
              "var Woffset = 0; " + "\r\n" +
              "var yon = 0; " + "\r\n" +
              "var xon = 0; " + "\r\n" +
              "var pause = true; " + "\r\n" +
              "var interval; " + "\r\n" +
              "img.style.top = yPos; " + "\r\n" +
              "function changePos() { " + "\r\n" +
              "width = document.body.clientWidth; " + "\r\n" +
              "height = document.body.clientHeight; " + "\r\n" +
              "Hoffset = img.offsetHeight; " + "\r\n" +
              "Woffset = img.offsetWidth; " + "\r\n" +
              "img.style.left = xPos + document.body.scrollLeft; " + "\r\n" +
              "img.style.top = yPos + document.body.scrollTop; " + "\r\n" +
              "if (yon) { " + "\r\n" +
              "yPos = yPos + step; " + "\r\n" +
              "} " + "\r\n" +
              "else { " + "\r\n" +
              "yPos = yPos - step; " + "\r\n" +
              "} " + "\r\n" +
              "if (yPos < 0) { " + "\r\n" +
              "yon = 1; " + "\r\n" +
              "yPos = 0;" + "\r\n" +
              "} " + "\r\n" +
              "if (yPos >= (height - Hoffset)) { " + "\r\n" +
              "yon = 0; " + "\r\n" +
              "yPos = (height - Hoffset); " + "\r\n" +
              "} " + "\r\n" +
              "if (xon) { " + "\r\n" +
              "xPos = xPos + step; " + "\r\n" +
              "} " + "\r\n" +
              "else { " + "\r\n" +
              "xPos = xPos - step; " + "\r\n" +
              "} " + "\r\n" +
              "if (xPos < 0) { " + "\r\n" +
              "xon = 1; " + "\r\n" +
              "xPos = 0;" + "\r\n" +
              "} " + "\r\n" +
              "if (xPos >= (width - Woffset)) { " + "\r\n" +
              "xon = 0; " + "\r\n" +
              "xPos = (width - Woffset); " + "\r\n" +
              "} " + "\r\n" +
              "} " + "\r\n" +
              "function ad() { " + "\r\n" +
              "img.visibility = \"visible\"; " + "\r\n" +
              "interval = setInterval('changePos()', delay); " + "\r\n" +
              "} " + "\r\n" +
              "ad(); " + "\r\n" +
              "//For more,visit:www.helpor.net " + "\r\n" +
              "--> " + "\r\n" +
              "</script>" + "\r\n";
            return Str;
        }

        public string getOnlineservice()
        {
            if (serviceStatus == "1")
            {
                if (serviceStyle == "1")
                {
                    return getqqkf1();
                }
                else if (serviceStyle == "2")
                {
                    return getqqkf2();
                }
            }
            return "";
        }

        public string getKf()
        {
            if (servicekfStatus == "1")
            {
                return servicekf;
            }
            return "";
        }

        public string getqqkf1()
        {
            string Str = "";
            Str = "<LINK rev=stylesheet href=\"/" + sitePath + "images_sys/qq/qqkf1/default.css\" type=text/css rel=stylesheet>" + "\r\n" +
            "<DIV id=kefu_pannel style=\"Z-INDEX: 30000; FILTER: alpha(opacity=85); LEFT: 0px; POSITION: absolute; TOP: 120px\">" + "\r\n" +
            "<TABLE cellSpacing=0 cellPadding=0 border=0>" + "\r\n" +
            "<THEAD id=kefu_pannel_top>" + "\r\n" +
            "<TR>" + "\r\n" +
            "<TH class=kefu_Title><SPAN class=kefu_shut id=kefu_ctrl onclick=HideKefu()></SPAN>" + "\r\n" +
            "<H2 class=txtCut>在线客服</H2></TH></TR></THEAD>" + "\r\n" +
            "<TBODY id=kefu_pannel_mid>" + "\r\n" +
            "<TR>" + "\r\n" +
            "<TD height=3></TD></TR>" + "\r\n" +
            "<TR>" + "\r\n" +
            "<TD>" + "\r\n";
            if (!string.IsNullOrEmpty(serviceQQ))
            {
                string[] tempStr = serviceQQ.Split(' ');
                for (int i = 0; i < tempStr.Length; i++)
                {
                    Str = Str + " <DIV class=kefu_box onmouseover=\"this.className='kefu_boxOver'\" onmouseout=\"this.className='kefu_box'\"><SPAN class=kefu_image><IMG src=\"/" + sitePath + "images_sys/qq/qqkf1/icon_person_stat_online.gif\"></SPAN><A class=kefu_Type_qq href=\"tencent://message/?uin=" + tempStr[i].Trim() + "&amp;Menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:" + tempStr[i].Trim() + ":41 &r=0.8817731731823399\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"></A></DIV>" + "\r\n";
                }
            }
            if (!string.IsNullOrEmpty(serviceWangWang))
            {
                string[] tempStr = serviceWangWang.Split(' ');
                for (int i = 0; i < tempStr.Length; i++)
                {
                    Str = Str + "<DIV class=kefu_box onmouseover=\"this.className='kefu_boxOver'\" onmouseout=\"this.className='kefu_box'\"><SPAN class=kefu_image><IMG src=\"/" + sitePath + "images_sys/qq/qqkf1/icon_person_stat_online.gif\"></SPAN><A target=\"_blank\" class=kefu_Type_msn href=\"http://amos1.taobao.com/msg.ww?v=2&uid=" + tempStr[i].Trim() + "&s=1\"><img border=\"0\" src=\"http://amos1.taobao.com/online.ww?v=2&uid=" + tempStr[i].Trim() + "&s=1\" alt=\"点击这里给我发消息\" /></A></DIV>" + "\r\n";

                }
            }
            Str = Str + "</TD></TR>" + "\r\n" +
                    "<TR>" + "\r\n" +
                "<TD height=3></TD></TR></TBODY>" + "\r\n" +
                "<TFOOT id=kefu_pannel_btm>" + "\r\n" +
                "<TR style=\"CURSOR: hand\" onclick=\"parent.location='" + serviceContact + "';\">" + "\r\n" +
                "<TD class=kefu_other></TD></TR></TFOOT></TABLE></DIV>" + "\r\n" +
                "<SCRIPT language=JavaScript src=\"/" + sitePath + "images_sys/qq/qqkf1/qqkf.js\"></SCRIPT>" + "\r\n";
            return Str.ToString();
        }


        public string getqqkf2()
        {
            string Str = "";
            Str = "<link rev=stylesheet href=\"/" + sitePath + "images_sys/qq/qqkf2/kf.css\" type=text/css rel=stylesheet>" + "\r\n" +
                   "<div onmouseout=\"toSmall()\" onmouseover=\"toBig()\" id=\"qq_Kefu\" style=\"top: 136px; left: -143px; position: absolute; \">" + "\r\n" +
                   "  <table cellspacing=\"0\" cellpadding=\"0\" border=\"0\">" + "\r\n" +
                   "    <tbody><tr>" + "\r\n" +
                   "      <td><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\">" + "\r\n" +
                   "          <tbody>" + "\r\n" +
                   "          <tr>" + "\r\n" +
                   "          	<td background=\"/" + sitePath + "images_sys/qq/qqkf2/kf_bg03_01.gif\" height=\"32\"></td>" + "\r\n" +
                   "          </tr>" + "\r\n" +
                   "          <tr>" + "\r\n" +
                   "            <td background=\"/" + sitePath + "images_sys/qq/qqkf2/kf_bg03_02.gif\" align=\"left\"  width=\"143\">" + "\r\n" +
                   "            <div class=\"kfbg\">" + "\r\n";
            if (!string.IsNullOrEmpty(serviceQQ))
            {
                string[] tempStr = serviceQQ.Split(' ');
                for (int i = 0; i < tempStr.Length; i++)
                {
                    Str = Str + " <div class=kefu_box onmouseover=\"this.classname='kefu_boxover'\" onmouseout=\"this.classname='kefu_box'\"><a class=kefu_type_qq href=\"tencent://message/?uin=" + tempStr[i].Trim() + "&amp;menu=yes\"><img border=\"0\" src=\"http://wpa.qq.com/pa?p=2:" + tempStr[i].Trim() + ":41 &r=0.8817731731823399\" alt=\"点击这里给我发消息\" title=\"点击这里给我发消息\"></a></div>" + "\r\n";
                }
            }
            if (!string.IsNullOrEmpty(serviceWangWang))
            {
                string[] tempStr = serviceWangWang.Split(' ');
                for (int i = 0; i < tempStr.Length; i++)
                {
                    Str = Str + "<div class=kefu_box onmouseover=\"this.classname='kefu_boxover'\" onmouseout=\"this.classname='kefu_box'\"><a target=\"_blank\" class=kefu_type_msn href=\"http://amos1.taobao.com/msg.ww?v=2&uid=" + tempStr[i].Trim() + "&s=1\"><img border=\"0\" src=\"http://amos1.taobao.com/online.ww?v=2&uid=" + tempStr[i].Trim() + "&s=1\" alt=\"点击这里给我发消息\" /></a></div>" + "\r\n";
                }
            }


            Str = Str + "</div>   " + "\r\n" +
          "            </td>" + "\r\n" +
          "          </tr>" + "\r\n" +
          "          <tr  style=\"cursor: hand\" onclick=\"parent.location='" + serviceContact + "';\" >" + "\r\n" +
          "            <td height=\"46\" background=\"/" + sitePath + "images_sys/qq/qqkf2/kf_bg03_03.gif\"><div class=\"kefu_work\"></div></td>" + "\r\n" +
          "          </tr>" + "\r\n" +
          "        </tbody></table></td>" + "\r\n" +
          "      <td class=\"kfbut\" width=\"27\" rowspan=\"3\" class=\"Kefu_Little\">&nbsp;</td>" + "\r\n" +
          "    </tr>" + "\r\n" +
          "  </tbody></table>" + "\r\n" +
          "</div>" + "\r\n" +
          "<script src=\"/" + sitePath + "images_sys/qq/qqkf2/kefu.js\" type=\"text/javascript\"></script>" + "\r\n";
            return Str;
        }

        public void parsePrevAndNext(string Id, string SortID)
        {
            string linkStr = "";
            DataTable dtPrev = DBUtility.OleDbHelper.Query("select top 1 NewsID,Title,SortStyle from Aspcms_News,Aspcms_NewsSort where Aspcms_News.SortID=Aspcms_NewsSort.SortID and NewsStatus and NewsID<" + Id + " and Aspcms_News.SortID=" + SortID + " order by NewsID desc").Tables[0];
            if (dtPrev.Rows.Count <= 0)
            {
                linkStr = "没有了!";
            }
            else
            {
                linkStr = getShowLink(SortID, dtPrev.Rows[0][0].ToString(), Dir(dtPrev.Rows[0][2].ToString()));
                linkStr = "<a href=\"" + linkStr + "\">" + dtPrev.Rows[0][1].ToString() + "</a>";
            }
            content = content.Replace("{aspcms:prev}", linkStr);
            DataTable dtNext = DBUtility.OleDbHelper.Query("select top 1 NewsID,Title,SortStyle from Aspcms_News,Aspcms_NewsSort where Aspcms_News.SortID=Aspcms_NewsSort.SortID and NewsStatus and NewsID>" + Id + " and Aspcms_News.SortID=" + SortID + " order by NewsID asc").Tables[0];
            if (dtNext.Rows.Count <= 0)
            {
                linkStr = "没有了!";
            }
            else
            {
                linkStr = getShowLink(SortID, dtNext.Rows[0][0].ToString(), Dir(dtNext.Rows[0][2].ToString()));
             
                linkStr = "<a href=\"" + linkStr + "\">" + dtNext.Rows[0][1].ToString() + "</a>";
            }
            content = content.Replace("{aspcms:next}", linkStr);

        }

        public string getArrt(string str, string tag, string arr)
        {
            string rValue = "";
            string labelRule = @"\[" + str + ":" + tag + @"([\s\S]*?)\]";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                rValue = parseArr(match.Groups[0].Value)[arr];
            }
            strDictionary.Clear();

            return rValue;
        }


        public string getTopType(string SortID)
        {
            string tempStr = "";
            DataTable dt = DBUtility.OleDbHelper.Query("select SortName,ParentID,SortID,sortStyle,sortUrl from Aspcms_NewsSort where SortID=" + SortID).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tempStr = "<a href=\"" + getUrl(dt.Rows[0][3].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][4].ToString()) + "\">" + dt.Rows[0][0].ToString() + "</a>,";
                tempStr += getTopType(dt.Rows[0][1].ToString());
            }
            else
            {
                tempStr = "";
            }
            return tempStr;

        }

        public void parsePosition(string SortID)
        {
            DataTable dt = DBUtility.OleDbHelper.Query("select SortName from Aspcms_NewsSort where SortID=" + SortID + "").Tables[0];
            content = content.Replace("{aspcms:sortname}", dt.Rows[0][0].ToString());
            if (content.IndexOf("{aspcms:position") < 0)
            {
                return;
            }
            string labelRule = @"{aspcms:position([\s\S]*?)}([\s\S]*?){/aspcms:position}";
            string labelRuleField = @"\[position:([\s\S]+?)\]";
            string loopstrTotal = "";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string[] linkArray = getTopType(SortID).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < linkArray.Length; i++)
                {
                    string loopstrLinklist = match.Groups[2].Value;
                    regExpObj = new Regex(labelRuleField);
                    MatchCollection matchesfield = regExpObj.Matches(loopstrLinklist);
                    string loopstrLinklistNew = loopstrLinklist;
                    foreach (Match matchfield in matchesfield)
                    {
                        string fieldNameAndAttr = matchfield.Groups[1].Value.Replace(@"[\s]+", ((char)32).ToString()).Trim();
                        string fieldName = "";
                        string fieldAttr = "";
                        int m = fieldNameAndAttr.IndexOf((char)32);
                        if (m > 0)
                        {
                            fieldName = fieldNameAndAttr.Substring(0, m - 1);
                            fieldAttr = fieldNameAndAttr.Substring(fieldNameAndAttr.Length - m);
                        }
                        else
                        {
                            fieldName = fieldNameAndAttr;
                            fieldAttr = "";
                        }
                        switch (fieldName)
                        {
                            case "link":
                                loopstrLinklistNew = loopstrLinklistNew.Replace(matchfield.Value, linkArray[linkArray.Length - 1 - i]);
                                break;
                        }
                    }
                    loopstrTotal = loopstrTotal + loopstrLinklistNew;
                }
                content = content.Replace(match.Value, loopstrTotal);
                loopstrTotal = "";
                strDictionary.Clear();
            }
        }

        public void parseHtml()
        {
            parseTopAndFoot();
            parseAuxiliaryTemplate();
        }


        public void parseCommon()
        {
            GetWebSetting();
            parseGlobal();
            parseNavList("");
            parseLinkList();
            parseLoop("type");
            parseLoop("about");
            parseLoop("news");
            parseLoop("down");
            parseLoop("pic");
            parseLoop("product");
            parseLoop("job");
            parseLoop("gbook");
            parseAd("ad");
            content = content.Replace("{aspcms:keys}", keys);
            //parseGbook();
            parseIf();

        }

        public string Dir(string webType)
        {
            string path = "";
            switch (webType)
            {
                case "0":
                    path = "news";
                    break;
                case "1":
                    path = "pic";
                    break;
                case "2":
                    path = "about";
                    break;
                case "3":
                    path = "product";
                    break;
                case "4":
                    path = "down";
                    break;
                case "5":
                    path = "url";
                    break;
                case "6":
                    path = "job";
                    break;
            }
            return path;
        }




        public string pageNumberLinkInfo(int currentPage, int pageListLen, int totalPages, string linkType, string sortid)
        {
            string firstPageLink = "";
            string lastPagelink = "";
            string nextPagelink = "";
            string finalPageLink = "";
            string pageNumber = makePageNumber(currentPage, pageListLen, totalPages, linkType, sortid);
            if (currentPage == 1)
            {
                firstPageLink = "<a class='nolink'>首页</a>&nbsp;";
                lastPagelink = "<a class='nolink'>上一页</a>";
            }
            else
            {
                if (linkType == "gbooklist")
                {
                    firstPageLink = "<a href='?1" + FileExt + "'>首页</a>&nbsp;";
                    lastPagelink = "<a href='?" + (currentPage - 1).ToString() + FileExt + "'>上一页</a>&nbsp;";
                }
                else if (linkType == "searchlist")
                {
                    firstPageLink = "<a href='?page=1&key=" + keys + "'>首页</a>&nbsp;";
                    lastPagelink = "<a href='?page=" + (currentPage - 1).ToString() + "&key=" + keys + "'>上一页</a>&nbsp;";
                }
                else
                {
                    firstPageLink = "<a href='" + runstr + sortid + "_1" + FileExt + "'>首页</a>&nbsp;";
                    if (currentPage > 2)
                    {
                        lastPagelink = "<a href='" + runstr + sortid + "_" + (currentPage - 1).ToString() + FileExt + "'>上一页</a>&nbsp;";
                    }
                    else
                    {
                        lastPagelink = "<a href='" + runstr + sortid + "_1" + FileExt + "'>上一页</a>&nbsp;";
                    }
                }
            }
            if (currentPage == totalPages)
            {
                nextPagelink = "<a class='nolink'>下一页</a>&nbsp;";
                finalPageLink = "<a class='nolink'>尾页</a>";
            }
            else
            {
                if (linkType == "gbooklist")
                {
                    nextPagelink = "<a href='?" + (currentPage + 1) + FileExt + "'>下一页</a>&nbsp;";
                    finalPageLink = "<a href='?" + totalPages + FileExt + "'>尾页</a>";
                }
                else if (linkType == "searchlist")
                {
                    nextPagelink = "<a href='?page=" + (currentPage + 1) + "&key=" + keys + "'>下一页</a>&nbsp;";
                    finalPageLink = "<a href='?page=" + totalPages + "&key=" + keys + "'>尾页</a>";
                }
                else
                {
                    nextPagelink = "<a href='" + runstr + sortid + "_" + (currentPage + 1) + FileExt + "'>下一页</a>&nbsp;";
                    finalPageLink = "<a href='" + runstr + sortid + "_" + totalPages + FileExt + "'>尾页</a>";
                }
            }
            return   firstPageLink + lastPagelink + pageNumber + "" + nextPagelink + "" + finalPageLink;
            //return "<span>共" + totalPages + "页 页次:" + currentPage + "/" + totalPages + "页</span>&nbsp;" + firstPageLink + lastPagelink + pageNumber + "" + nextPagelink + "" + finalPageLink;
        }

        public string makePageNumber(int currentPage, int pageListLen, int totalPages, string linkType, string sortid)
        {
            int beforePages = 0;
            int beginPage = 0;
            int endPage = 0;
            string strPageNumber = "";
            if (pageListLen % 2 == 0)
            {
                beforePages = pageListLen / 2;
            }
            else
            {
                beforePages = (int)(pageListLen / 2) - 1;
            }
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }
            if (pageListLen > totalPages)
            {
                pageListLen = totalPages;
            }
            if (currentPage - beforePages < 1)
            {
                beginPage = 1;
                endPage = pageListLen;
            }
            else if (currentPage - beforePages + pageListLen > totalPages)
            {
                beginPage = totalPages - pageListLen + 1;
                endPage = totalPages;
            }
            else
            {
                beginPage = currentPage - beforePages;
                endPage = currentPage - beforePages + pageListLen - 1;
            }
            for (int pagenumber = beginPage; pagenumber <= endPage; pagenumber++)
            {
                if (pagenumber == currentPage)
                {
                    strPageNumber = strPageNumber + "&nbsp;<a><font color=red>" + pagenumber + "</font></a>" + "&nbsp;";
                }
                else
                {
                    if (linkType == "newslist" || linkType == "downlist" || linkType == "productlist" || linkType == "piclist")
                    {
                        if (pagenumber > 1)
                        {
                            strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "_" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                        }
                        else
                        {
                            strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "_1" + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                        }

                    }
                    else if (linkType == "about")
                    {
                        if (pagenumber > 1)
                        {
                            strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "_" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                        }
                        else
                        {
                            strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "" + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                        }
                    }
                    else if (linkType == "gbooklist")
                    {
                        strPageNumber = strPageNumber + "<a href=\"?" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                    }
                    else if (linkType == "joblist")
                    {
                        strPageNumber = strPageNumber + "<a href=\"?" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                    }
                    else if (linkType == "searchlist")
                    {
                        strPageNumber = strPageNumber + "<a href=\"?page=" + pagenumber + "&key=" + keys + "\">" + pagenumber + "</a>&nbsp;";
                    }
                    else
                    {
                        if (sortid == "")
                        {
                            strPageNumber = strPageNumber + "<a href=\"?" + linkType + "_" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                        }
                        else
                        {
                            if (pagenumber > 1)
                            {
                                strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "_" + linkType + "_" + pagenumber + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                            }
                            else
                            {
                                strPageNumber = strPageNumber + "<a href=\"" + runstr + sortid + "_" + linkType + FileExt + "\">" + pagenumber + "</a>&nbsp;";
                            }
                        }
                    }
                }
            }
            return strPageNumber;
        }

        public string plSort(string str)
        {
            return str;
        }
        /// <summary>
        /// 网站运行模式（false为动态，true为静态）
        /// </summary>
        /// <returns></returns>
        public bool CheckRunMode()
        {
            return runMode;
        }


        #region 生成页面方法
        public string GetContent(string SortId, string Id, int page)
        {
            try
            {

                DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL, ParentID,topsortid from Aspcms_NewsSort where   SortID=" + SortId).Tables[0];
                if (dtSort.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！1");
                }
                string style = Dir(dtSort.Rows[0]["SortStyle"].ToString());
                string contentTemplateName = dtSort.Rows[0]["SortContentTemplate"].ToString();
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + contentTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                parseHtml();
                if (content.IndexOf("{aspcms:comment}") > 0)
                {
                    if (switchComments == "1")
                    {

                        string tempContent = content;
                        Load("/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/plug/comment.html");
                        tempContent = tempContent.Replace("{aspcms:comment}", content);//	'加载评论模板
                        content = tempContent;
                    }
                    else
                    {
                        content = content.Replace("{aspcms:comment}", "");//	'加载评论模板
                    }
                }

                content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["parentID"].ToString());
                content = content.Replace("{aspcms:sortid}", SortId);
                content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                parsePosition(SortId);
                parseCommon();

                parsePrevAndNext(Id, SortId);

                string sperStr = "";
                string sperCol = "";

                DataTable dtSper = DBUtility.OleDbHelper.Query("select SpecField from   Aspcms_SpecSet where SpecType='" + style + "'  Order by SpecOrder Asc,SpecID").Tables[0];
                foreach (DataRow dr in dtSper.Rows)
                {
                    sperStr += "," + dr["SpecField"].ToString();
                    sperCol += "," + style + "_" + dr["SpecField"].ToString();
                }
                string Sql = "";

                Sql = "select Title,Title2,TitleColor,NewsSource,[Content],Author,AddTime,NewsTag,Visits,ImagePath,downurl" + sperCol + " from Aspcms_News where NewsStatus=true and NewsID=" + Id;
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！" + Sql);
                }
                content = content.Replace("[" + style + ":id]", Id);
                content = content.Replace("[" + style + ":title]", dt.Rows[0]["Title"].ToString());
                content = content.Replace("[" + style + ":subtitle]", dt.Rows[0]["Title2"].ToString());
                content = content.Replace("[" + style + ":author]", dt.Rows[0]["Author"].ToString());
                content = content.Replace("[" + style + ":source]", dt.Rows[0]["NewsSource"].ToString());
                content = content.Replace("[" + style + ":date]", dt.Rows[0]["AddTime"].ToString());
                content = content.Replace("[" + style + ":visits]", dt.Rows[0]["Visits"].ToString());
                content = content + "<script src=\"/" + sitePath + "inc/visitsAdd.ashx?id=" + Id + "\"></script>";
                content = content.Replace("[" + style + ":tag]", dt.Rows[0]["NewsTag"].ToString());
                content = content.Replace("[" + style + ":color]", dt.Rows[0]["TitleColor"].ToString());
                if (dt.Rows[0]["ImagePath"].ToString().Trim() != "")
                {
                    content = content.Replace("[" + style + ":pic]", dt.Rows[0]["ImagePath"].ToString());
                }
                else
                {
                    content = content.Replace("[" + style + ":pic]", "/" + sitePath + "images_sys/nopic.gif");
                }


                content = content.Replace("[" + style + ":downurl]", dt.Rows[0]["downurl"].ToString());
                if (style == "product" || style == "news" || style == "job")
                {
                    string[] sperStrsArr = sperStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] sperColsArr = sperCol.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < sperStrsArr.Length; i++)
                    {
                        content = content.Replace("[" + style + ":" + sperStrsArr[i] + "]", dt.Rows[0][sperColsArr[i]].ToString());
                    }
                }
                string newsContent = Common.StringUtil.DecodeHtml(dt.Rows[0]["Content"].ToString());

                if (newsContent.IndexOf("{aspcms:page}") > 0)
                {
                    string pageStr = "";
                    string[] newsContentArr = newsContent.Split(new string[] { "{aspcms:page}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (page > newsContentArr.Length)
                    {
                        page = newsContentArr.Length;
                    }
                    if (page >= 2)
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_" + (page - 1) + FileExt + "'>上一页</a>";
                    }
                    else
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_1" + FileExt + "'>上一页</a>";
                    }
                    pageStr = pageStr + makePageNumber(page, 10, newsContentArr.Length, "gbook", SortId);
                    if (page == newsContentArr.Length)
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (newsContentArr.Length) + FileExt + "'>下一页</a></div>";
                    }
                    else
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (page + 1) + FileExt + "'>下一页</a></div>";
                    }
                    content = content.Replace("[" + style + ":info]", newsContentArr[page - 1] + pageStr);
                }
                else
                {
                    content = content.Replace("[" + style + ":info]", newsContent);
                }
                content = content.Replace("[" + style + ":desc]", Common.StringUtil.cutstring(Common.StringUtil.ClearHtmlCode(newsContent), 100));

                return (content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetList(string SortId, int page)
        {
            DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL,ParentID,(select count(*) from AspCms_NewsSort where ParentID=t.SortID),topsortid from Aspcms_NewsSort as t where  SortStyle<>2 and SortStyle<>5 and SortID=" + SortId).Tables[0];
            if (dtSort.Rows.Count <= 0)
            {
                throw new Exception("参数不正确");
            }
            string style = Dir(dtSort.Rows[0]["SortStyle"].ToString());
            string listTemplateName = dtSort.Rows[0]["SortTemplate"].ToString();
            string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + listTemplateName;
            templatePath = templatePath.Replace("//", "/");
            DataTable dt = DBUtility.OleDbHelper.Query("select * from Aspcms_News where NewsStatus and SortID in (" + Common.CommonFunction.GetSmallestChild("Aspcms_NewsSort", SortId) + ")").Tables[0];

            Load(templatePath);
            parseHtml();
            parsePosition(SortId);

            content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
            content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["ParentID"].ToString());
            content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
            content = content.Replace("{aspcms:sortid}", SortId);
            parseList(SortId, page, style + "list", "", style);
            parseCommon();
            return content;

        }

        public string GetAbout(string SortId, int page)
        {
            try
            {

                DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL,ParentID,topsortid from Aspcms_NewsSort where   SortID=" + SortId).Tables[0];
                if (dtSort.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！1");
                }
                string contentTemplateName = dtSort.Rows[0]["SortContentTemplate"].ToString();
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + contentTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                parseHtml();
                content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["parentID"].ToString());
                content = content.Replace("{aspcms:sortid}", SortId);
                content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                parsePosition(SortId);
                parseCommon();

                string Sql = "";

                Sql = "select Title,TitleColor,NewsSource,[Content],Author,AddTime,NewsTag,Visits,ImagePath,downurl from Aspcms_News where  SortID=" + SortId;

                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    throw new Exception("不存在该信息！" + Sql);
                }
                string newsContent = Common.StringUtil.DecodeHtml(dt.Rows[0]["Content"].ToString());
                if (newsContent.IndexOf("{aspcms:page}") > 0)
                {
                    string pageStr = "";
                    string[] newsContentArr = newsContent.Split(new string[] { "{aspcms:page}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (page > newsContentArr.Length)
                    {
                        page = newsContentArr.Length;
                    }
                    if (page >= 2)
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + (page - 1) + FileExt + "'>上一页</a>";
                    }
                    else
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_1" + FileExt + "'>上一页</a>";
                    }
                    pageStr = pageStr + makePageNumber(page, 10, newsContentArr.Length, "about", SortId);
                    if (page == newsContentArr.Length)
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + (newsContentArr.Length) + FileExt + "'>下一页</a></div>";
                    }
                    else
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + (page + 1) + FileExt + "'>下一页</a></div>";
                    }
                    content = content.Replace("[about:info]", newsContentArr[page - 1] + pageStr);
                }
                else
                {
                    content = content.Replace("[about:info]", newsContent);
                }
                content = content.Replace("[about:desc]", Common.StringUtil.cutstring(Common.StringUtil.ClearHtmlCode(newsContent), 100));
                //content = content + "<script src=\"/" + sitePath + "inc/visitsAdd.ashx?id=" + SortId + "\"></script>";
                return (content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetSearch(int page, string keys)
        {
            string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/search.html";
            templatePath = templatePath.Replace("//", "/");
            keys = keys;
            Load(templatePath);
            parseHtml();


            parseCommon();
            parseList("0", page, "searchlist", keys, "product");
            return content;

        }

        public string GetGbook(int page)
        {
            string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/gbook.html";
            templatePath = templatePath.Replace("//", "/");
            Load(templatePath);
            parseHtml();

            parseCommon();
            parseList("0", page, "gbooklist", "", "gbook");
            return content;

        }

        public string GetJobList(int page)
        {
            string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/joblist.html";
            templatePath = templatePath.Replace("//", "/");
            Load(templatePath);
            parseHtml();
            parseCommon();
            parseList("", page, "joblist", "", "job");
            return content;

        }

        public string GetJob(string SortId, string Id, int page)
        {
            try
            {
                DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL, ParentID,topsortid from Aspcms_NewsSort where   SortID=" + SortId).Tables[0];
                if (dtSort.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！1");
                }
                string style = Dir(dtSort.Rows[0]["SortStyle"].ToString());
                string contentTemplateName = dtSort.Rows[0]["SortContentTemplate"].ToString();
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + contentTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                parseHtml();
                content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["parentID"].ToString());
                content = content.Replace("{aspcms:sortid}", SortId);
                content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                parsePosition(SortId);
                parseCommon();
                parsePrevAndNext(Id, SortId);

                string sperStr = "";
                string sperCol = "";

                DataTable dtSper = DBUtility.OleDbHelper.Query("select SpecField from   Aspcms_SpecSet where SpecType='" + style + "'  Order by SpecOrder Asc,SpecID").Tables[0];
                foreach (DataRow dr in dtSper.Rows)
                {
                    sperStr += "," + dr["SpecField"].ToString();
                    sperCol += "," + style + "_" + dr["SpecField"].ToString();
                }

                string Sql = "";

                Sql = "select JobId,Title,TitleColor,[Content],Author,AddTime,JobTag,Visits,ImagePath,downurl" + sperCol + " from Aspcms_Job where JobStatus=true and JobID=" + Id;
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    throw new Exception("该招聘信息已经被删除！" + Sql);
                }
                content = content.Replace("[" + style + ":id]", Id);
                content = content.Replace("[" + style + ":title]", dt.Rows[0]["Title"].ToString());
                content = content.Replace("[" + style + ":date]", dt.Rows[0]["AddTime"].ToString());
                content = content.Replace("[" + style + ":visits]", dt.Rows[0]["Visits"].ToString());
                content = content.Replace("[" + style + ":tag]", dt.Rows[0]["JobTag"].ToString());
                content = content.Replace("[" + style + ":color]", dt.Rows[0]["TitleColor"].ToString());
                content = content.Replace("[" + style + ":pic]", dt.Rows[0]["ImagePath"].ToString());

                if (content.IndexOf("[" + style + ":downurl]") > 0)
                {
                    string downUrlStr = "";
                    string[] downUrls = dt.Rows[0]["downurl"].ToString().Split(',');
                    for (int di = 0; di < downUrls.Length; di++)
                    {
                        if (downUrls[di].Trim() != "")
                        {
                            downUrlStr += " <a href=\"" + downUrls[di] + "\"  target=\"_blank\">下载地址" + di + 1 + "</a> &nbsp;";
                        }
                    }
                    content = content.Replace("[" + style + ":downurl]", dt.Rows[0]["downurl"].ToString());
                }

                if (sperStr != "" && sperCol != "")
                {
                    string[] sperStrsArr = sperStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] sperColsArr = sperCol.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < sperStrsArr.Length; i++)
                    {
                        content = content.Replace("[" + style + ":" + sperStrsArr[i] + "]", dt.Rows[0][sperColsArr[i]].ToString());
                    }
                }
                string newsContent = Common.StringUtil.DecodeHtml(dt.Rows[0]["Content"].ToString());

                if (newsContent.IndexOf("{aspcms:page}") > 0)
                {
                    string pageStr = "";
                    string[] newsContentArr = newsContent.Split(new string[] { "{aspcms:page}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (page > newsContentArr.Length)
                    {
                        page = newsContentArr.Length;
                    }
                    if (page >= 2)
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_" + (page - 1) + FileExt + "'>上一页</a>";
                    }
                    else
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_1" + FileExt + "'>上一页</a>";
                    }
                    pageStr = pageStr + makePageNumber(page, 10, newsContentArr.Length, "job", SortId);
                    if (page == newsContentArr.Length)
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (newsContentArr.Length) + FileExt + "'>下一页</a></div>";
                    }
                    else
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (page + 1) + FileExt + "'>下一页</a></div>";
                    }
                    content = content.Replace("[" + style + ":info]", newsContentArr[page - 1] + pageStr);
                }
                else
                {
                    content = content.Replace("[" + style + ":info]", newsContent);
                }
                content = content.Replace("[" + style + ":desc]", Common.StringUtil.cutstring(Common.StringUtil.ClearHtmlCode(newsContent), 100));

                return (content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string GetJobAdd(int JobId)
        {
            try
            {
                string sperStr = "";
                string sperCol = "";
                string style = "job";
                DataTable dtSper = DBUtility.OleDbHelper.Query("select SpecField from   Aspcms_SpecSet where SpecType='" + style + "'  Order by SpecOrder Asc,SpecID").Tables[0];
                foreach (DataRow dr in dtSper.Rows)
                {
                    sperStr += "," + dr["SpecField"].ToString();
                    sperCol += "," + style + "_" + dr["SpecField"].ToString();
                }

                string Sql = "";

                Sql = "select JobId,SortId,Title,TitleColor,[Content],Author,AddTime,JobTag,Visits,ImagePath,downurl" + sperCol + " from Aspcms_Job where JobStatus=true and JobID=" + JobId;
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    throw new Exception("该招聘信息已经被删除！" + Sql);
                }
                string SortId = dt.Rows[0]["SortId"].ToString();
                DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL, ParentID,topsortid from Aspcms_NewsSort where   SortID=" + SortId).Tables[0];
                if (dtSort.Rows.Count <= 0)
                {
                    throw new Exception("招聘分类不存在！");
                }
                string contentTemplateName = "jobAdd.html";
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + contentTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                parseHtml();
                content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["parentID"].ToString());
                content = content.Replace("{aspcms:sortid}", SortId);
                content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                parsePosition(SortId);
                parseCommon();

                content = content.Replace("[" + style + ":id]", JobId.ToString());
                content = content.Replace("[" + style + ":title]", dt.Rows[0]["Title"].ToString());
                content = content.Replace("[" + style + ":date]", dt.Rows[0]["AddTime"].ToString());
                content = content.Replace("[" + style + ":visits]", dt.Rows[0]["Visits"].ToString());
                content = content.Replace("[" + style + ":tag]", dt.Rows[0]["JobTag"].ToString());
                content = content.Replace("[" + style + ":color]", dt.Rows[0]["TitleColor"].ToString());
                content = content.Replace("[" + style + ":pic]", dt.Rows[0]["ImagePath"].ToString());
                content = content.Replace("[" + style + ":downurl]", dt.Rows[0]["downurl"].ToString());
                return (content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region
        public string CreateListBySortId(string SortId)
        {
            DataTable dtSort = DBUtility.OleDbHelper.Query("select SortID,ParentID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL,SortFolder,topsortid from Aspcms_NewsSort where SortStyle<>2 and SortStyle<>5 and SortID=" + SortId).Tables[0];
            if (dtSort.Rows.Count <= 0)
            {
                return "该栏目不存在!";
            }
            try
            {
                string listTemplateName = dtSort.Rows[0]["SortTemplate"].ToString();
                string sortFolder = dtSort.Rows[0]["SortFolder"].ToString();
                string sortStyle = Dir(dtSort.Rows[0]["SortStyle"].ToString());
                string pageListType = sortStyle + "list";
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + listTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                int lsize = 20;
                string labelRule = "{aspcms:" + pageListType + @"([\s\S]*?)}([\s\S]*?){/aspcms:" + pageListType + "}";
                regExpObj = new Regex(labelRule);
                MatchCollection matches = regExpObj.Matches(content);
                if (matches.Count > 0)
                {
                    string labelStr = matches[0].Groups[1].Value;
                    Dictionary<string, string> labelArr = parseArr(labelStr);
                    if (!string.IsNullOrEmpty(labelArr["size"]))
                    {
                        lsize = int.Parse(labelArr["size"]);
                    }
                }
                DataTable dt = DBUtility.OleDbHelper.Query("select * from Aspcms_News where NewsStatus and SortID in (" + Common.CommonFunction.GetSmallestChild("Aspcms_NewsSort", SortId) + ")").Tables[0];
                int pageCount = dt.Rows.Count / lsize + 1;
                for (int page = 1; page <= pageCount; page++)
                {
                    Load(templatePath);
                    parseHtml();
                    parsePosition(SortId);
                    if (dtSort.Rows.Count > 0)
                    {
                        content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                        content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["ParentID"].ToString());
                        content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                        content = content.Replace("{aspcms:sortid}", SortId);
                    }
                    parseList(SortId, page, pageListType, "", sortStyle);
                    parseCommon();
                    Common.FileOpeartorFunction.createFile(content, "/" + sitePath + sortStyle + "list/" + SortId + "_" + page + FileExt, Encoding.Default);
                }
                return "生成" + dtSort.Rows[0]["SortName"].ToString() + "成功!";
            }
            catch (Exception ex)
            {
                return "生成" + dtSort.Rows[0]["SortName"].ToString() + "失败!" + ex.Message;
            }
        }
        #endregion


        #region 生成专题的方法
        public string CreateSpecialIndex(string specialId)
        {
            DataTable dt = DBUtility.OleDbHelper.Query("select * from AspCms_Special where SpecialId=" + specialId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + dt.Rows[0]["SpecialIndexTemplate"].ToString();
                Load(templatePath);
                parseHtml();
                parseSpecialCommon();
                return content;
            }
            else
            {
                return "该专题已经被删除!";
            }
        }

        public void parseSpecialCommon()
        {
            GetWebSetting();
            parseGlobal();
            parseSpecialLoop("type");
            parseSpecialLoop("about");
            parseSpecialLoop("news");
            parseSpecialLoop("down");
            parseSpecialLoop("pic");
            parseSpecialLoop("product");
            parseSpecialLoop("job");
            parseSpecialLoop("gbook");
            content = content.Replace("{aspcms:keys}", keys);
            //parseGbook();
            parseIf();

        }

        public void parseSpecialLoop(string str)
        {
            string labelRule = "{aspcms:" + str + @"([\s\S]*?)}([\s\S]*?){/aspcms:" + str + "}";
            string labelRuleField = @"\[" + str + @":([\s\S]+?)\]";
            regExpObj = new Regex(labelRule);
            MatchCollection matches = regExpObj.Matches(content);
            foreach (Match match in matches)
            {
                string labelStr = match.Groups[1].Value;
                string loopStr = match.Groups[2].Value;
                Dictionary<string, string> labelArr = parseArr(labelStr);
                int lnum = 10;
                string ltype = "";
                string whereType = "";
                string lsort = "";
                string sortStr = "";
                string whereSort = "";
                string lorder = "";
                string orderStr = "";
                string whereTime = "";
                if (!labelArr.ContainsKey("num") || string.IsNullOrEmpty(labelArr["num"]))
                {
                    lnum = 10;
                }
                else
                {
                    lnum = int.Parse(labelArr["num"]);
                }
                if (!labelArr.ContainsKey("type") || string.IsNullOrEmpty(labelArr["type"]))
                {
                    ltype = "all";
                }
                else
                {
                    ltype = labelArr["type"];
                }
                if (ltype != "all")
                {
                    if (int.Parse(ltype) == 1)
                    {
                        whereType = " and len(ImagePath)=0 ";
                    }
                    else if (int.Parse(ltype) == 2)
                    {
                        whereType = " and len(ImagePath)>0";
                    }
                }
                else
                {
                    whereType = "";
                }
                if (!labelArr.ContainsKey("sort") || string.IsNullOrEmpty(labelArr["sort"]))
                {
                    lsort = "all";
                }
                else
                {
                    lsort = labelArr["sort"];
                }
                if (lsort != "all")
                {
                    if (lsort.IndexOf(",") > 0)
                    {
                        sortStr = CommonFunction.GetSmallestChild("Aspcms_NewsSort", lsort);
                    }
                    else
                    {
                        sortStr = lsort;
                    }
                    whereSort = " and SortID in (" + CommonFunction.GetSmallestChild("Aspcms_NewsSort", sortStr) + ")";
                }
                else
                {
                    whereSort = "";
                }

                if (!labelArr.ContainsKey("order") || string.IsNullOrEmpty(labelArr["order"]))
                {
                    lorder = "time";
                }
                else
                {
                    lorder = labelArr["order"];
                }
                switch (lorder)
                {
                    case "id":
                        orderStr = " order by IsTop,isrecommend,NewsID desc";
                        break;
                    case "visits":
                        orderStr = " order by IsTop,isrecommend,Visits desc";
                        break;
                    case "time":
                        orderStr = " order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "top":
                        orderStr = " order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "istop":
                        orderStr = " and IsTop=true order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "isrecommend":
                        orderStr = " and isrecommend=true order by  IsTop,isrecommend,AddTime desc";
                        break;
                    case "order":
                        orderStr = " order by IsTop,isrecommend, NewsOrder,AddTime desc";
                        break;
                }
                if (labelArr.ContainsKey("time"))
                {
                    switch (labelArr["time"])
                    {
                        case "day": whereTime = " and  DateDiff('d',AddTime,date())=0";
                            break;
                        case "week": whereTime = " and  DateDiff('w',AddTime,date())=0";
                            break;
                        case "month": whereTime = " and  DateDiff('m',AddTime,date())=0";
                            break;
                        default: whereTime = "";
                            break;
                    }
                }
                string Sql = "";
                if (str == "news" || str == "product" || str == "down" || str == "pic")
                {
                    Sql = "select top " + lnum + " NewsID,Title,IsOutLink,Visits,ImagePath,AddTime,OutLink,Content,SortID,TitleColor,IsTop,isrecommend from Aspcms_News where NewsStatus=true " + whereType + whereSort + whereTime + orderStr;

                }
                else if (str == "about")
                {
                    Sql = "select top 1 Content,NewsID,SortID,Title from Aspcms_News where SortID=" + lsort;
                }
                else if (str == "type")
                {
                    Sql = "select SortName,SortURL,SortStyle from Aspcms_NewsSort where  SortID=" + lsort;
                }
                else if (str == "job")
                {
                    Sql = "select top " + lnum + " JobID,SortID,Title,Title2,JobTag,Content,JobStatus,AddTime from Aspcms_Job where JobStatus order by AddTime";
                }
                else if (str == "gbook")
                {
                    Sql = "select top " + lnum + " FaqID,FaqTitle,Contact,ContactWay,Content,Reply,AddTime,ReplyTime,FaqStatus,AuditStatus from Aspcms_Faq where FaqStatus order by AddTime";
                }
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                regExpObj = new Regex(labelRuleField);
                MatchCollection matchesfield = regExpObj.Matches(loopStr);
                string loopstrTotal = "";
                if (dt.Rows.Count > 0)
                {
                    lnum = dt.Rows.Count;
                }
                else
                {
                    lnum = -1;
                }
                string nloopstr, fieldNameArr, fieldName, fieldArr, timestyle;
                int namelen = 8;
                int infolen = 200;
                for (int i = 0; i < lnum; i++)
                {
                    nloopstr = loopStr;
                    foreach (Match matchfield in matchesfield)
                    {
                        fieldNameArr = regExpReplace(matchfield.Groups[1].Value, @"[\s]+", ((char)32).ToString()).Trim();
                        int m = fieldNameArr.IndexOf((char)32);
                        if (m > 0)
                        {
                            fieldName = fieldNameArr.Substring(0, m);
                            fieldArr = fieldNameArr.Substring(m + 1);
                        }
                        else
                        {
                            fieldName = fieldNameArr;
                            fieldArr = "";
                        }

                        #region if (str == "news" || str == "product" || str == "down" || str == "pic")
                        if (str == "news" || str == "product" || str == "down" || str == "pic")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    if (dt.Rows[i]["IsOutLink"].ToString() == "1")
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["OutLink"].ToString());
                                    }
                                    else
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt.Rows[i]["SortID"].ToString(), dt.Rows[i]["NewsID"].ToString(), str));
                                    }
                                    break;
                                case "title":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 8;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }
                                    string title = "";

                                    title = StringUtil.cutstring(dt.Rows[i]["Title"].ToString(), namelen);

                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "titlecolor":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["titlecolor"].ToString());
                                    break;
                                case "istop":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["istop"].ToString());
                                    break;
                                case "isrecommend":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["isrecommend"].ToString());
                                    break;
                                case "desc":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        infolen = 200;
                                    }
                                    else
                                    {
                                        infolen = int.Parse(parseArr(fieldArr)["len"]);
                                    }

                                    nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(StringUtil.DecodeHtml(dt.Rows[i]["Content"].ToString()), "html"), infolen));
                                    break;
                                case "visits":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Visits"].ToString());
                                    break;
                                case "sortname":
                                    nloopstr = nloopstr.Replace(matchfield.Value, plSort(dt.Rows[i]["SortID"].ToString()));
                                    break;
                                case "pic":
                                    if (!string.IsNullOrEmpty(dt.Rows[i]["ImagePath"].ToString()))
                                    {
                                        if (dt.Rows[i]["ImagePath"].ToString().IndexOf("http://") > 0)
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["ImagePath"].ToString());
                                        }
                                        else
                                        {
                                            nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["ImagePath"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        nloopstr = nloopstr.Replace(matchfield.Value, "/" + sitePath + "images_sys/nopic.gif");
                                    }
                                    break;
                                case "date":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }
                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #region else if (str == "type")
                        else if (str == "type")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    nloopstr = nloopstr.Replace(matchfield.Value, getUrl(dt.Rows[i]["SortStyle"].ToString(), lsort, dt.Rows[i]["SortURL"].ToString()));
                                    break;
                                case "name":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 200;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(parseArr(fieldArr)["len"]);
                                    }
                                    nloopstr = nloopstr.Replace(matchfield.Value, Common.StringUtil.cutstring(dt.Rows[i]["SortName"].ToString(), namelen));
                                    break;
                            }
                        }
                        #endregion

                        #region else if (str == "about")
                        else if (str == "about")
                        {
                            switch (fieldName)
                            {
                                case "info":
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        infolen = 200;
                                    }
                                    else
                                    {
                                        infolen = int.Parse(parseArr(fieldArr)["len"]);
                                    }
                                    nloopstr = nloopstr.Replace(matchfield.Value, StringUtil.cutstring(StringUtil.FilterStr(StringUtil.ClearHtmlCode(StringUtil.DecodeHtml(dt.Rows[i]["Content"].ToString())), "html"), infolen));
                                    break;
                                case "link":
                                    break;
                                case "title":
                                    break;
                            }
                        }
                        #endregion

                        #region  else if (str == "job")
                        else if (str == "job")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    nloopstr = nloopstr.Replace(matchfield.Value, getShowLink(dt.Rows[i]["SortID"].ToString(), dt.Rows[i]["JobID"].ToString(), str));
                                    break;
                                case "title":
                                    string title = "";
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 15;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }
                                    title = StringUtil.cutstring(dt.Rows[i]["Title"].ToString(), namelen);
                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "name":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Contact"].ToString());
                                    break;
                                case "status":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["JobStatus"].ToString());
                                    break;
                                case "winfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Content"].ToString());
                                    break;
                                case "wdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "mm-dd";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }

                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                            }
                        }
                        #endregion

                        #region  else if (str == "gbook")
                        else if (str == "gbook")
                        {
                            switch (fieldName)
                            {
                                case "i":
                                    nloopstr = nloopstr.Replace(matchfield.Value, (i + 1).ToString());
                                    break;
                                case "link":
                                    //                                'if rsObj(5)=1 then nloopstr = replace(nloopstr,matchfield.value,rsObj(9)) : else nloopstr = replace(nloopstr,matchfield.value,getShowLink(DateArray(0,i),DateArray(0,i),showType))
                                    break;
                                case "title":
                                    string title = "";
                                    Dictionary<string, string> direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("len") || string.IsNullOrEmpty(direction["len"]))
                                    {
                                        namelen = 15;
                                    }
                                    else
                                    {
                                        namelen = int.Parse(direction["len"]);
                                    }

                                    title = StringUtil.cutstring(dt.Rows[i]["FaqTitle"].ToString(), namelen);


                                    nloopstr = nloopstr.Replace(matchfield.Value, title);
                                    break;
                                case "name":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["Contact"].ToString());
                                    break;
                                case "status":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[i]["FaqStatus"].ToString());
                                    break;
                                case "winfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Content"].ToString());
                                    break;
                                case "rinfo":
                                    nloopstr = nloopstr.Replace(matchfield.Value, dt.Rows[0]["Reply"].ToString());
                                    break;
                                case "wdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }

                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["AddTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                                case "rdate":
                                    direction = parseArr(fieldArr);
                                    if (!direction.ContainsKey("style") || string.IsNullOrEmpty(direction["style"]))
                                    {
                                        timestyle = "m-d";
                                    }
                                    else
                                    {
                                        timestyle = parseArr(fieldArr)["style"];
                                    }
                                    switch (timestyle)
                                    {
                                        case "yy-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("yy-m-d"));
                                            break;
                                        case "y-m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("y-m-d"));
                                            break;
                                        case "m-d":
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString("m-d"));
                                            break;
                                        default:
                                            nloopstr = nloopstr.Replace(matchfield.Value, DateUtil.ConvertStringToDate(dt.Rows[i]["ReplyTime"].ToString()).ToString(timestyle)); break;
                                    }
                                    break;
                            }
                        }
                        #endregion
                    }
                    loopstrTotal = loopstrTotal + nloopstr;
                }
                content = content.Replace(match.Value, loopstrTotal);
                strDictionary.Clear();
            }
        }


        public string GetSpecialList(string Special, string SortId, int page)
        {
            DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL,ParentID,(select count(*) from AspCms_NewsSort where ParentID=t.SortID),topsortid from Aspcms_NewsSort as t where  SortStyle<>2 and SortStyle<>5 and SortID=" + SortId + " and InStr(Special,SpecialId) ").Tables[0];
            if (dtSort.Rows.Count <= 0)
            {
                throw new Exception("参数不正确");
            }
            string style = Dir(dtSort.Rows[0]["SortStyle"].ToString());
            string listTemplateName = dtSort.Rows[0]["SortTemplate"].ToString();
            string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + listTemplateName;
            templatePath = templatePath.Replace("//", "/");
            DataTable dt = DBUtility.OleDbHelper.Query("select * from Aspcms_News where NewsStatus and SortID in (" + Common.CommonFunction.GetSmallestChild("Aspcms_NewsSort", SortId) + ")").Tables[0];

            Load(templatePath);
            parseHtml();
            parsePosition(SortId);

            content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
            content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["ParentID"].ToString());
            content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
            content = content.Replace("{aspcms:sortid}", SortId);
            parseList(SortId, page, style + "list", "", style);
            parseCommon();
            return content;

        }


        public string GetSpecialContent(string SpecialId, string SortId, string Id, int page)
        {
            try
            {

                DataTable dtSort = DBUtility.OleDbHelper.Query("select top 1 sortID,SortStyle,SortName,SortTemplate,SortContentTemplate,SortURL, ParentID,topsortid from Aspcms_NewsSort where   SortID=" + SortId).Tables[0];
                if (dtSort.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！1");
                }
                string style = Dir(dtSort.Rows[0]["SortStyle"].ToString());
                string contentTemplateName = dtSort.Rows[0]["SortContentTemplate"].ToString();
                string templatePath = "/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/" + contentTemplateName;
                templatePath = templatePath.Replace("//", "/");
                Load(templatePath);
                parseHtml();
                if (content.IndexOf("{aspcms:comment}") > 0)
                {
                    if (switchComments == "1")
                    {

                        string tempContent = content;
                        Load("/" + sitePath + "templates/" + defaultTemplate + "/" + htmlFilePath + "/plug/comment.html");
                        tempContent = tempContent.Replace("{aspcms:comment}", content);//	'加载评论模板
                        content = tempContent;
                    }
                    else
                    {
                        content = content.Replace("{aspcms:comment}", "");//	'加载评论模板
                    }
                }

                content = content.Replace("{aspcms:sortname}", dtSort.Rows[0]["SortName"].ToString());
                content = content.Replace("{aspcms:parentsortid}", dtSort.Rows[0]["parentID"].ToString());
                content = content.Replace("{aspcms:sortid}", SortId);
                content = content.Replace("{aspcms:topsortid}", dtSort.Rows[0]["topsortid"].ToString());
                parsePosition(SortId);
                parseCommon();

                parsePrevAndNext(Id, SortId);

                string sperStr = "";
                string sperCol = "";

                DataTable dtSper = DBUtility.OleDbHelper.Query("select SpecField from   Aspcms_SpecSet where SpecType='" + style + "'  Order by SpecOrder Asc,SpecID").Tables[0];
                foreach (DataRow dr in dtSper.Rows)
                {
                    sperStr += "," + dr["SpecField"].ToString();
                    sperCol += "," + style + "_" + dr["SpecField"].ToString();
                }
                string Sql = "";

                Sql = "select Title,Title2,TitleColor,NewsSource,[Content],Author,AddTime,NewsTag,Visits,ImagePath,downurl" + sperCol + " from Aspcms_News where NewsStatus=true and NewsID=" + Id;
                DataTable dt = DBUtility.OleDbHelper.Query(Sql).Tables[0];
                if (dt.Rows.Count <= 0)
                {
                    throw new Exception("参数错误！" + Sql);
                }
                content = content.Replace("[" + style + ":id]", Id);
                content = content.Replace("[" + style + ":title]", dt.Rows[0]["Title"].ToString());
                content = content.Replace("[" + style + ":subtitle]", dt.Rows[0]["Title2"].ToString());
                content = content.Replace("[" + style + ":author]", dt.Rows[0]["Author"].ToString());
                content = content.Replace("[" + style + ":source]", dt.Rows[0]["NewsSource"].ToString());
                content = content.Replace("[" + style + ":date]", dt.Rows[0]["AddTime"].ToString());
                content = content.Replace("[" + style + ":visits]", dt.Rows[0]["Visits"].ToString());
                content = content + "<script src=\"/" + sitePath + "inc/visitsAdd.ashx?id=" + Id + "\"></script>";
                content = content.Replace("[" + style + ":tag]", dt.Rows[0]["NewsTag"].ToString());
                content = content.Replace("[" + style + ":color]", dt.Rows[0]["TitleColor"].ToString());
                if (dt.Rows[0]["ImagePath"].ToString().Trim() != "")
                {
                    content = content.Replace("[" + style + ":pic]", dt.Rows[0]["ImagePath"].ToString());
                }
                else
                {
                    content = content.Replace("[" + style + ":pic]", "/" + sitePath + "images_sys/nopic.gif");
                }


                content = content.Replace("[" + style + ":downurl]", dt.Rows[0]["downurl"].ToString());
                if (style == "product" || style == "news" || style == "job")
                {
                    string[] sperStrsArr = sperStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] sperColsArr = sperCol.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < sperStrsArr.Length; i++)
                    {
                        content = content.Replace("[" + style + ":" + sperStrsArr[i] + "]", dt.Rows[0][sperColsArr[i]].ToString());
                    }
                }
                string newsContent = Common.StringUtil.DecodeHtml(dt.Rows[0]["Content"].ToString());

                if (newsContent.IndexOf("{aspcms:page}") > 0)
                {
                    string pageStr = "";
                    string[] newsContentArr = newsContent.Split(new string[] { "{aspcms:page}" }, StringSplitOptions.RemoveEmptyEntries);
                    if (page > newsContentArr.Length)
                    {
                        page = newsContentArr.Length;
                    }
                    if (page >= 2)
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_" + (page - 1) + FileExt + "'>上一页</a>";
                    }
                    else
                    {
                        pageStr = pageStr + "<div class='pages'><a href='" + runstr + SortId + "_" + Id + "_1" + FileExt + "'>上一页</a>";
                    }
                    pageStr = pageStr + makePageNumber(page, 10, newsContentArr.Length, "gbook", SortId);
                    if (page == newsContentArr.Length)
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (newsContentArr.Length) + FileExt + "'>下一页</a></div>";
                    }
                    else
                    {
                        pageStr = pageStr + "<a href='" + runstr + SortId + "_" + Id + "_" + (page + 1) + FileExt + "'>下一页</a></div>";
                    }
                    content = content.Replace("[" + style + ":info]", newsContentArr[page - 1] + pageStr);
                }
                else
                {
                    content = content.Replace("[" + style + ":info]", newsContent);
                }
                content = content.Replace("[" + style + ":desc]", Common.StringUtil.cutstring(Common.StringUtil.ClearHtmlCode(newsContent), 100));

                return (content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}

