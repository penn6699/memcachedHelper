using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// MemCached缓存处理
/// </summary>
public class MemcachedHelper
{
    
    private static MemcachedClient _MemcachedClient;
    //static readonly object locker = new object();

    private static MemcachedClient Client {
        get {
            if (_MemcachedClient == null) {
                _MemcachedClient = new MemcachedClient();
            }
            return _MemcachedClient;
        }
    }

    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="value">键值</param>
    /// <param name="expires">有效时间。单位是分钟</param>
    /// <returns></returns>
    public static bool Set(string key,object value, int? expires = null) {
        
        Debug.WriteLine(key);
        if (expires == null || expires < 1)
        {
            return Client.Store(StoreMode.Set, key, value);
        }
        else
        {
            int totalSeconds = 60 * (int)expires;

            if (totalSeconds> 2592000)  //当配置文件设置为0时，表示保存最大天数30天。
            {
                totalSeconds = 2592000;
            }

            TimeSpan ts = new TimeSpan(0, 0, totalSeconds);           
            return Client.Store(StoreMode.Set, key, value,ts);
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static object Get(string key) 
    {
        return Client.Get(key);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public static T Get<T>(string key) where T : class
    {
        return Client.Get<T>(key);
    }

    public static IDictionary<string,object> Get(List<string> keys)
    {
        return Client.Get(keys);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool IsExist(string key) {
        //return Client.Get(key) != null;//memcache不允许将值设置null
        object obj;
        return Client.TryGet(key, out obj);
    }

    /// <summary>
    /// 删除指定缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool Remove(string key)
    {
        return Client.Remove(key);
    }


    /// <summary>
    /// 清空所有缓存
    /// </summary>
    public static void Clear() {
        Client.FlushAll();
    }







}