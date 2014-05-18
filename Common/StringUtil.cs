using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Text;
namespace Common
{
    
    /// <summary>
    /// �ַ����������߼�
    /// </summary>
    public class StringUtil
    {
        static string str = "=|%|?" + (char)32 + "|" + (char)34 + "|&|;|,|'|$| |" + (char)9 + "|#|��|@|-|";

        public StringUtil()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //			
        }

        /// <summary>
        /// ���ַ����е�β��ɾ��ָ�����ַ���
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="removedString"></param>
        /// <returns></returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                    throw new Exception("ԭ�ַ����в������Ƴ��ַ�����");
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
        /// ��ȡ��ַ��ұߵ��ַ���
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
        /// ��ȡ��ַ���ߵ��ַ���
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
        /// ȥ�����һ������
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
        /// ɾ�����ɼ��ַ�
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
        /// ��ȡ����Ԫ�صĺϲ��ַ���
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
        ///		��ȡĳһ�ַ������ַ��������г��ֵĴ���
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
        ///     ��ȡĳһ�ַ������ַ����г��ֵĴ���
        /// </summary>
        /// <param name="stringArray" type="string">
        ///     <para>
        ///         ԭ�ַ���
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         ƥ���ַ���
        ///     </para>
        /// </param>
        /// <returns>
        ///     ƥ���ַ�������
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
        /// ��ȡ��startString��ʼ��ԭ�ַ�����β�������ַ�   
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
        /// ���ֽ���ȡ���ַ����ĳ���
        /// </summary>
        /// <param name="strTmp">Ҫ������ַ���</param>
        /// <returns>�ַ������ֽ���</returns>
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
        /// ���ֽ���Ҫ���ַ�����λ��
        /// </summary>
        /// <param name="intIns">�ַ�����λ��</param>
        /// <param name="strTmp">Ҫ������ַ���</param>
        /// <returns>�ֽڵ�λ��</returns>
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
        /// �ж������Ƿ�Ϊ��ֵ����
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

        #region ��ȡIP
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

        #region ����Σ�����ݿ��ַ�
        /// <summary>
        /// ����Σ�����ݿ��ַ�
        /// </summary>
        /// <param name="objString">Ҫ���˵�Σ���ַ�</param>
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

        #region HTML �������
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

            text = regex1.Replace(text, string.Empty);                    //����<script></script>��� 
            text = regex2.Replace(text, string.Empty);                    //����href=javascript: (<A>) ���� 
            text = regex3.Replace(text, " _disibledevent=");    //���������ؼ���on...�¼� 
            text = regex4.Replace(text, string.Empty);                    //����iframe 
            text = regex5.Replace(text, string.Empty);                    //����frameset 
            text = regex6.Replace(text, string.Empty);                    //����frameset 
            text = regex7.Replace(text, string.Empty);                    //����frameset 
            text = regex8.Replace(text, string.Empty);                    //����frameset 
            text = regex9.Replace(text, string.Empty);
            text = regex10.Replace(text, " ");                            //�������߸���Ŀո�
            text = regex11.Replace(text, string.Empty);                   //<br>
            text = regex12.Replace(text, " ");                            //&nbsp;
            text = regex13.Replace(text, string.Empty);                   // �������
            text = regex14.Replace(text, string.Empty);                   // �������
            text = regex15.Replace(text, string.Empty);                   // �������
            text = regex16.Replace(text, string.Empty);                   // �������


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

        #region �����ַ���ʾ���ȣ��������Ʊ����һЩ�ı�����ʾ����
        /// <summary>
        /// �����ַ���ʾ���ȣ��������Ʊ����һЩ�ı�����ʾ����
        /// </summary>
        /// <param name="inputstr">��Ҫ���Ƶ��ַ�</param>
        /// <param name="len">���Ƶĳ���</param>
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
        /// �ж��Ƿ��зǷ��ַ�
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

        #region ���ݺ��ֻ�ȡƴ����

        /// <summary>
        /// ���ݺ��ֻ�ȡƴ����
        /// </summary>
        /// <param name="hz">���뺺�ֲ���</param>
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
            string ls_second_ch = "ءآأؤإئابةتثجحخدذرزسشصضطظعغػؼؽ" +
            "ؾؿ������������������������������������������������������������������������������������������������������������������������������١٢٣٤٥٦٧٨٩٪٫٬٭ٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿ������������������������������������������������������������������������������������������������������������������������������ڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿ����������������������������������������������������������������������������������" +
            "��������������������������������������������ۣۡۢۤۥۦۧۨ۩۪ۭ۫۬ۮۯ۰۱۲۳۴۵۶۷۸۹ۺۻۼ۽۾ۿ������������������������������������������������������������������������������������������������������������������������������ܡܢܣܤܥܦܧܨܩܪܫܬܭܮܯܱܴܷܸܹܻܼܾܰܲܳܵܶܺܽܿ������������������������������������������������������������������������������������������������������������������������������ݡݢݣݤݥݦݧݨݩݪݫݬݭݮݯݰݱݲݳݴݵݶ" +
            "ݷݸݹݺݻݼݽݾݿ������������������������������������������������������������������������������������������������������������������������������ޡޢޣޤޥަާިީުޫެޭޮޯްޱ޲޳޴޵޶޷޸޹޺޻޼޽޾޿������������������������������������������������������������������������������������������������������������������������������ߡߢߣߤߥߦߧߨߩߪ߲߫߬߭߮߯߰߱߳ߴߵ߶߷߸߹ߺ߻߼߽߾߿������������������������������������������������������������������������" +
            "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "�����������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "���������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "��������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������������" +
            "������������������������������������������������������������������������������������������������������������������������������������������������������������������������������";
            byte[] array = new byte[2];

            string return_py = "";
            for (int i = 0; i < hz.Length; i++)
            {
                array = System.Text.Encoding.Default.GetBytes(hz[i].ToString());
                if (array[0] < 176) //.�Ǻ��� 
                {
                    return_py += hz[i];
                }
                else if (array[0] >= 176 && array[0] <= 215) //һ������ 
                {

                    if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "z";
                    else if (hz[i].ToString().CompareTo("ѹ") >= 0)
                        return_py += "y";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "x";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "w";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "t";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "s";
                    else if (hz[i].ToString().CompareTo("Ȼ") >= 0)
                        return_py += "r";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "q";
                    else if (hz[i].ToString().CompareTo("ž") >= 0)
                        return_py += "p";
                    else if (hz[i].ToString().CompareTo("Ŷ") >= 0)
                        return_py += "o";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "n";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "m";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "l";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "k";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "j";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "h";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "g";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "f";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "e";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "d";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "c";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "b";
                    else if (hz[i].ToString().CompareTo("��") >= 0)
                        return_py += "a";
                }
                else if (array[0] >= 215) //�������� 
                {
                    return_py += ls_second_eng.Substring(ls_second_ch.IndexOf(hz[i].ToString(), 0), 1);
                }
            }
            return return_py.ToUpper();
        }

        #endregion



     

    }

}
