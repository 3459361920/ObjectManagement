using KingLion.WebUtils.NPinyin;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Wathet.Common
{

    public static class DoPinYin
    {
        #region //将字符串转换为拼音

        /// <summary>
        /// 将字符串转换为拼音
        /// </summary>
        /// <param name="target">目标字符串</param>
        /// <param name="IsFirstCodeUpper">是否首字母转换为大写</param>
        /// <param name="IsOnlyFirstLetter">是否只输出首字母</param>
        /// <param name="IsAppendSpace">是否使用空格间隔</param>
        /// <returns></returns>
        public static string Convert(string target, bool IsFirstCodeUpper = false, bool IsOnlyFirstLetter = false, bool IsAppendSpace = false)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]");
            var Result = new List<string>();
            foreach (char str in target)
            {
                var obj = str.ToString();
                if (regex.IsMatch(obj)) //中文
                {
                    var p = ConvertByChar(str, IsFirstCodeUpper);
                    if (p.Length > 0)
                    {
                        Result.Add(IsOnlyFirstLetter ? p[0].ToString() : p);
                    }
                }
                else //直接附加
                {
                    Result.Add(obj);
                }
            }

            return string.Join(IsAppendSpace ? " " : "", Result);
        } 
        #endregion

        #region //将单个字符转换为拼音
        /// <summary>
        /// 将单个字符转换为拼音
        /// </summary>
        /// <param name="code"></param>
        /// <param name="IsFirstCodeUpper"></param>
        /// <returns></returns>
        public static string ConvertByChar(char code, bool IsFirstCodeUpper = false)
        {
            var str = Pinyin.GetPinyin(code);
            if (str.Length > 0)
            {
                return IsFirstCodeUpper
                    ? str[0].ToString().ToUpper() + str.Substring(1)
                    : str;
            }
            return str;
        }
        #endregion


        /// <summary>
        /// 汉字转拼音并获取首字母
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        static public string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }
        /// <summary>
        /// 获取汉字字符串第一个字首字母
        /// </summary>
        /// <param name="cnChar">汉字</param>
        /// <returns><string/returns>
        public static string getSpell(string cnChar)
        {
            if (cnChar.CompareTo("吖") < 0)
            {
                string s = cnChar.Substring(0, 1).ToUpper();
                if (char.IsNumber(s, 0))
                {
                    return "0";
                }
                else
                {
                    return s;
                }

            }
            else if (cnChar.CompareTo("八") < 0)
            {
                return "A";
            }
            else if (cnChar.CompareTo("嚓") < 0)
            {
                return "B";
            }
            else if (cnChar.CompareTo("咑") < 0)
            {
                return "C";
            }
            else if (cnChar.CompareTo("妸") < 0)
            {
                return "D";
            }
            else if (cnChar.CompareTo("发") < 0)
            {
                return "E";
            }
            else if (cnChar.CompareTo("旮") < 0)
            {
                return "F";
            }
            else if (cnChar.CompareTo("铪") < 0)
            {
                return "G";
            }
            else if (cnChar.CompareTo("讥") < 0)
            {
                return "H";
            }
            else if (cnChar.CompareTo("咔") < 0)
            {
                return "J";
            }
            else if (cnChar.CompareTo("垃") < 0)
            {
                return "K";
            }
            else if (cnChar.CompareTo("呒") < 0)
            {
                return "L";
            }
            else if (cnChar.CompareTo("拏") < 0)
            {
                return "M";
            }
            else if (cnChar.CompareTo("噢") < 0)
            {
                return "N";
            }
            else if (cnChar.CompareTo("妑") < 0)
            {
                return "O";
            }
            else if (cnChar.CompareTo("七") < 0)
            {
                return "P";
            }
            else if (cnChar.CompareTo("亽") < 0)
            {
                return "Q";
            }
            else if (cnChar.CompareTo("仨") < 0)
            {
                return "R";
            }
            else if (cnChar.CompareTo("他") < 0)
            {
                return "S";
            }
            else if (cnChar.CompareTo("哇") < 0)
            {
                return "T";
            }
            else if (cnChar.CompareTo("夕") < 0)
            {
                return "W";
            }
            else if (cnChar.CompareTo("丫") < 0)
            {
                return "X";
            }
            else if (cnChar.CompareTo("帀") < 0)
            {
                return "Y";
            }
            else if (cnChar.CompareTo("咗") < 0)
            {
                return "Z";
            }
            else
            {
                return "0";
            }
        }

    }
}