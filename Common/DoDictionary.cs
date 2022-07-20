using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wathet.Common
{
    public static class DoDictionary
    {
        #region //将键值对的数据转换为SQL的Case When 
        /// <summary>
        /// 将键值对的数据转换为SQL的Case When 
        /// 输出的值需要替换{0}为列名 {1}为默认值
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ToCaseWhenSQL(this Dictionary<int, string> dic)
        {
            if (dic.Count > 0)
            {
                string result = " Case ";

                foreach (var item in dic)
                {
                    result += " When {0}='" + item.Key.ToString() + "' Then '" + item.Value.ToString() + "'";
                }
                result += " Else '{1}' End";
                return result;
            }
            else
            {
                return "''";
            }
        }
        #endregion

        #region //将字符串键值对转换为数字字符串键值对
        /// <summary>
        /// 将字符串键值对转换为数字字符串键值对
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static Dictionary<int, string> ToInt(this Dictionary<string, string> dic)
        {
            var result = new Dictionary<int, string>();
            foreach (var item in dic)
            {
                result[item.Key.ToInt()] = item.Value;
            }
            return result;
        }
        #endregion

        #region Dictionary key忽略大小写获取第一位值
        /// <summary>
        /// ictionary key忽略大小写获取第一位值
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="dic">Dictionary</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public static T IgnoreCaseGetFirstValue<T>(this IDictionary<string, T> dic, string key) => IgnoreCaseGetFirstValue(dic, key, default(T));

        /// <summary>
        /// Dictionary key忽略大小写获取第一位值
        /// </summary>
        /// <param name="dic">Dictionary</param>
        /// <param name="key">key</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns></returns>
        public static T IgnoreCaseGetFirstValue<T>(this IDictionary<string, T> dic,string key,T defaultValue)
        {
            if (dic == null || string.IsNullOrEmpty(key))
            {
                return defaultValue;
            }
            var exKey = dic.Keys.FirstOrDefault(c => string.Compare(c, key, StringComparison.OrdinalIgnoreCase) == 0);
            return string.IsNullOrEmpty(exKey) ? defaultValue : dic[exKey];
        }
        #endregion

        #region Dictionary key忽略大小写移除项
        /// <summary>
        /// Dictionary key忽略大小写移除项
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool RemoveIgnoreCase<T>(this IDictionary<string, T> dic, string key)
        {
            if (dic == null || string.IsNullOrEmpty(key))
            {
                return false;
            }
            var exKey = dic.Keys.FirstOrDefault(c => string.Compare(c, key, StringComparison.OrdinalIgnoreCase) == 0);
            if (string.IsNullOrEmpty(exKey))
            {
                return false;
            }
            return dic.Remove(exKey);
        }
        #endregion

        #region //将键值对对象添加到上下文对象中

        /// <summary>
        /// 将键值对对象添加到上下文对象中
        /// 主要用于后期的接口记录日志，
        /// 这样能够不但访问日志能够记录，逻辑中的运行日志也可以一起记录
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="ItemsName"></param>
        /// <returns></returns>
        public static bool InsertHttp(this Dictionary<string, object> dic, string ItemsName = "RunLog")
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    var http = HttpContext.Current;
                    if (!http.Items.ContainsKey(ItemsName))
                    {
                        http.Items[ItemsName] = dic;
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToSimple("键值对添加到上下文时出错"));
                return false;
            }
        }
        #endregion

        #region 组装QueryString的方法
        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&连接，首位没有符号，如：a=1&b=2&c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string formDataQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        } 
        #endregion

    }
}
