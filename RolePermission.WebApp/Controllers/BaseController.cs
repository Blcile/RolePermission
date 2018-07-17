using RolePermission.IBLL;
using RolePermission.Model;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RolePermission.WebApp.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        protected Account GetCurrentAccount()
        {
            if (GetCookies("sessionId") != null)
            {
                string sessionId = GetCookies("sessionId"); //接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(sessionId); //根据key从Memcache中获取用户的信息
                return obj == null ? null : Common.SerializerHelper.DeserializeToObject<Account>(obj.ToString());
            }
            else
            {
                return null;
            }
        }

        protected string GetSession(string key)
        {
            return HttpContext.Session.GetString(key);
        }

        protected void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value??"");
        }

        protected string GetCookies(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out var m);
            return m;
        }

        protected void SetCookies(string key, string value, int? expireTime = 60 * 60)
        {
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(expireTime.Value),
                Path = "/",
                Secure = false,
                IsEssential = true
            };
            HttpContext.Response.Cookies.Append(key, value);
        }

        protected void RemoveCookies(string key)  
        {  
            HttpContext.Response.Cookies.Delete(key);  
        }  
    }
}