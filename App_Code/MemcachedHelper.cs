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
    
    private MemcachedClient mc;

    public MemcachedHelper() {
        mc = new MemcachedClient();
    }

    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="key">键名</param>
    /// <param name="value">键值</param>
    /// <param name="expires">有效时间。单位是分钟</param>
    /// <returns></returns>
    public bool Set(string key,object value, int? expires = null) {
        
        Debug.WriteLine(key);
        if (expires == null || expires < 1)
        {
            return mc.Store(StoreMode.Set, key, value);
        }
        else
        {
            return mc.Store(StoreMode.Set, key, value, DateTime.Now.AddMinutes((double)expires));
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public object Get(string key) 
    {
        return mc.Get(key);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T Get<T>(string key) where T : class
    {
        return mc.Get<T>(key);
    }

    public IDictionary<string,object> Get(List<string> keys)
    {
        return mc.Get(keys);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsExist(string key) {
        //return mc.Get(key) != null;//memcache不允许将值设置null
        object obj;
        return mc.TryGet(key, out obj);
    }

    /// <summary>
    /// 删除指定缓存
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool Remove(string key)
    {
        return mc.Remove(key);
    }


    /// <summary>
    /// 清空所有缓存
    /// </summary>
    public void Clear() {
        mc.FlushAll();
    }







}