﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Security.Cryptography;

namespace Wathet.Common
{
    public class DoValid
    {





        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 检测是否是字母或者数字的字符串
        /// </summary>
        /// <param name="strIn">要验证的字符串</param>
        /// <returns></returns>
        public static bool IsValidString(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[A-Za-z0-9]+$");
        }


        /// <summary>
        /// 判断电话/传真
        /// </summary>
        /// <param name="Tel"></param>
        /// <returns></returns>
        public static bool IsValidTel(string Tel)
        {
            return Regex.IsMatch(Tel, @"^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$");
        }


        /// <summary>
        /// 邮政编码
        /// </summary>
        /// <param name="Zip"></param>
        /// <returns></returns>
        public static bool IsValidZip(string Zip)
        {
            return Regex.IsMatch(Zip, @"^[a-z0-9 ]{3,12}$");
        }
        /// <summary>
        /// 判断只能输字母
        /// </summary>
        /// <param name="EnName"></param>
        /// <returns></returns>
        public static bool IsValidEnName(string EnName)
        {
            return Regex.IsMatch(EnName, @"[a-zA-Z]");
        }

        /// <summary>
        /// 判断手机
        /// </summary>
        /// <param name="Mobil"></param>
        /// <returns></returns>
        public static bool IsValidMobil(string Mobil)
        {
            return Regex.IsMatch(Mobil, @"^(\d)+[-]?(\d){6,12}$");
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            //A-Z, a-z, 0-9, +, /, =
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }
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
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|游客|^Guest");
        }

        /// <summary>
        /// 判断文件流是否为UTF8字符集
        /// </summary>
        /// <param name="sbInputStream">文件流</param>
        /// <returns>判断结果</returns>
        private static bool IsUTF8(FileStream sbInputStream)
        {
            int i;
            byte cOctets;  // octets to go in this UTF-8 encoded character 
            byte chr;
            bool bAllAscii = true;
            long iLen = sbInputStream.Length;

            cOctets = 0;
            for (i = 0; i < iLen; i++)
            {
                chr = (byte)sbInputStream.ReadByte();

                if ((chr & 0x80) != 0) bAllAscii = false;

                if (cOctets == 0)
                {
                    if (chr >= 0x80)
                    {
                        do
                        {
                            chr <<= 1;
                            cOctets++;
                        }
                        while ((chr & 0x80) != 0);

                        cOctets--;
                        if (cOctets == 0) return false;
                    }
                }
                else
                {
                    if ((chr & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    cOctets--;
                }
            }

            if (cOctets > 0)
            {
                return false;
            }

            if (bAllAscii)
            {
                return false;
            }

            return true;

        }

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");

        }
        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");

        }

        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        return i;
                    }
                }

            }
            return -1;
        }
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }


        /// <summary>
        /// json 数据为空
        /// </summary>
        public static bool JsonIsNull(string jsonstr)
        {
            jsonstr=jsonstr.Trim();
            if (jsonstr == "" || jsonstr == "[]" || jsonstr == "{}" || jsonstr == "[" || jsonstr == "]" || jsonstr == "{" || jsonstr == "}")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #region 验证接口code
        public static bool ValidateApiCode(string oldCode, string newCode)
        {
            if (string.IsNullOrWhiteSpace(oldCode) || string.IsNullOrWhiteSpace(newCode))
                return false;
            if (oldCode.Length != 19 || newCode.Length != 32)
                return false;
            var oldList = oldCode.Split('-');//根据oldCode分解成4组string
            if (oldList.Length != 4)
                return false;
            var strList = oldList.Select(x => x.ToCharArray()).ToList();//通过4组string获取4组char[]
            foreach (var str in strList)
                if (str.Length != 4)
                    return false;
            var sortArr = new int[] { 0, 3, 1, 2 };//转换时取的索引
            var testnewCode = "";//newcode声明
            sortArr.ToList().ForEach(x =>
            {
                for (int counter = 0; counter < 4; counter++)
                    testnewCode += strList[counter][x];
                testnewCode += "-";
            });//根据文档对应的转换顺序获取newCode
            testnewCode = testnewCode.TrimEnd('-') + "!@&*^QWER";//删除末尾多余-，添加固定字符串
            return MD5(testnewCode) == newCode;//返回32位MD5之后的值（MD5方法请自行实现）
        }

        public static bool ValidateApiTimeCode(string oldCode, string newCode, string md5key = "Companycn")
        {
            
            //unix时间戳（10位）-随机串（6位）-fp（未知）
            //1439538035-damos2-xxxxxx
            if (string.IsNullOrWhiteSpace(oldCode) || string.IsNullOrWhiteSpace(newCode))
                return false;

            if (oldCode.Length < 19 || newCode.Length != 32)
                return false;
            var oldList = oldCode.Split('-');//根据oldCode分解成4组string
            if (oldList.Length != 3)
                return false;

            var lengthArr = new int[] { 10, 6 };
            for (int i = 0; i < 2; i++)
                if (oldList[i].Length != lengthArr[i])
                    return false;

            var timeStramp = oldList[0];
            var fromTime =DoDateTime.GetDateTimeFromUnixStramp(timeStramp);
            if (Math.Abs((DateTime.Now - fromTime).TotalSeconds) > 600)
                return false;

            var sortedList = oldList.OrderBy(x => x).ToList();
            var str = MD5(DoString.GetArrayStr(sortedList, "^"));
            str = MD5(str.Insert(10, md5key));
            return str == newCode;//返回32位MD5之后的值（MD5方法请自行实现）
        }
        #endregion

        #region MD5加密
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');

            }
            return str;
        }
        #endregion

        public static bool CheckString(string strToCheck)
        {
            return !string.IsNullOrWhiteSpace(strToCheck);
        }

    }
}
