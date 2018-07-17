using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Memcached.ClientLibrary;

namespace RolePermission.Common
{
    public class MemcacheHelper
    {
        //private static readonly MemcachedClient mc = null;
        private static readonly Dictionary<string, object> carch = null;
        static MemcacheHelper()
        {
            carch = new Dictionary<string, object>();
//            string[] serverlist = { "127.0.0.1:11211" };//一定要将地址写到Web.config文件中。
//            //初始化池
//            SockIOPool pool = SockIOPool.GetInstance();
//            pool.SetServers(serverlist);
//
//            pool.InitConnections = 3;
//            pool.MinConnections = 3;
//            pool.MaxConnections = 5;
//
//            pool.SocketConnectTimeout = 1000;
//            pool.SocketTimeout = 3000;
//
//            pool.MaintenanceSleep = 30;
//            pool.Failover = true;
//
//            pool.Nagle = false;
//            pool.Initialize();
//
//            // 获得客户端实例
//            mc = new MemcachedClient();
//            mc.EnableCompression = false;
        }
        /// <summary>
        /// 向Memcache中写数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, object value)
        {
            carch.Add(key, value);
        }
        /// <summary>
        ///  向Memcache中写数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time">过期时间</param>
        public static void Set(string key, object value, DateTime time)
        {
            carch.Add(key, value);
        }
        /// <summary>
        /// 获取Memcahce中的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            carch.TryGetValue(key, out var m);
            return m ?? null;
        }
        /// <summary>
        /// 删除Memcache中的数据
        /// </summary>
        /// <param name="key"></param>
        public static bool Delete(string key)
        {
            carch.TryGetValue(key, out var m);
            if (null!=m)
            {
                return carch.Remove(key);
            }
            return false;
        }
    }
}
