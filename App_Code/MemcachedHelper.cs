using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MemcachedHelper 的摘要说明
/// </summary>
public class MemcachedHelper
{
    
    private MemcachedClient mc;

    public MemcachedHelper() {
        mc = new MemcachedClient();
    }

    public bool Set(string key,object value) {
        return mc.Store(StoreMode.Set, key, value);
    }

    public T Get<T>(string key) 
    {
        return mc.Get<T>(key);
    }









}