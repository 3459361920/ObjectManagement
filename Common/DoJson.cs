using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Wathet.Common
{
    public class DoJson
    {
        #region DataTable <=> Json

        /// <summary>
        /// 将DataRow转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable,只提供结构</param>
        /// <param name="dr">要转换的dr</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataRowToJson(DataTable dt, DataRow dr)
        {
            try
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json.TrimStart('[').TrimEnd(']');
            }
            catch (Exception ex) 
            {
                return "";
                throw ex;
            }
        }

        /// <summary>
        /// 将DataRow转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable,只提供结构</param>
        /// <param name="dr">要转换的dr</param>
        /// <param name="dic">继续附加的dic数据</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataRowAddListToJson(DataTable dt, DataRow dr, Dictionary<string, string> dic)
        {
            try
            {
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }

                if (dic != null)
                {
                    foreach (KeyValuePair<string, string> d in dic)
                    {
                        result.Add(d.Key, d.Value);
                    }
                }
                list.Add(result);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json.TrimStart('[').TrimEnd(']');
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }


        /// <summary>
        /// 将DataRow转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable,只提供结构</param>
        /// <param name="dr">要转换的dr</param>
        /// <param name="unClumns">所有列中要去除的列</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataRowUnClumnToJson(DataTable dt, DataRow dr, string[] unClumns)
        {
            try
            {
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (DataColumn dc in dt.Columns)
                {
                    if (!unClumns.Contains(dc.ColumnName))
                    {
                        result.Add(dc.ColumnName, dr[dc].ToString());
                    }
                }
                list.Add(result);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json.TrimStart('[').TrimEnd(']');
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        /// <summary>
        /// 将DataTable转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataTableToJson(DataTable dt)
        {
            try
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result.Add(dc.ColumnName, dr[dc].ToString());
                    }
                    list.Add(result);
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        /// <summary>
        /// 将DataTable转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <param name="dic">继续添加的dic</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataTableApenListToJson(DataTable dt, Dictionary<string, string> dic)
        {
            try
            {
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        result.Add(dc.ColumnName, dr[dc].ToString());
                    }
                    list.Add(result);
                }
                if (list != null)
                {
                    list.Add(dic);
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }


        /// <summary>
        /// 将DataTable转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <param name="unClounm">不包含的列</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataTableToJsonUnClounm(DataTable dt, string[] unClounm)
        {
            try
            {
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (!unClounm.Contains(dc.ColumnName))
                        {
                            result.Add(dc.ColumnName, dr[dc].ToString());
                        }
                    }
                    list.Add(result);
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }
        /// <summary>
        /// 将DataTable转换为Json格式
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <param name="unClounm">去除表中的某些列</param>
        /// <returns>转换后的json格式字符串</returns>
        public static string DataTableUnClounmAppenListToJson(DataTable dt, string[] unClounm, Dictionary<string, string> addic)
        {
            try
            {
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, string> result = new Dictionary<string, string>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (!unClounm.Contains(dc.ColumnName))
                        {
                            result.Add(dc.ColumnName, dr[dc].ToString());
                        }
                    }
                    list.Add(result);
                }
                if (list != null)
                {
                    list.Add(addic);
                }
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                return json;
            }
            catch (Exception ex)
            {
                return "";
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// 将json格式的字符串转换为list格式的数据
        /// </summary>
        /// <param name="jsonStr">要转换的json格式字符串</param>
        /// <returns>转换后list格式的数据</returns>
        public static List<T> JsonToList<T>(string jsonStr)
        {
            try
            {
                if (jsonStr.StartsWith("[") && jsonStr.EndsWith("]"))
                {
                    List<T> t = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsonStr);

                    return t;
                }
                else
                {
                    List<T> t = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>("[" + jsonStr + "]");
                    return t;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// 将json格式的字符串转换为Entity格式的数据 20160917
        /// </summary>
        /// <param name="jsonStr">要转换的json格式字符串</param>
        /// <returns>转换后Model格式的数据</returns>
        public static T JsonToEntity<T>(string jsonStr)
        {
            try
            {
                jsonStr = jsonStr.TrimStart('[').TrimEnd(']');
                T model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
                return model;
            }
            catch (Exception ex)
            {
                return default(T);
                throw ex;
            }
        }





        #region //byte[] <=> Json

        /// <summary>
        /// 将对象序例化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializableSet(object obj)
        {
            if (obj == null) return null;
            using (MemoryStream fs = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
                formatter = null;
                return fs.ToArray();
            }
        }
        /// <summary>
        /// 将二进制数据反序例化为对象
        /// </summary>
        /// <param name="tmp"></param>
        public static object SerializableGet(byte[] tmp)
        {
            if (tmp == null) return null;
            using (MemoryStream fs = new MemoryStream(tmp))
            {
                fs.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                var ret= formatter.Deserialize(fs);
                return ret;
            }
        }
        #endregion

    }

    /// <summary>
    /// 忽略空集合的字段
    /// </summary>
    public class IgnoreEmptyEnumerablesResolver : DefaultContractResolver
    {
        public static readonly IgnoreEmptyEnumerablesResolver Instance = new IgnoreEmptyEnumerablesResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType != typeof(string) &&
                typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                property.ShouldSerialize = instance =>
                {
                    IEnumerable enumerable = null;

                    // this value could be in a public field or public property
                    switch (member.MemberType)
                    {
                        case MemberTypes.Property:
                            enumerable = instance
                                .GetType()
                                .GetProperty(member.Name)
                                ?.GetValue(instance, null) as IEnumerable;
                            break;
                        case MemberTypes.Field:
                            enumerable = instance
                                .GetType()
                                .GetField(member.Name)
                                .GetValue(instance) as IEnumerable;
                            break;
                        default:
                            break;

                    }

                    if (enumerable != null)
                    {
                        // check to see if there is at least one item in the Enumerable
                        return enumerable.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        // if the list is null, we defer the decision to NullValueHandling
                        return true;
                    }

                };
            }

            return property;
        }
    }
}
