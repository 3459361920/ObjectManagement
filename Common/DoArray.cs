using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wathet.Common
{
    public class DoArray
    {


        /// <summary>
        /// 判断给定的字符串数组(strNumber)中的数据是不是都为数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串数组</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsNumericArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string id in strNumber)
            {
                if (!id.IsInt())
                {
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// 判断给定的对象在数组中的位置 没有则返回 -1 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int IndexOf(object[] array, object obj)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (obj.ToString() == array[i].ToString()) return i;
            }
            return -1;
        }

        /// <summary>
        /// 两数组比较是否相同
        /// </summary>
        public static bool Comparison(object[] array1, object[] array2, string JianGeFu)
        {
            var list1 = array1.ToList();
            list1.Sort();
            var list2 = array2.ToList();
            list2.Sort();
            return string.Join(JianGeFu, list1).Equals(string.Join(JianGeFu, list2));
        }

        /// <summary>
        /// 数组去重
        /// </summary>
        public static T[] ArrayDistinct<T>(T[] array1)
        {
            List<T> newArray = new List<T>();
            foreach (var item in array1)
            {
                if (!newArray.Contains(item)) newArray.Add(item);
            }
            return newArray.ToArray();
        }

        /// <summary>
        /// 判断两个数组是否包含
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <param name="isAll">是否全部包含 (默认为true ,全部包含)</param>
        /// <returns></returns>
        public static bool CheckContains(string array1, string array2, bool isAll = true)
        {
            if (!string.IsNullOrEmpty(array1) && !string.IsNullOrEmpty(array2))
            {
                return CheckContains(array1.Split(",", StringSplitOptions.RemoveEmptyEntries), array2.Split(",", StringSplitOptions.RemoveEmptyEntries), isAll);
            }
            return false;
        }

        public static bool CheckContains(string[] array1, string[] array2, bool isAll = true)
        {
            if (array1 != null && array2 != null)
            {
                if (array1.Count() > 0 && array2.Count() > 0)
                {
                    return isAll
                        ? array2.Count(o => array1.Contains(o)) == array2.Count()
                        : array2.Count(o => array1.Contains(o)) > 0;
                }
            }
            return false;
        }

    }
}
