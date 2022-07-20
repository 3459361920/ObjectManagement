using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;


namespace Wathet.Common
{
    /// <summary>
    /// 字符串工具类
    /// </summary>
    public static class DoString
    {
        #region //字符串或者数字补位
        /// <summary>
        /// 给字符串或者数字在前边或者后边补充指定的字符到指定的长度
        /// </summary>
        /// <param name="Target">原始值 可以是int 也可以是string</param>
        /// <param name="length">要补充到的长度</param>
        /// <param name="bu">要在前边补充的字符 默认0</param>
        /// <returns></returns>
        public static string Bu0(object Target, int length, string bu = "0", bool isBefore = true)
        {
            if (Target != null)
            {
                var tar = Target.ToString();
                var tarLen = tar.Length;
                if (tarLen < length)
                {
                    for (var i = 0; i < length - tarLen; i++)
                    {
                        tar = isBefore ? bu + tar : tar + bu;
                    }
                    return tar;
                }
                return Target.ToString();
            }
            return null;
        }
        #endregion

        #region //驼峰命名

        /// <summary>
        /// 首字母小写
        /// </summary>
        public static string ToCamel(this string obj) { if (string.IsNullOrEmpty(obj)) return obj; return obj[0].ToString().ToLower() + obj.Substring(1); }
        /// <summary>
        /// 首字母大写
        /// </summary>
        public static string ToPascal(this string obj) { if (string.IsNullOrEmpty(obj)) return obj; return obj[0].ToString().ToUpper() + obj.Substring(1); }
        #endregion

        #region //获取GUID
        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <param name="IsSymbol">是否删除GUID中间的-号</param>
        /// <returns>新的GUID</returns>
        public static string GUID(bool IsSymbol = true)
        {
            return IsSymbol ? Guid.NewGuid().ToString().Replace("-", "").ToLower() : Guid.NewGuid().ToString().ToLower();
        }

        public static bool CheckAllowMallRole(string roleList, object mallRoleIds)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region //身份证号码转化成4307036****86X形式
        /// <summary>
        /// 扩展方法:身份证号码转化成4307036****86X形式
        /// </summary>
        /// <param name="idCardNumber">身份证号码</param>
        /// <returns></returns>
        public static string HideIdCardNumber(string idCardNumber)
        {
            if (!string.IsNullOrWhiteSpace(idCardNumber) && idCardNumber.Length == 18)
            {
                return idCardNumber.Substring(0, 5) + "******" + idCardNumber.Substring(15);
            }
            return string.Empty;
        }
        #endregion

        #region //手机号隐藏中间四位
        /// <summary>
        /// 扩展方法:手机号转化成189****6547形式
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <returns></returns>
        public static string HideMobileNumber(string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber.Length == 11)
            {
                return phoneNumber.Substring(0, 3) + "****" + phoneNumber.Substring(7, 4);
            }
            return string.Empty;
        }
        #endregion

        #region //判断是否手机号码
        /// <summary>
        /// 判断字符串是否是手机号码
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static bool IsPhone(string Phone)
        {
            var aa = new Regex(@"^1\d{10}");
            return aa.IsMatch(Phone);
        }
        #endregion

        #region //科学计数法
        /// <summary>
        /// 扩展方法：将整形转成有逗号分隔的货币类型(100,000,000)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToThousand(int value)
        {
            var ts = value.ToString(CultureInfo.InvariantCulture);
            ts = ts.Reverse();
            var sb = new StringBuilder();
            for (var i = 0; i < ts.Length; i++)
            {
                sb.Append((i % 3 == 0 && i != 0) ? "," + ts.Substring(i, 1) : ts.Substring(i, 1));
            }
            return sb.ToString().Reverse();
        }
        #endregion


