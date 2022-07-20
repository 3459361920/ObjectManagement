using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Wathet.Common
{
    public static class DoDataTable
    {
        #region //获取Dt的所有列名
        /// <summary>
        /// 获取Dt的所有列名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<string> GetColumnNames(this DataTable dt)
        {
            var result = new List<string>();
            dt = dt ?? new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                result.Add(col.ColumnName.ToLower());
            }
            return result;
        }
        #endregion

        #region //DataTable <=> List<T>

        public static DataTable ToDataTable<T>(this T Entity)
        {
            return new List<T>() { Entity }.ToDataTable();
        }


        /// <summary>
        /// 转化一个DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            //获得反射的入口
            Type type = typeof(T);
            var dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列
            Array.ForEach(type.GetProperties(), p =>
            {
                if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                {
                    dt.Columns.Add(p.Name, typeof(string));
                }
                else if (p.PropertyType.UnderlyingSystemType.ToString() == "System.Nullable`1[System.DateTime]")
                {
                    dt.Columns.Add(p.Name, typeof(DateTime));
                }
                else
                {
                    dt.Columns.Add(p.Name, p.PropertyType);
                }

            });
            foreach (var item in list)
            {
                //创建一个DataRow实例
                DataRow row = dt.NewRow();
                //给row 赋值
                T o = item;
                Array.ForEach(type.GetProperties(), p =>
                {
                    if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                    {
                        row[p.Name] = Newtonsoft.Json.JsonConvert.SerializeObject(p.GetValue(o, null));
                    }
                    else
                    {
                        row[p.Name] = p.GetValue(o, null);
                    }
                }
                );
                //加入到DataTable
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// DataTable 转换为List 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            var List = new List<T>();
            //创建一个属性的列表
            var prolist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(T);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表
            Array.ForEach(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prolist.Add(p); });
            var CurrentProName = string.Empty;
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    T entity = new T();
                    prolist.ForEach(p =>
                    {
                        CurrentProName = p.Name;
                        var value = row[p.Name];
                        if (value is System.DBNull)
                        {
                            value = "";
                            if (p.PropertyType.IsNumericType()) value = 0;
                            if (p.PropertyType == typeof(DateTime)) value = Config.DefaultDateTime;
                            if (p.PropertyType == typeof(bool)) value = false;  //先默认给 false
                            if (p.PropertyType == typeof(decimal)) value = 0m;
                        }

                        //如果该属性是实体类型
                        if (p.PropertyType.IsClass && p.PropertyType != typeof(string))
                        {
                            p.SetValue(entity, Newtonsoft.Json.JsonConvert.DeserializeObject(value.ToString(), p.PropertyType));
                        }
                        else if (p.PropertyType == typeof(decimal))
                        {
                            p.SetValue(entity, value.ToDecimal());
                        }
                        else
                        {
                            p.SetValue(entity, value);
                        }
                    });
                    List.Add(entity);
                }
                return List;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(CurrentProName);
                return null;
            }
        }




        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable ToDataTableTow(IList list)
        {
            var result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }

                foreach (object t in list)
                {
                    var tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /**/
        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable(list, null);
        }

        /**/
        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            var propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);

            var result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                foreach (T t in list)
                {
                    var tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(t, null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(t, null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        #endregion

        #region //DataRow[] List<DataRow> => DataTable
        /// <summary>
        /// 将Datarow[] 转换为表
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static DataTable ToTable(this DataRow[] Obj, params string[] ColName)
        {
            return Obj.ToList().ToTable(ColName);
        }

        /// <summary>
        /// 将List<DataRow> 转换为表
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static DataTable ToTable(this List<DataRow> Obj, params string[] ColName)
        {

            ColName = ColName.ToLower();
            if (Obj.Count > 0)
            {
                DataTable result = Obj[0].Table.Clone();
                foreach (DataRow row in Obj)
                {
                    result.Rows.Add(row.ItemArray);
                }
                List<string> RemoveCol = new List<string>();

                if (ColName.Length > 0) //如果有特意指定的列,则删除其他列,为空时输出全部
                {
                    foreach (DataColumn colInfo in result.Columns)
                    {
                        if (!ColName.Contains(colInfo.ColumnName.ToLower()))
                        {
                            RemoveCol.Add(colInfo.ColumnName.ToLower());
                        }
                    }
                    RemoveCol.ForEach(o => result.Columns.Remove(o));
                }
                return result;
            }

            return new DataTable();
        }

        #endregion

        #region //DataTable  某一列输出为List<string>
        /// <summary>
        /// DataTable  某一列输出
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="ColumnName">列名称</param>
        /// <param name="IsQuChong">是否去重</param>
        /// <returns></returns>
        public static List<string> ToList_ByOneColumn(this DataTable DT, string ColumnName, bool IsQuChong = false)
        {
            if (DT != null)
            {
                if (DT.Columns.Contains(ColumnName))
                {
                    if (IsQuChong)
                    {
                        HashSet<string> hashSet = new HashSet<string>();
                        Array.ForEach(DT.Select(), row => { hashSet.Add(row[ColumnName].ToString()); });
                        return hashSet.ToList();
                    }
                    else
                    {
                        return DT.Select().Select(o => o[ColumnName].ToString()).ToList();
                    }
                }
            }
            return null;
        }

        #endregion

        #region //DataTable =>　Dictionary<string, string>

        /// <summary>
        /// 从DateTable 中挑选出两列组成键值对
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this DataTable DT, string Key, string Value, bool IsToLower = true)
        {
            var result = new Dictionary<string, string>();
            var cols = DT.GetColumnNames();
            if (cols.Contains(Key.ToLower()) && cols.Contains(Value.ToLower()))
            {
                DT.Select().ToList().ForEach(row =>
                {
                    var Dic_key = IsToLower ? row[Key].ToString().ToLower() : row[Key].ToString();
                    if (!result.ContainsKey(Dic_key))
                    {
                        result.Add(Dic_key, row[Value].ToString());
                    }
                });
            }
            return result;
        }

        #endregion

        #region //DataRow => Dictionary<string, string>

        public static Dictionary<string, string> ToDictionary(this DataRow Row, bool IsToLower = true)
        {
            var result = new Dictionary<string, string>();
            foreach (DataColumn col in Row.Table.Columns)
            {
                result[IsToLower ? col.ColumnName.ToLower() : col.ColumnName] = (Row[col.ColumnName] ?? "").ToString();
            }
            return result;
        }
        #endregion
    }
}
