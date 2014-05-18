using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;
namespace Common
{
    
    /// <summary>
    /// „÷ЈыіЃ≤ў„чє§ЊяЉѓ
    /// </summary>
    public class StringUtil
    {
        static string str = "=|%|?" + (char)32 + "|" + (char)34 + "|&|;|,|'|$| |" + (char)9 + "|#|£§|@|-|";

        public StringUtil()
        {
            //
            // TODO: ‘ЏіЋі¶ћнЉ”єє‘мЇѓ э¬яЉ≠
            //			
        }

        /// <summary>
        /// і”„÷ЈыіЃ÷–µƒќ≤≤њ…Њ≥э÷Єґ®µƒ„÷ЈыіЃ
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="removedString"></param>
        /// <returns></returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                    throw new Exception("‘≠„÷ЈыіЃ÷–≤ї∞ьЇђ“∆≥э„÷ЈыіЃ£°");
                string result = sourceString;
                int lengthOfSourceString = sourceString.Length;
                int lengthOfRemovedString = removedString.Length;
                int startIndex = lengthOfSourceString - lengthOfRemovedString;
                string tempSubString = sourceString.Substring(startIndex);
                if (tempSubString.ToUpper() == removedString.ToUpper())
                {
                    result = sourceString.Remove(startIndex, lengthOfRemovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }

        /// <summary>
        /// їс»°≤рЈ÷Јы”“±яµƒ„÷ЈыіЃ
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string RightSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[tempString.Length - 1].ToString();
            }
            return result;
        }