        #region //字符串逆转
        /// <summary>
        /// 扩展方法：将字符串逆转
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Reverse(this string source)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                char[] temp = source.ToCharArray();
                Array.Reverse(temp);
                return new string(temp);
            }
            return string.Empty;
        }
        #endregion

        #region //将字符串按长度切割
        /// <summary>
        /// 扩展方法:将字符串按长度切割
        /// </summary>
        /// <param name="source"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Cut(this string source, int? len = 10)
        {
            if (!string.IsNullOrWhiteSpace(source))
            {
                var oldStrLen = source.Length;
                if (oldStrLen <= len.Value)
                {
                    return source;
                }
                else
                {
                    return source.Substring(0, len.Value - 3) + "...";
                }
            }
            return string.Empty;
        }
        #endregion

        #region //生成重复字符串
        /// <summary>
        /// 生成指定数量的重复字符串
        /// </summary>
        public static string GetStrByCount(string str, int nSpaces)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nSpaces; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }
        #endregion


        #region //删除不可见字符
        /// <summary>
        /// 删除不可见字符
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
        #endregion

        #region //获取某一字符串出现的次数
        /// <summary>
        /// 获取某一字符串在字符串中出现的次数
        /// </summary>
        public static int GetStringCount(string source, string target)
        {
            return (source.Length - source.Replace(target, "").Length) / target.Length;
        }
        #endregion


        #region //从指定字符开始截取字符串
        /// <summary>
        /// 截取从startString开始到原字符串结尾的所有字符   
        /// </summary>
        public static string GetSubString(string sourceString, string startString, bool IsCareUpper = false)
        {
            try
            {
                int index = IsCareUpper ? sourceString.ToUpper().IndexOf(startString.ToUpper()) : sourceString.IndexOf(startString);
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
        #endregion

        #region //用指定的开始和结束字符来截取字符串
        /// <summary>
        /// 用指定的开始和结束字符来截取字符串
        /// </summary>
        public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
        {
            try
            {
                if (!sourceString.Contains(beginRemovedString))
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
                return sourceString;
            }
        }
        #endregion

        #region 分割字符串
        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                    return new string[] { strContent };

                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
                return new string[0] { };
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }
        #endregion

        #region //按字节数取出字符串的长度 中文算2个
        /// <summary>
        /// 按字节数取出字符串的长度 中文算2个
        /// </summary>
        public static int GetByteCount(string strTmp)
        {
            int Length = 0;
            int i = 0;
            while (i < strTmp.Length)
            {
                Length += strTmp.Substring(i, 1).ToBytes().Length == 3 ? 2 : 1;
            }

            return Length;
        }
        #endregion

        #region //磁盘空间文字转换
        /// <summary>
        /// 磁盘空间文字转换
        /// </summary>
        /// <param name="Size"></param>
        /// <param name="Unit">转换出的单位,默认是自动匹配,可以设定值为 PB TB GB MB KB b</param>
        /// <returns></returns>
        public static string GetDiskSizeStr(long Size, string Unit = "auto")
        {
            var PB = 1024D * 1024 * 1024 * 1024 * 1024;
            var TB = 1024D * 1024 * 1024 * 1024;
            var GB = 1024D * 1024 * 1024;
            var MB = 1024D * 1024;
            var KB = 1024D;
            switch (Unit.ToUpper())
            {
                case "P": case "PB": return Math.Round(Size / PB, 2) + " PB";
                case "T": case "TB": return Math.Round(Size / TB, 2) + " TB";
                case "G": case "GB": return Math.Round(Size / GB, 2) + " GB";
                case "M": case "MB": return Math.Round(Size / MB, 2) + " MB";
                case "K": case "KB": return Math.Round(Size / KB, 2) + " KB";
                case "B": case "BYTE": return Size + " b";
                default:
                    string result = string.Empty;
                    if (Size > PB) { return Math.Round(Size / PB, 2) + " PB"; }
                    if (Size > TB) { return Math.Round(Size / TB, 2) + " TB"; }
                    if (Size > GB) { return Math.Round(Size / GB, 2) + " GB"; }
                    if (Size > MB) { return Math.Round(Size / MB, 2) + " MB"; }
                    if (Size > KB) { return Math.Round(Size / KB, 2) + " KB"; }
                    return Size + " b";
            }
        }
        #endregion

        /// <summary>
        /// 按字节数要在字符串的位置
        /// </summary>
        /// <param name="intIns">字符串的位置</param>
        /// <param name="strTmp">要计算的字符串</param>
        /// <returns>字节的位置</returns>
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
        /// 从右边截取字符串
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CutRightString(string inputString, int len)
        {
            if (string.IsNullOrEmpty(inputString))
                return string.Empty;

            var input = Reverse(inputString);
            var output = CutString(input, len, "...");
            return Reverse(output);
        }


        /// <summary>
        /// 从包含中英文的字符串中截取固定长度的一段，inputString为传入字符串，len为截取长度（一个汉字占两个位）。
        /// </summary>
        public static string CutString(string inputString, int len, string end)
        {
            inputString = inputString.Trim();
            byte[] myByte = System.Text.Encoding.Default.GetBytes(inputString);
            if (myByte.Length > len)
            {
                string result = "";
                for (int i = 0; i < inputString.Length; i++)
                {
                    byte[] tempByte = System.Text.Encoding.Default.GetBytes(result);
                    if (tempByte.Length < len)
                    {
                        result += inputString.Substring(i, 1);
                    }
                    else
                    {
                        break;
                    }
                }
                return result + end;
            }
            else
            {
                return inputString;
            }
        }


        ///解码
        public static string DecodeBase64( string code,string code_type= "utf-8")
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }


        #region //删除换行 空格 隔位符
        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEnd(string str)
        {
            return TrimEnd(str, " ");
        }

        /// <summary>
        /// 删除字符串尾部的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEnd(string str, string oper)
        {
            str = str.TrimEnd(new char[] { ' ', '\r', '\n', '\t' });
            return str.TrimEnd(Convert.ToChar(oper));
        }
        /// <summary>
        /// 删除字符开始的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimStart(string str)
        {
            return TrimStart(str, " ");
        }
        /// <summary>
        /// 删除字符开始的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimStart(string str, string oper)
        {
            str = str.TrimStart(new char[] { ' ', '\r', '\n', '\t' });
            return str.TrimStart(Convert.ToChar(oper));
        }
        /// <summary>
        /// 删除字符左右的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Trim(string str)
        {
            return Trim(str, " ");
        }
        /// <summary>
        /// 删除字符左右的回车/换行/空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Trim(string str, string oper)
        {
            str = str.Trim(new char[] { ' ', '\r', '\n', '\t' });
            return str.Trim(Convert.ToChar(oper));
        }


        #endregion


        #region //dd
        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <param name="length">子字符串的长度</param>
        /// <returns>子字符串</returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }


                if (startIndex > str.Length)
                {
                    return "";
                }


            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 从字符串的指定位置开始截取到字符串结尾的了符串
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="startIndex">子字符串的起始位置</param>
        /// <returns>子字符串</returns>
        public static string SubString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        /// <summary>
        /// 取指定长度的字符串
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_StartIndex">起始位置</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {


            string myResult = p_SrcString;

            //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
            if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") ||
                System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
            {
                //当截取的起始位置超出字段串长度时
                if (p_StartIndex >= p_SrcString.Length)
                {
                    return "";
                }
                else
                {
                    return p_SrcString.Substring(p_StartIndex,
                                                   ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }


            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }



                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {

                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                            {
                                nFlag = 1;
                            }
                        }
                        else
                        {
                            nFlag = 0;
                        }

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                    {
                        nRealLength = p_Length + 1;
                    }

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);

                    myResult = myResult + p_TailString;
                }
            }

            return myResult;
        }

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        #endregion

        #region 将字符串转换为数组
        /// <summary>
        /// 使用逗号将字符串拆分成字符串数组
        /// </summary>
        /// <param name="str">目标字符串</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStrArray(string str)
        {
            return str.Split(',');
        }
        #endregion

        #region string[]转int[]
        /// <summary>
        /// 将string数组转换为int数组
        /// </summary>
        /// <param name="strArray">目标数组</param>
        /// <returns></returns>
        public static int[] GetIntArray(string[] strArray)
        {
            int[] intArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                intArray[i] = StrToInt(strArray[i], 0);
            }
            return intArray;
        }
        #endregion

        #region 将数组转换为字符串
        /// <summary>
        /// 将数组转为包含有间隔符的字符串
        /// </summary>
        /// <param name="list">目标数组</param>
        /// <param name="speater">间隔符</param>
        /// <returns></returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 将数组转换为字符串
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="speater">分隔符</param>
        /// <returns>String</returns>
        public static string GetArrayStr<T>(IEnumerable<T> list, char speater)
        {
            StringBuilder sb = new StringBuilder();
            var count = list.Count();
            foreach (var item in list)
            {
                sb.Append(item);
                sb.Append(speater);
            }
            return sb.ToString().TrimEnd(speater);
        }


        /// <summary>
        /// 将数组转换为字符串
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="speater">分隔符</param>
        /// <returns>String</returns>
        public static string GetIntArrayStr(List<int> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i].ToString());
                }
                else
                {
                    sb.Append(list[i].ToString());
                    sb.Append(speater.ToString());
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 将数组转换为字符串
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="speater">分隔符</param>
        /// <returns>String</returns>
        public static string GetArrayStr(string[] list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Length; i++)
            {
                if (i == list.Length - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }

        #endregion

        #region 删除最后结尾的一个逗号
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        #endregion

        #region 删除最后结尾的指定字符后的字符
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        #endregion

        #region 生成指定长度的字符串
        /// <summary>
        /// 生成指定长度的字符串,即生成strLong个str字符串
        /// </summary>
        /// <param name="strLong">生成的长度</param>
        /// <param name="str">以str生成字符串</param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }
            return ReturnStr;
        }
        #endregion

        #region 格式化复杂的字符串
        /// <summary>
        /// 格式化复杂的字符串
        /// </summary>
        /// <param name="indexStr">这个字符串之后的要格式化</param>
        /// <param name="str">要格式话的字符串</param>
        /// <param name="oldStr">原来的字符符号("or')</param>
        /// <param name="newStr">转换后的字符符号（"or'）</param>
        /// <returns></returns>
        public static string ForMttingString(string indexStr, string str, string oldStr, string newStr)
        {
            string ReturnStr = "";
            if (str.Contains(indexStr))
            {
                int index = str.IndexOf(indexStr);
                int indexLength = indexStr.Length;
                string subStr = str.Substring(index + indexLength, str.Length - index - indexLength);
                string starStr = str.Substring(0, index + indexLength);
                subStr = subStr.Replace(oldStr, newStr);
                int last = subStr.LastIndexOf(newStr);
                subStr = subStr.Substring(0, last) + oldStr + subStr.Substring(last + 1, subStr.Length - last - 1);
                return starStr + subStr;
            }
            return ReturnStr;
        }
        #endregion
        #region 生成日期随机码
        /// <summary>
        /// 生成时间随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamTimeCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }

        /// <summary>
        /// 生成日期随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamDateCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMdd");
            #endregion
        }
        #endregion

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }
        #region 清除HTML标记且返回相应的长度
        public static string DropHTML(string Htmlstring, int strLen)
        {
            return CutString(DropHTML(Htmlstring), strLen);
        }
        #endregion

        #region 截取字符长度
        /// <summary>
        /// 截取字符长度
        /// </summary>
        /// <param name="inputString">字符串</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        public static string CutString(string inputString, int len)
        {
            if (inputString == "")
            {
                return "";
            }
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += inputString.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > len)
                    break;
            }
            //如果截过则加上半个省略号 
            //byte[] mybyte = System.Text.Encoding.Default.GetBytes(inputString);
            //if (mybyte.Length > len)
            //    tempString += "...";
            return tempString;
        }
        #endregion

        #region 清除HTML标记
        /// <summary>
        /// 清除自定字符串的html格式，并进行HMTL编码
        /// </summary>
        /// <param name="Htmlstring">目标字符串</param>
        /// <returns>字符串的html编码</returns>
        //public static string DropHTML(string Htmlstring)
        //{
        //    //删除脚本  
        //    Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //    //删除HTML  
        //    Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        //    Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        //    Htmlstring = HttpContext.Current!=null? HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim(): Htmlstring;

        //    return Htmlstring;
        //}
        #endregion

        #region 清除HTML标记且返回相应的长度
        ///// <summary>
        ///// 清除目标字符串的HTML格式，并返回指定的长度
        ///// </summary>
        ///// <param name="Htmlstring">目标字符串</param>
        ///// <param name="strLen">指定的长度</param>
        ///// <returns>返回的字符串</returns>
        //public static string DropHTML(string Htmlstring, int strLen)
        //{
        //    return CutString(DropHTML(Htmlstring), strLen);
        //}
        #endregion

        #region TXT代码转换成HTML格式
        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="Input">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把TXT代码转换成HTML格式
        public static String ToHtml(string Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\r\n", "<br />");
            sb.Replace("\n", "<br />");
            sb.Replace("\t", " ");
            sb.Replace("“", "&ldquo;");
            sb.Replace("”", "&rdquo;");
            sb.Replace(" ", "&nbsp;");
            return sb.ToString();
        }
        #endregion

        #region HTML代码转换成TXT格式
        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="Input">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把HTML代码转换成TXT格式
        public static String ToTxt(String Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&nbsp;", " ");
            sb.Replace("&ldquo;", "“");
            sb.Replace("&rdquo;", "”");
            sb.Replace("<br>", "\r\n");
            sb.Replace("<br>", "\n");
            sb.Replace("<br />", "\n");
            sb.Replace("<br />", "\r\n");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp;", "&");
            return sb.ToString();
        }
        #endregion

        #region 检查危险字符
        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        public static bool Filter(ref string sInput)
        {
            if (string.IsNullOrEmpty(sInput)) return true;
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|=|or|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                return false;
            }
            else
            {
                output = output.Replace("'", "''");
                return true;
            }
        }
        #endregion

        #region 过滤特殊字符
        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (Input != string.Empty && Input != null)
            {
                string ihtml = Input.ToLower();
                ihtml = ihtml.Replace("<script", "&lt;script");
                ihtml = ihtml.Replace("script>", "script&gt;");
                ihtml = ihtml.Replace("<%", "&lt;%");
                ihtml = ihtml.Replace("%>", "%&gt;");
                ihtml = ihtml.Replace("<$", "&lt;$");
                ihtml = ihtml.Replace("$>", "$&gt;");
                return ihtml;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region //判断是否OpenId
        /// <summary>
        /// 判断字符串是否是OpenID, 或者UnionID
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public static bool IsOpenID(string OpenID)
        {
            var aa = new Regex(@"[a-zA-Z\d_-]{28}");
            if (string.IsNullOrEmpty(OpenID))
            {
                return false;
            }
            return aa.IsMatch(OpenID);
        }
        #endregion

        #region ///生成随机字符串

        ///<summary>
        ///生成随机字符串 
        ///</summary>
        ///<param name="length">目标字符串的长度</param>
        ///<param name="useNum">是否包含数字，1=包含，默认为包含</param>
        ///<param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        ///<param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        ///<param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        ///<param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        ///<returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }

        #endregion

        #region 生成指定区间随机数
        /// <summary>
        /// 生成指定区间随机数
        /// </summary>
        /// <param name="minVal">最小值（包含）</param>
        /// <param name="maxVal">最大值（不包含）</param>
        /// <returns></returns>
        public static int GetRandom(int minVal, int maxVal)
        {
            //这样产生0 ~ 100的强随机数（不含100）
            int m = maxVal - minVal;
            int rnd = int.MinValue;
            decimal _base = (decimal)long.MaxValue;
            byte[] rndSeries = new byte[8];
            System.Security.Cryptography.RNGCryptoServiceProvider rng
            = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndSeries);
            long l = BitConverter.ToInt64(rndSeries, 0);
            rnd = (int)(Math.Abs(l) / _base * m);
            return minVal + rnd;
        }

        #endregion

        /// <summary>
        /// 将字符串转换为double类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的double类型结果</returns>
        public static double StrToDouble(string expression, double defValue)
        {
            var overLength = true;
            if (expression.Contains("."))
            {
                var array = expression.Split('.');
                if (array.Length != 2)
                    return defValue;
                else if (array[0].Length >= 11)
                    return defValue;
                else
                    overLength = false;
            }
            else
            {
                var intValue = StrToInt(expression, -int.MaxValue);
                return intValue == -int.MaxValue ? defValue : intValue;
            }
            if (string.IsNullOrEmpty(expression) || overLength || !Regex.IsMatch(expression.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            double rv;
            if (double.TryParse(expression, out rv))
                return rv;

            return Convert.ToDouble(defValue);
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string expression, decimal defValue)
        {
            if ((expression == null) || (expression.Length > 10))
                return defValue;

            decimal intValue = defValue;
            if (expression != null)
            {
                bool IsDecimal = Regex.IsMatch(expression, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsDecimal)
                    decimal.TryParse(expression, out intValue);
            }
            return intValue;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="Expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object Expression, bool defValue)
        {
            if (Expression != null)
            {
                if (string.Compare(Expression.ToString(), "true", true) == 0)
                {
                    return true;
                }
                else if (string.Compare(Expression.ToString(), "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="Expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string Expression, int defValue)
        {

            if (string.IsNullOrEmpty(Expression) || Expression.Trim().Length >= 11 || !Regex.IsMatch(Expression.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (int.TryParse(Expression, out rv))
                return rv;

            try
            {
                return Convert.ToInt32(StrToFloat(Expression, defValue));
            }
            catch
            {
                return defValue;
            }
        }

        #region 父类赋值子类 
        /// <summary>
        /// 使用父类给子类字段，属性赋值
        /// </summary>
        /// <typeparam name="TParent">父类类型，请确保所有属性，字段具有get.set方法</typeparam>
        /// <typeparam name="TChild">子类类型，请确保所有属性，字段具有get.set方法</typeparam>
        /// <param name="parent">父类对象</param>
        /// <param name="child">子类对象</param>
        /// <returns></returns>
        public static TChild AutoCopy<TParent, TChild>(TParent parent, TChild child)
            where TChild : class, TParent, new()
            where TParent : class, new()
        {
            var par_type = typeof(TParent);
            var chi_type = typeof(TChild);
            var chi_properties = chi_type.GetProperties();
            var par_properties = par_type.GetProperties();
            var chi_fields = chi_type.GetFields();
            var par_fields = par_type.GetFields();
            foreach (PropertyInfo pi in chi_properties)
            {
                var par_pi = par_properties.Where(x => x.Name == pi.Name).FirstOrDefault();
                if (par_pi != null)
                    pi.SetValue(child, par_pi.GetValue(parent));
            }
            foreach (FieldInfo fi in chi_fields)
            {
                var par_fi = par_fields.Where(x => x.Name == fi.Name).FirstOrDefault();
                if (par_fi != null)
                    fi.SetValue(child, par_fi.GetValue(parent));
            }
            return child;
        }
        #endregion


        /// <summary>
        /// sql字段太长分批查询
        /// </summary>
        /// <param name="ids">要查询的字段</param>
        /// <param name="count">传入数量</param>
        /// <param name="field">要查询字段</param>
        /// <returns></returns>
        public static string getSQLIn(List<int> ids, int count, string field)
        {
            if (count == 0)
            {
                return string.Empty;
            }
            count = Math.Min(count, 200);
            int len = ids.Count();
            int size = len % count;
            if (size == 0)
            {
                size = len / count;
            }
            else
            {
                size = (len / count) + 1;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                int fromIndex = i * count;
                int toIndex = Math.Min(fromIndex + count, len);
                string yjdNbr = "";
                for (int j = fromIndex; j < toIndex; j++)
                {
                    yjdNbr += ids[j] + ",";
                }
                if (i != 0)
                {
                    builder.Append(" or ");
                }
                builder.Append(field).Append(" in (").Append(yjdNbr.TrimEnd(',')).Append(")");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                return builder.ToString();
            }
            else
            {
                return field + " in ('')";
            }
        }


        /// <summary>
        ///适用商场模糊查询
        /// </summary>
        /// <param name="ids">要查询的字段</param>
        /// <param name="field">要查询字段</param>
        /// <returns></returns>
        public static string getMallSQL(List<int> ids, string field)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < ids.Count; i++)
            {
                if (i != 0)
                {
                    builder.Append(" or ");
                }
                builder.Append(field).Append(" like '%,").Append(ids[i]).Append(",%'");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                return builder.ToString();
            }
            else
            {
                return field + " like '%,,%'";
            }
        }

        public static string getSQLIn(List<string> ids, int count, string field)
        {
            if (count == 0)
            {
                return string.Empty;
            }
            count = Math.Min(count, 1000);
            int len = ids.Count();
            int size = len % count;
            if (size == 0)
            {
                size = len / count;
            }
            else
            {
                size = (len / count) + 1;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                int fromIndex = i * count;
                int toIndex = Math.Min(fromIndex + count, len);
                string yjdNbr = "";
                for (int j = fromIndex; j < toIndex; j++)
                {
                    yjdNbr += "'" + ids[j] + "',";
                }
                if (i != 0)
                {
                    builder.Append(" or ");
                }
                builder.Append(field).Append(" in (").Append(yjdNbr.TrimEnd(',')).Append(")");
            }
            if (!string.IsNullOrEmpty(builder.ToString()))
            {
                return builder.ToString();
            }
            else
            {
                return field + " in ('')";
            }
        }

        /// <summary>
        /// 检查用户权限是否包含管理商场权限
        /// </summary>
        /// <param name="userRoleStr">用户权限</param>
        /// <param name="mallRole">管理商场权限ids</param>
        /// <returns></returns>
        public static bool CheckAllowMallRole(string userRoleStr, string mallRole)
        {
            if (string.IsNullOrEmpty(userRoleStr)) { return false; }
            bool result = false;
            var allow = mallRole.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var roleList = userRoleStr.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

            roleList.ForEach(o =>
            {
                if (allow.Contains(o)) { result = true; }
            });

            return result;
        }


        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue.ToString(), @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                {
                    intValue = Convert.ToSingle(strValue);
                }
            }
            return intValue;
        }


        #region 检测是否有Sql危险字符
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return null;
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";

            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output.Trim();
        }

        /// <summary> 
        /// 检查过滤设定的危险字符
        /// </summary> 
        /// <param name="InText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public static bool SqlFilter(string word, string InText)
        {
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 清除HTML标记
        public static string DropHTML(string Htmlstring, bool is_sql = false)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"alert[(][\s\S]*[)]", "", RegexOptions.IgnoreCase);  //alert的字符
            Htmlstring = Regex.Replace(Htmlstring, @"<iframe[^>]*?>.*?</iframe>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"iframe[\s\S]*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"javascript:[\s\t\r\n]*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"[+][\s\S]*[+]", "", RegexOptions.IgnoreCase);  //加号内的字符

            //Htmlstring = Regex.Replace(Htmlstring, @"[""][\s\S]*[""]", "", RegexOptions.IgnoreCase);  //双引号内的字符
            //删除HTML  
            if (!Htmlstring.Contains("<>"))
            {
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            }

            //  Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

            //删除与数据库相关的词
            Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, " asc ", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, " mid ", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, " char ", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, " and ", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, " or ", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "net user", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "%20", "", RegexOptions.IgnoreCase);
            //


            if (!is_sql)
            {
                Htmlstring = Htmlstring.Replace("'", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("<", "");
                //Htmlstring = Regex.Replace(Htmlstring, "==", "", RegexOptions.IgnoreCase);
                //Htmlstring = Regex.Replace(Htmlstring, "--", "", RegexOptions.IgnoreCase);

            }


            //Htmlstring = Htmlstring.Replace("\r\n", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring.Trim();
        }

        /// <summary>
        /// 只删除html标签
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string DropHTMLOnly(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            return Htmlstring.Trim();
        }
        #endregion


        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns></returns>
        public static string Number(int Length)
        {
            return Number(Length, false);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        public static string Number(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }

    }
}
