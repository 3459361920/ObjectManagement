using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Cache
    {

        //内存实例
        static readonly MemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());
        
        /// <summary>
        /// 获取当前内存缓存内容
        /// </summary>
        /// <param name="keyName">缓存key</param>
        /// <returns></returns>
        public static dynamic GetCacheValue(string keyName)
        {
            try
            {
                var get= MemoryCache.Get(keyName);
                return get;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 添加内存缓存值
        /// </summary>
        /// <param name="KeyName"></param>重复键添加会刷新过期时间
        /// <param name="Value"></param>
        /// <param name="Seconds"></param>
        /// <returns></returns>
        public static dynamic SetCacheValue(string KeyName,string Value,int Seconds)
        {
            try
            {
                MemoryCache.Set(KeyName,Value,DateTimeOffset.Now.AddSeconds(Seconds));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