        /// <summary>
        /// їс»°≤рЈ÷Јы„у±яµƒ„÷ЈыіЃ
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string LeftSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[0].ToString();
            }
            return result;
        }

        /// <summary>
        /// »•µф„оЇу“їЄцґЇЇ≈
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string DelLastComma(string origin)
        {
            if (origin.IndexOf(",") == -1)
            {
                return origin;
            }
            return origin.Substring(0, origin.LastIndexOf(","));
        }

        /// <summary>
        /// …Њ≥э≤їњ…Љы„÷Јы
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(string sourceString)
        {
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder(131);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 16)
                {
                    sBuilder.Append(sourceString[i].ToString());
                }
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// їс»° э„й‘™ЋЎµƒЇѕ≤Ґ„÷ЈыіЃ
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public static string GetArrayString(string[] stringArray)
        {
            string totalString = null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                totalString = totalString + stringArray[i];
            }
            return totalString;
        }

        /// <summary>
        ///		їс»°ƒ≥“ї„÷ЈыіЃ‘Џ„÷ЈыіЃ э„й÷–≥цѕ÷µƒіќ э
        /// </summary>
        /// <param name="stringArray" type="string[]">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <returns>
        ///     A int value...
        /// </returns>
        public static int GetStringCount(string[] stringArray, string findString)
        {
            int count = -1;
            string totalString = GetArrayString(stringArray);
            string subString = totalString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = totalString.Substring(subString.IndexOf(findString));
                count += 1;
            }
            return count;
        }

        /// <summary>
        ///     їс»°ƒ≥“ї„÷ЈыіЃ‘Џ„÷ЈыіЃ÷–≥цѕ÷µƒіќ э
        /// </summary>
        /// <param name="stringArray" type="string">
        ///     <para>
        ///         ‘≠„÷ЈыіЃ
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         ∆•≈д„÷ЈыіЃ
        ///     </para>
        /// </param>
        /// <returns>
        ///     ∆•≈д„÷ЈыіЃ эЅњ
        /// </returns>
        public static int GetStringCount(string sourceString, string findString)
        {
            int count = 0;
            int findStringLength = findString.Length;
            string subString = sourceString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count += 1;
            }
            return count;
        }

        /// <summary>
        /// љЎ»°і”startStringњ™ Љµљ‘≠„÷ЈыіЃљбќ≤µƒЋщ”–„÷Јы   
        /// </summary>
        /// <param name="sourceString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="startString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <returns>
        ///     A string value...
        /// </returns>
        public static string GetSubString(string sourceString, string startString)
        {
            try
            {
                int index = sourceString.ToUpper().IndexOf(startString);
                if (index > 0)
                {
                    return sourceString.Substring(index);
                }
                return sourceString;
            }
            catch
            {
                return "";
            }
        }

        public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
        {
            try
            {
                if (sourceString.IndexOf(beginRemovedString) != 0)
                    beginRemovedString = "";

                if (sourceString.LastIndexOf(endRemovedString, sourceString.Length - endRemovedString.Length) < 0)
                    endRemovedString = "";

                int startIndex = beginRemovedString.Length;
                int length = sourceString.Length - beginRemovedString.Length - endRemovedString.Length;
                if (length > 0)
                {
                    return sourceString.Substring(startIndex, length);
                }
                return sourceString;
            }
            catch
            {
                return sourceString; ;
            }
        }

        /// <summary>
        /// ∞і„÷љЏ э»°≥ц„÷ЈыіЃµƒ≥§ґ»
        /// </summary>
        /// <param name="strTmp">“™Љ∆Ћгµƒ„÷ЈыіЃ</param>
        /// <returns>„÷ЈыіЃµƒ„÷љЏ э</returns>
        public static int GetByteCount(string strTmp)
        {
            int intCharCount = 0;
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intCharCount = intCharCount + 2;
                }
                else
                {
                    intCharCount = intCharCount + 1;
                }
            }
            return intCharCount;
        }

        /// <summary>
        /// ∞і„÷љЏ э“™‘Џ„÷ЈыіЃµƒќї÷√
        /// </summary>
        /// <param name="intIns">„÷ЈыіЃµƒќї÷√</param>
        /// <param name="strTmp">“™Љ∆Ћгµƒ„÷ЈыіЃ</param>
        /// <returns>„÷љЏµƒќї÷√</returns>
        public static int GetByteIndex(int intIns, string strTmp)
        {
            int intReIns = 0;
            if (strTmp.Trim() == "")
            {
                return intIns;
            }
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intReIns = intReIns + 2;
                }
                else
                {
                    intReIns = intReIns + 1;
                }
                if (intReIns >= intIns)
                {
                    intReIns = i + 1;
                    break;
                }
            }
            return intReIns;
        }
        /// <summary>
        /// ≈–ґѕ эЊЁ «Јсќ™ э÷µја–Ќ
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool isNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region їс»°IP
        public static string GetUserIpAddress(System.Web.HttpContext context)
        {
            string result = String.Empty;
            if (context == null) return result;

            result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            return result;
        }
        #endregion

        #region єэ¬Ћќ£ѕ’ эЊЁњв„÷Јы
        /// <summary>
        /// єэ¬Ћќ£ѕ’ эЊЁњв„÷Јы
        /// </summary>
        /// <param name="objString">“™єэ¬Ћµƒќ£ѕ’„÷Јы</param>
        public static string ReplaceDangerString(string objString)
        {
            objString = objString.Trim();
            objString = objString.Replace("%", "");
            objString = objString.Replace("'", "");
            objString = objString.Replace("=", "");
            objString = objString.Replace(">", "");
            objString = objString.Replace("<", "");
            objString = objString.Replace("+", "");
            objString = objString.Replace("&", "");
            objString = objString.Replace("\"", "");
            objString = objString.Replace("--", "");
            return objString;
        }
        #endregion

        #region HTML іъ¬лєэ¬Ћ
        public static string ClearHtmlCode(string text)
        {
            Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
            Regex regex6 = new Regex(@"\<img[^\>]+\>", RegexOptions.IgnoreCase);
            Regex regex7 = new Regex(@"</p>", RegexOptions.IgnoreCase);
            Regex regex8 = new Regex(@"<p>", RegexOptions.IgnoreCase);
            Regex regex9 = new Regex(@"<[^>]*>", RegexOptions.IgnoreCase);

            Regex regex10 = new Regex(@"[\s]{2,}", RegexOptions.IgnoreCase);
            Regex regex11 = new Regex(@"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", RegexOptions.IgnoreCase);
            Regex regex12 = new Regex(@"(\s*&[n|N][b|B][s|S][p|P];\s*)+", RegexOptions.IgnoreCase);
            Regex regex13 = new Regex(@"<(.|\n)*?>", RegexOptions.IgnoreCase);
            Regex regex14 = new Regex(@"/<\/?[^>]*>/g", RegexOptions.IgnoreCase);
            Regex regex15 = new Regex(@"/[    | ]* /g", RegexOptions.IgnoreCase);
            Regex regex16 = new Regex(@"/ [\s| |    ]* /g", RegexOptions.IgnoreCase);

            text = regex1.Replace(text, string.Empty);                    //єэ¬Ћ<script></script>±кЉ« 
            text = regex2.Replace(text, string.Empty);                    //єэ¬Ћhref=javascript: (<A>)  ф–‘ 
            text = regex3.Replace(text, " _disibledevent=");    //єэ¬Ћ∆дЋьњЎЉюµƒon... ¬Љю 
            text = regex4.Replace(text, string.Empty);                    //єэ¬Ћiframe 
            text = regex5.Replace(text, string.Empty);                    //єэ¬Ћframeset 
            text = regex6.Replace(text, string.Empty);                    //єэ¬Ћframeset 
            text = regex7.Replace(text, string.Empty);                    //єэ¬Ћframeset 
            text = regex8.Replace(text, string.Empty);                    //єэ¬Ћframeset 
            text = regex9.Replace(text, string.Empty);
            text = regex10.Replace(text, " ");                            //ЅљЄцїт’яЄьґаµƒњ’Єс
            text = regex11.Replace(text, string.Empty);                   //<br>
            text = regex12.Replace(text, " ");                            //&nbsp;
            text = regex13.Replace(text, string.Empty);                   // ∆дЋы±кЉ«
            text = regex14.Replace(text, string.Empty);                   // ∆дЋы±кЉ«
            text = regex15.Replace(text, string.Empty);                   // ∆дЋы±кЉ«
            text = regex16.Replace(text, string.Empty);                   // ∆дЋы±кЉ«


            text = text.Replace(" ", "");
            text = text.Replace("</strong>", "");
            text = text.Replace("<strong>", "");

            return text;
        }


        public static string EncodeHtml(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                str=str.Replace("<","&lt;");
                str=str.Replace(">","&gt;");
                str=str.Replace(((char)34).ToString(),"&quot;");
                str=str.Replace(((char)39).ToString(),"&apos;");
                return str;
            }
            
        }
        public static string DecodeHtml(string str)
        {
             if(string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                str=str.Replace("&lt;","<");
                str=str.Replace("&gt;",">");
                str=str.Replace("&quot;",((char)34).ToString());
                str=str.Replace("&apos;",((char)39).ToString());
                return str;
            }
        }

        public static string FilterStr(string str, string filtertype)
        {
            string rulestr = "";
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            switch (filtertype)
            {
                case "html":
                    rulestr = @"(<[a-zA-Z].*?>)|(<[\/][a-zA-Z].*?>)";
                    break;
                case "jsiframe":
                    rulestr = @"(<(script|iframe).*?>)|(<[\/](script|iframe).*?>)";
                    break;

            }
            Regex regObj = new Regex(rulestr);
            return regObj.Replace(str, "");
        }
        

        #endregion

        #region ѕё÷∆„÷Јыѕ‘ Њ≥§ґ»£ђ”√”Џѕё÷∆±кћвµ»“ї–©ќƒ±Њµƒѕ‘ Њ≥§ґ»
        /// <summary>
        /// ѕё÷∆„÷Јыѕ‘ Њ≥§ґ»£ђ”√”Џѕё÷∆±кћвµ»“ї–©ќƒ±Њµƒѕ‘ Њ≥§ґ»
        /// </summary>
        /// <param name="inputstr">–и“™ѕё÷∆µƒ„÷Јы</param>
        /// <param name="len">ѕё÷∆µƒ≥§ґ»</param>
        /// <returns></returns>
        public static string cutstring(string inputstr, int len)
        {
            ASCIIEncoding asci = new ASCIIEncoding();
            int strlen = 0;
            string str = null;
            byte[] s = asci.GetBytes(inputstr);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    strlen += 2;
                }
                else
                {
                    strlen += 1;
                }
                try
                {
                    str += inputstr.Substring(i, 1);
                }
                catch
                {
                    break;
                }
                if (strlen > len)
                    break;
            }
            byte[] mybyte = Encoding.Default.GetBytes(inputstr);
            if (mybyte.Length > len)
            {
                str += "...";
            }
            return str;
        }
        #endregion

        /// <summary>
        /// ≈–ґѕ «ЈсЇђ”–Ј«Ј®„÷Јы
        /// </summary>
        /// <param name="objgString"></param>
        /// <returns></returns>
        public static bool IsDangerString(string objString)
        {
            if (objString.IndexOfAny(str.ToCharArray())!=-1)
                return true;
            else
                return false;
        }

        #region ЄщЊЁЇЇ„÷їс»°∆і“ф¬л

        /// <summary>
        /// ЄщЊЁЇЇ„÷їс»°∆і“ф¬л
        /// </summary>
        /// <param name="hz">іЂ»лЇЇ„÷≤ќ э</param>
        /// <returns></returns>
        public static string GetFirstLetter(string hz)
        {

            string ls_second_eng = "CJWGNSPGCGNESYPBTYYZDXYKYGTDJNNJQMBSGZSCYJSYYQPGKBZGYCYWJKGKLJSWKPJQHYTWDDZLSGMRYPYWWCCKZNKYDGTTNGJEYKKZYTCJNMCYLQLYPYQFQRPZSLWBTGKJFYXJWZLTBNCXJJJJZXDTTSQZYCDXXHGCKBPHFFSSWYBGMXLPBYLLLHLXSPZMYJHSOJNGHDZQYKLGJHSGQZHXQGKEZZWYSCSCJXYEYXADZPMDSSMZJZQJYZCDJZWQJBDZBXGZNZCPWHKXHQKMWFBPBYDTJZZKQHYLYGXFPTYJYYZPSZLFCHMQSHGMXXSXJJSDCSBBQBEFSJYHWWGZKPYLQBGLDLCCTNMAYDDKSSNGYCSGXLYZAYBNPTSDKDYLHGYMYLCXPYCJNDQJWXQXFYYFJLEJBZRXCCQWQQSBNKYMGPLBMJRQCFLNYMYQMSQTRBCJTHZTQFRXQ" +
            "HXMJJCJLXQGJMSHZKBSWYEMYLTXFSYDSGLYCJQXSJNQBSCTYHBFTDCYZDJWYGHQFRXWCKQKXEBPTLPXJZSRMEBWHJLBJSLYYSMDXLCLQKXLHXJRZJMFQHXHWYWSBHTRXXGLHQHFNMNYKLDYXZPWLGGTMTCFPAJJZYLJTYANJGBJPLQGDZYQYAXBKYSECJSZNSLYZHZXLZCGHPXZHZNYTDSBCJKDLZAYFMYDLEBBGQYZKXGLDNDNYSKJSHDLYXBCGHXYPKDJMMZNGMMCLGWZSZXZJFZNMLZZTHCSYDBDLLSCDDNLKJYKJSYCJLKOHQASDKNHCSGANHDAASHTCPLCPQYBSDMPJLPCJOQLCDHJJYSPRCHNWJNLHLYYQYYWZPTCZGWWMZFFJQQQQYXACLBHKDJXDGMMYDJXZLLSYGXGKJRYWZWYCLZMSSJZLDBYDCFCXYHLXCHYZJQSFQAGMNYXPFRKSSB" +
            "JLYXYSYGLNSCMHCWWMNZJJLXXHCHSYDSTTXRYCYXBYHCSMXJSZNPWGPXXTAYBGAJCXLYSDCCWZOCWKCCSBNHCPDYZNFCYYTYCKXKYBSQKKYTQQXFCWCHCYKELZQBSQYJQCCLMTHSYWHMKTLKJLYCXWHEQQHTQHZPQSQSCFYMMDMGBWHWLGSSLYSDLMLXPTHMJHWLJZYHZJXHTXJLHXRSWLWZJCBXMHZQXSDZPMGFCSGLSXYMJSHXPJXWMYQKSMYPLRTHBXFTPMHYXLCHLHLZYLXGSSSSTCLSLDCLRPBHZHXYYFHBBGDMYCNQQWLQHJJZYWJZYEJJDHPBLQXTQKWHLCHQXAGTLXLJXMSLXHTZKZJECXJCJNMFBYCSFYWYBJZGNYSDZSQYRSLJPCLPWXSDWEJBJCBCNAYTWGMPAPCLYQPCLZXSBNMSGGFNZJJBZSFZYNDXHPLQKZCZWALSBCCJXJYZGWKYP" +
            "SGXFZFCDKHJGXDLQFSGDSLQWZKXTMHSBGZMJZRGLYJBPMLMSXLZJQQHZYJCZYDJWBMJKLDDPMJEGXYHYLXHLQYQHKYCWCJMYYXNATJHYCCXZPCQLBZWWYTWBQCMLPMYRJCCCXFPZNZZLJPLXXYZTZLGDLDCKLYRZZGQTGJHHHJLJAXFGFJZSLCFDQZLCLGJDJCSNCLLJPJQDCCLCJXMYZFTSXGCGSBRZXJQQCTZHGYQTJQQLZXJYLYLBCYAMCSTYLPDJBYREGKLZYZHLYSZQLZNWCZCLLWJQJJJKDGJZOLBBZPPGLGHTGZXYGHZMYCNQSYCYHBHGXKAMTXYXNBSKYZZGJZLQJDFCJXDYGJQJJPMGWGJJJPKQSBGBMMCJSSCLPQPDXCDYYKYFCJDDYYGYWRHJRTGZNYQLDKLJSZZGZQZJGDYKSHPZMTLCPWNJAFYZDJCNMWESCYGLBTZCGMSSLLYXQSXSBSJS" +
            "BBSGGHFJLWPMZJNLYYWDQSHZXTYYWHMCYHYWDBXBTLMSYYYFSXJCSDXXLHJHFSSXZQHFZMZCZTQCXZXRTTDJHNNYZQQMNQDMMGYYDXMJGDHCDYZBFFALLZTDLTFXMXQZDNGWQDBDCZJDXBZGSQQDDJCMBKZFFXMKDMDSYYSZCMLJDSYNSPRSKMKMPCKLGDBQTFZSWTFGGLYPLLJZHGJJGYPZLTCSMCNBTJBQFKTHBYZGKPBBYMTTSSXTBNPDKLEYCJNYCDYKZDDHQHSDZSCTARLLTKZLGECLLKJLQJAQNBDKKGHPJTZQKSECSHALQFMMGJNLYJBBTMLYZXDCJPLDLPCQDHZYCBZSCZBZMSLJFLKRZJSNFRGJHXPDHYJYBZGDLQCSEZGXLBLGYXTWMABCHECMWYJYZLLJJYHLGBDJLSLYGKDZPZXJYYZLWCXSZFGWYYDLYHCLJSCMBJHBLYZLYCBLYDPDQYSXQZB" +
            "YTDKYXJYYCNRJMDJGKLCLJBCTBJDDBBLBLCZQRPXJCGLZCSHLTOLJNMDDDLNGKAQHQHJGYKHEZNMSHRPHQQJCHGMFPRXHJGDYCHGHLYRZQLCYQJNZSQTKQJYMSZSWLCFQQQXYFGGYPTQWLMCRNFKKFSYYLQBMQAMMMYXCTPSHCPTXXZZSMPHPSHMCLMLDQFYQXSZYJDJJZZHQPDSZGLSTJBCKBXYQZJSGPSXQZQZRQTBDKYXZKHHGFLBCSMDLDGDZDBLZYYCXNNCSYBZBFGLZZXSWMSCCMQNJQSBDQSJTXXMBLTXZCLZSHZCXRQJGJYLXZFJPHYMZQQYDFQJJLZZNZJCDGZYGCTXMZYSCTLKPHTXHTLBJXJLXSCDQXCBBTJFQZFSLTJBTKQBXXJJLJCHCZDBZJDCZJDCPRNPQCJPFCZLCLZXZDMXMPHJSGZGSZZQJYLWTJPFSYASMCJBTZKYCWMYTCSJJLJCQLWZM" +
            "ALBXYFBPNLSFHTGJWEJJXXGLLJSTGSHJQLZFKCGNNDSZFDEQFHBSAQTGLLBXMMYGSZLDYDQMJJRGBJTKGDHGKBLQKBDMBYLXWCXYTTYBKMRTJZXQJBHLMHMJJZMQASLDCYXYQDLQCAFYWYXQHZ";
            string ls_second_ch = "Ў°ЎҐЎ£Ў§Ў•Ў¶ЎІЎ®Ў©Ў™ЎЂЎђЎ≠ЎЃЎѓЎ∞Ў±Ў≤Ў≥ЎіЎµЎґЎЈЎЄЎєЎЇЎїЎЉЎљ" +
            "ЎЊЎњЎјЎЅЎ¬Ў√ЎƒЎ≈Ў∆Ў«Ў»Ў…Ў ЎЋЎћЎЌЎќЎѕЎ–Ў—Ў“Ў”Ў‘Ў’Ў÷Ў„ЎЎЎўЎЏЎџЎ№ЎЁЎёЎяЎаЎбЎвЎгЎдЎеЎжЎзЎиЎйЎкЎлЎмЎнЎоЎпЎрЎсЎтЎуЎфЎхЎцЎчЎшЎщЎъЎыЎьЎэЎюў°ўҐў£ў§ў•ў¶ўІў®ў©ў™ўЂўђў≠ўЃўѓў∞ў±ў≤ў≥ўіўµўґўЈўЄўєўЇўїўЉўљўЊўњўјўЅў¬ў√ўƒў≈ў∆ў«ў»ў…ў ўЋўћўЌўќўѕў–ў—ў“ў”ў‘ў’ў÷ў„ўЎўўўЏўџў№ўЁўёўяўаўбўвўгўдўеўжўзўиўйўкўлўмўнўоўпўрўсўтўуўфўхўцўчўшўщўъўыўьўэўюЏ°ЏҐЏ£Џ§Џ•Џ¶ЏІЏ®Џ©Џ™ЏЂЏђЏ≠ЏЃЏѓЏ∞Џ±Џ≤Џ≥ЏіЏµЏґЏЈЏЄЏєЏЇЏїЏЉЏљЏЊЏњЏјЏЅЏ¬Џ√ЏƒЏ≈Џ∆Џ«Џ»Џ…Џ ЏЋЏћЏЌЏќЏѕЏ–Џ—Џ“Џ”Џ‘Џ’Џ÷Џ„ЏЎЏўЏЏЏџЏ№ЏЁЏёЏяЏаЏбЏвЏгЏдЏеЏжЏзЏи" +
            "ЏйЏкЏлЏмЏнЏоЏпЏрЏсЏтЏуЏфЏхЏцЏчЏшЏщЏъЏыЏьЏэЏюџ°џҐџ£џ§џ•џ¶џІџ®џ©џ™џЂџђџ≠џЃџѓџ∞џ±џ≤џ≥џіџµџґџЈџЄџєџЇџїџЉџљџЊџњџјџЅџ¬џ√џƒџ≈џ∆џ«џ»џ…џ џЋџћџЌџќџѕџ–џ—џ“џ”џ‘џ’џ÷џ„џЎџўџЏџџџ№џЁџёџяџаџбџвџгџдџеџжџзџиџйџкџлџмџнџоџпџрџсџтџуџфџхџцџчџшџщџъџыџьџэџю№°№Ґ№£№§№•№¶№І№®№©№™№Ђ№ђ№≠№Ѓ№ѓ№∞№±№≤№≥№і№µ№ґ№Ј№Є№є№Ї№ї№Љ№љ№Њ№њ№ј№Ѕ№¬№√№ƒ№≈№∆№«№»№…№ №Ћ№ћ№Ќ№ќ№ѕ№–№—№“№”№‘№’№÷№„№Ў№ў№Џ№џ№№№Ё№ё№я№а№б№в№г№д№е№ж№з№и№й№к№л№м№н№о№п№р№с№т№у№ф№х№ц№ч№ш№щ№ъ№ы№ь№э№юЁ°ЁҐЁ£Ё§Ё•Ё¶ЁІЁ®Ё©Ё™ЁЂЁђЁ≠ЁЃЁѓЁ∞Ё±Ё≤Ё≥ЁіЁµЁґ" +
            "ЁЈЁЄЁєЁЇЁїЁЉЁљЁЊЁњЁјЁЅЁ¬Ё√ЁƒЁ≈Ё∆Ё«Ё»Ё…Ё ЁЋЁћЁЌЁќЁѕЁ–Ё—Ё“Ё”Ё‘Ё’Ё÷Ё„ЁЎЁўЁЏЁџЁ№ЁЁЁёЁяЁаЁбЁвЁгЁдЁеЁжЁзЁиЁйЁкЁлЁмЁнЁоЁпЁрЁсЁтЁуЁфЁхЁцЁчЁшЁщЁъЁыЁьЁэЁюё°ёҐё£ё§ё•ё¶ёІё®ё©ё™ёЂёђё≠ёЃёѓё∞ё±ё≤ё≥ёіёµёґёЈёЄёєёЇёїёЉёљёЊёњёјёЅё¬ё√ёƒё≈ё∆ё«ё»ё…ё ёЋёћёЌёќёѕё–ё—ё“ё”ё‘ё’ё÷ё„ёЎёўёЏёџё№ёЁёёёяёаёбёвёгёдёеёжёзёиёйёкёлёмёнёоёпёрёсётёуёфёхёцёчёшёщёъёыёьёэёюя°яҐя£я§я•я¶яІя®я©я™яЂяђя≠яЃяѓя∞я±я≤я≥яіяµяґяЈяЄяєяЇяїяЉяљяЊяњяјяЅя¬я√яƒя≈я∆я«я»я…я яЋяћяЌяќяѕя–я—я“я”я‘я’я÷я„яЎяўяЏяџя№яЁяёяяяаябявяг" +
            "ядяеяжязяияйякялямяняояпярясятяуяфяхяцячяшящяъяыяьяэяюа°аҐа£а§а•а¶аІа®а©а™аЂађа≠аЃаѓа∞а±а≤а≥аіаµаґаЈаЄаєаЇаїаЉаљаЊањајаЅа¬а√аƒа≈а∆а«а»а…а аЋаћаЌаќаѕа–а—а“а”а‘а’а÷а„аЎаўаЏаџа№аЁаёаяааабавагадаеажазаиайакаламанаоапарасатауафахацачашащаъаыаьаэаюб°бҐб£б§б•б¶бІб®б©б™бЂбђб≠бЃбѓб∞б±б≤б≥бібµбґбЈбЄбєбЇбїбЉбљбЊбњбјбЅб¬б√бƒб≈б∆б«б»б…б бЋбћбЌбќбѕб–б—б“б”б‘б’б÷б„бЎбўбЏбџб№бЁбёбябабббвбгбдбебжбзбибйбкблбмбнбобпбрбсбтбубфбхбцбчбшбщбъбыбьбэбюв°вҐв£в§в•в¶вІв®в©в™вЂвђв≠вЃвѓв∞в±в≤в≥вівµ" +
            "вґвЈвЄвєвЇвївЉвљвЊвњвјвЅв¬в√вƒв≈в∆в«в»в…в вЋвћвЌвќвѕв–в—в“в”в‘в’в÷в„вЎвўвЏвџв№вЁвёвявавбвввгвдвевжвзвивйвквлвмвнвовпврвсвтвувфвхвцвчвшвщвъвывьвэвюг°гҐг£г§г•г¶гІг®г©г™гЂгђг≠гЃгѓг∞г±г≤г≥гігµгґгЈгЄгєгЇгїгЉгљгЊгњгјгЅг¬г√гƒг≈г∆г«г»г…г гЋгћгЌгќгѕг–г—г“г”г‘г’г÷г„гЎгўгЏгџг№гЁгёгягагбгвгггдгегжгзгигйгкглгмгнгогпгргсгтгугфгхгцгчгшгщгъгыгьгэгюд°дҐд£д§д•д¶дІд®д©д™дЂдђд≠дЃдѓд∞д±д≤д≥дідµдґдЈдЄдєдЇдїдЉдљдЊдњдјдЅд¬д√дƒд≈д∆д«д»д…д дЋдћдЌдќдѕд–д—д“д”д‘д’д÷д„дЎдўдЏдџд№дЁдёдядадбдвдгдддедждзди" +
            "дйдкдлдмдндодпдрдсдтдудфдхдцдчдшдщдъдыдьдэдюе°еҐе£е§е•е¶еІе®е©е™еЂеђе≠еЃеѓе∞е±е≤е≥еіеµеґеЈеЄеєеЇеїеЉељеЊењејеЅе¬е√еƒе≈е∆е«е»е…е еЋећеЌеќеѕе–е—е“е”е‘е’е÷е„еЎеўеЏеџе№еЁеёеяеаебевегедееежезеиейекелеменеоепересетеуефехецечешещеъеыеьеэеюж°жҐж£ж§ж•ж¶жІж®ж©ж™жЂжђж≠жЃжѓж∞ж±ж≤ж≥жіжµжґжЈжЄжєжЇжїжЉжљжЊжњжјжЅж¬ж√жƒж≈ж∆ж«ж»ж…ж жЋжћжЌжќжѕж–ж—ж“ж”ж‘ж’ж÷ж„жЎжўжЏжџж№жЁжёжяжажбжвжгжджежжжзжижйжкжлжмжнжожпжржсжтжужфжхжцжчжшжщжъжыжьжэжюз°зҐз£з§з•з¶зІз®з©з™зЂзђз≠зЃзѓз∞з±з≤з≥зізµзґзЈзЄзєзЇзїзЉзљ" +
            "зЊзњзјзЅз¬з√зƒз≈з∆з«з»з…з зЋзћзЌзќзѕз–з—з“з”з‘з’з÷з„зЎзўзЏзџз№зЁзёзязазбзвзгздзезжзззизйзкзлзмзнзозпзрзсзтзузфзхзцзчзшзщзъзызьзэзюи°иҐи£и§и•и¶иІи®и©и™иЂиђи≠иЃиѓи∞и±и≤и≥иіиµиґиЈиЄиєиЇиїиЉиљиЊињијиЅи¬и√иƒи≈и∆и«и»и…и иЋићиЌиќиѕи–и—и“и”и‘и’и÷и„иЎиўиЏиџи№иЁиёияиаибивигидиеижизииийикилиминиоипириситиуифихицичишищиъиыиьиэиюй°йҐй£й§й•й¶йІй®й©й™йЂйђй≠йЃйѓй∞й±й≤й≥йійµйґйЈйЄйєйЇйїйЉйљйЊйњйјйЅй¬й√йƒй≈й∆й«й»й…й йЋйћйЌйќйѕй–й—й“й”й‘й’й÷й„йЎйўйЏйџй№йЁйёйяйайбйвйгйдйейжйзйийййкйлймйнйойпйрйсйтйу" +
            "йфйхйцйчйшйщйъйыйьйэйюк°кҐк£к§к•к¶кІк®к©к™кЂкђк≠кЃкѓк∞к±к≤к≥кікµкґкЈкЄкєкЇкїкЉкљкЊкњкјкЅк¬к√кƒк≈к∆к«к»к…к кЋкћкЌкќкѕк–к—к“к”к‘к’к÷к„кЎкўкЏкџк№кЁкёкякакбквкгкдкекжкзкикйккклкмкнкокпкркскткукфкхкцкчкшкщкъкыкькэкюл°лҐл£л§л•л¶лІл®л©л™лЂлђл≠лЃлѓл∞л±л≤л≥лілµлґлЈлЄлєлЇлїлЉлљлЊлњлјлЅл¬л√лƒл≈л∆л«л»л…л лЋлћлЌлќлѕл–л—л“л”л‘л’л÷л„лЎлўлЏлџл№лЁлёлялалблвлглдлелжлзлилйлклллмлнлолплрлслтлулфлхлцлчлшлщлълыльлэлюм°мҐм£м§м•м¶мІм®м©м™мЂмђм≠мЃмѓм∞м±м≤м≥мімµмґмЈмЄмємЇмїмЉмљмЊмњмјмЅм¬м√мƒм≈м∆м«м»м…м мЋмћмЌ" +
            "мќмѕм–м—м“м”м‘м’м÷м„мЎмўмЏмџм№мЁмёмямамбмвмгмдмемжмзмимймкмлмммнмомпмрмсмтмумфмхмцмчмшмщмъмымьмэмюн°нҐн£н§н•н¶нІн®н©н™нЂнђн≠нЃнѓн∞н±н≤н≥нінµнґнЈнЄнєнЇнїнЉнљнЊнњнјнЅн¬н√нƒн≈н∆н«н»н…н нЋнћнЌнќнѕн–н—н“н”н‘н’н÷н„нЎнўнЏнџн№нЁнёнянанбнвнгндненжнзнинйнкнлнмнннонпнрнснтнунфнхнцнчншнщнъныньнэнюо°оҐо£о§о•о¶оІо®о©о™оЂођо≠оЃоѓо∞о±о≤о≥оіоµоґоЈоЄоєоЇоїоЉољоЊоњојоЅо¬о√оƒо≈о∆о«о»о…о оЋоћоЌоќоѕо–о—о“о”о‘о’о÷о„оЎоўоЏоџо№оЁоёояоаобовогодоеожозоиойоколомонооопоросотоуофохоцочошощоъоыоьоэоюп°пҐп£п§п•п¶пІп®п©п™" +
            "пЂпђп≠пЃпѓп∞п±п≤п≥піпµпґпЈпЄпєпЇпїпЉпљпЊпњпјпЅп¬п√пƒп≈п∆п«п»п…п пЋпћпЌпќпѕп–п—п“п”п‘п’п÷п„пЎпўпЏпџп№пЁпёпяпапбпвпгпдпепжпзпипйпкплпмпнпопппрпсптпупфпхпцпчпшпщпъпыпьпэпюр°рҐр£р§р•р¶рІр®р©р™рЂрђр≠рЃрѓр∞р±р≤р≥рірµрґрЈрЄрєрЇрїрЉрљрЊрњрјрЅр¬р√рƒр≈р∆р«р»р…р рЋрћрЌрќрѕр–р—р“р”р‘р’р÷р„рЎрўрЏрџр№рЁрёрярарбрвргрдрержрзрирйркрлрмрнрорпрррсртрурфрхрцрчршрщрърырьрэрюс°сҐс£с§с•с¶сІс®с©с™сЂсђс≠сЃсѓс∞с±с≤с≥сісµсґсЈсЄсєсЇсїсЉсљсЊсњсјсЅс¬с√сƒс≈с∆с«с…с сЋсћсЌсќсѕс–с—с“с”с‘с’с÷с„сЎсўсЏсџс№сЁсёсясасвсгсдсесжсз" +
            "сисйскслсмснсоспсрссстсусфсхсцсчсшсщсъсысьсэсют°тҐт£т§т•т¶тІт®т©т™тЂтђт≠тЃтѓт∞т±т≤т≥тітµтґтЈтЄтєтЇтїтЉтљтЊтњтјтЅт¬т√тƒт≈т∆т«т»т…т тЋтћтЌтќтѕт–т—т“т”т‘т’т÷т„тЎтўтЏтџт№тЁтётятатбтвтгтдтетжтзтитйтктлтмтнтотптртстттутфтхтцтчтштщтътытьтэтюу°уҐу£у§у•у¶уІу®у©у™уЂуђу≠уЃуѓу∞у±у≤у≥уіуµуґуЈуЄуєуЇуїуЉуљуЊуњујуЅу¬у√уƒу≈у∆у«у»у…у уЋућуЌуќуѕу–у—у“у”у‘у’у÷у„уЎуўуЏуџу№уЁуёуяуаубувугудуеужузуиуйукулумунуоупурусутуууфухуцучушущуъуыуьуэуюф°фҐф£ф§ф•ф¶фІф®ф©ф™фЂфђф≠фЃфѓф∞ф±ф≤ф≥фіфµфґфЈфЄфєфЇфїфЉфљфЊфњфјфЅф¬ф√фƒф≈ф∆ф«" +
            "ф»ф…ф фЋфћфЌфќфѕф–ф—ф“ф”ф‘ф’ф÷ф„фЎфўфЏфџф№фЁфёфяфафбфвфгфдфефжфзфифйфкфлфмфнфофпфрфсфтфуфффхфцфчфшфщфъфыфьфэфюх°хҐх£х§х•х¶хІх®х©х™хЂхђх≠хЃхѓх∞х±х≤х≥хіхµхґхЈхЄхєхЇхїхЉхљхЊхњхјхЅх¬х√хƒх≈х∆х«х»х…х хЋхћхЌхќхѕх–х—х“х”х‘х’х÷х„хЎхўхЏхџх№хЁхёхяхахбхвхгхдхехжхзхихйхкхлхмхнхохпхрхсхтхухфхххцхчхшхщхъхыхьхэхюц°цҐц£ц§ц•ц¶цІц®ц©ц™цЂцђц≠цЃцѓц∞ц±ц≤ц≥ціцµцґцЈцЄцєцЇцїцЉцљцЊцњцјцЅц¬ц√цƒц≈ц∆ц«ц»ц…ц цЋцћцЌцќцѕц–ц—ц“ц”ц‘ц’ц÷ц„цЎцўцЏцџц№цЁцёцяцацбцвцгцдцецжцзцицйцкцлцмцнцоцпцрцсцтцуцфцхцццчцшцщцъцыцьцэцюч°чҐч£ч§ч•ч¶чІ" +
            "ч®ч©ч™чЂчђч≠чЃчѓч∞ч±ч≤ч≥чічµчґчЈчЄчєчЇчїчЉчљчЊчњчјчЅч¬ч√чƒч≈ч∆ч«ч»ч…ч чЋчћчЌчќчѕч–ч—ч“ч”ч‘ч’ч÷ч„чЎчўчЏчџч№чЁчёчячачбчвчгчдчечжчзчичйчкчлчмчнчочпчрчсчтчучфчхчцчччшчщчъчычьчэчю";
            byte[] array = new byte[2];

            string return_py = "";
            for (int i = 0; i < hz.Length; i++)
            {
                array = System.Text.Encoding.Default.GetBytes(hz[i].ToString());
                if (array[0] < 176) //.Ј«ЇЇ„÷ 
                {
                    return_py += hz[i];
                }
                else if (array[0] >= 176 && array[0] <= 215) //“їЉґЇЇ„÷ 
                {

                    if (hz[i].ToString().CompareTo("‘—") >= 0)
                        return_py += "z";
                    else if (hz[i].ToString().CompareTo("—є") >= 0)
                        return_py += "y";
                    else if (hz[i].ToString().CompareTo("ќф") >= 0)
                        return_py += "x";
                    else if (hz[i].ToString().CompareTo("ЌЏ") >= 0)
                        return_py += "w";
                    else if (hz[i].ToString().CompareTo("Ћъ") >= 0)
                        return_py += "t";
                    else if (hz[i].ToString().CompareTo("»ц") >= 0)
                        return_py += "s";
                    else if (hz[i].ToString().CompareTo("»ї") >= 0)
                        return_py += "r";
                    else if (hz[i].ToString().CompareTo("∆Џ") >= 0)
                        return_py += "q";
                    else if (hz[i].ToString().CompareTo("≈Њ") >= 0)
                        return_py += "p";
                    else if (hz[i].ToString().CompareTo("≈ґ") >= 0)
                        return_py += "o";
                    else if (hz[i].ToString().CompareTo("ƒ√") >= 0)
                        return_py += "n";
                    else if (hz[i].ToString().CompareTo("¬и") >= 0)
                        return_py += "m";
                    else if (hz[i].ToString().CompareTo("јђ") >= 0)
                        return_py += "l";
                    else if (hz[i].ToString().CompareTo("њ¶") >= 0)
                        return_py += "k";
                    else if (hz[i].ToString().CompareTo("їч") >= 0)
                        return_py += "j";
                    else if (hz[i].ToString().CompareTo("єю") >= 0)
                        return_py += "h";
                    else if (hz[i].ToString().CompareTo("ЄЅ") >= 0)
                        return_py += "g";
                    else if (hz[i].ToString().CompareTo("ЈҐ") >= 0)
                        return_py += "f";
                    else if (hz[i].ToString().CompareTo("ґк") >= 0)
                        return_py += "e";
                    else if (hz[i].ToString().CompareTo("іо") >= 0)
                        return_py += "d";
                    else if (hz[i].ToString().CompareTo("≤Ѕ") >= 0)
                        return_py += "c";
                    else if (hz[i].ToString().CompareTo("∞≈") >= 0)
                        return_py += "b";
                    else if (hz[i].ToString().CompareTo("∞°") >= 0)
                        return_py += "a";
                }
                else if (array[0] >= 215) //ґюЉґЇЇ„÷ 
                {
                    return_py += ls_second_eng.Substring(ls_second_ch.IndexOf(hz[i].ToString(), 0), 1);
                }
            }
            return return_py.ToUpper();
        }

        #endregion



     

    }

}
