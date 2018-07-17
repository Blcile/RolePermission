using Microsoft.AspNetCore.Mvc.Filters;

namespace RolePermission.WebApp.Filter
{
    public class MyExceptionAttribute//: HandleErrorAttribute
    {
//        public static RedisClient client = new RedisClient("127.0.0.1", 6379);//发布到正式环境时，记得更改IP地址和默认端口，并且设置密码
//        #region 如果设置密码
//        //static string host = "127.0.0.1";/*访问host地址*/
//        //static string password = "2016@Test.88210_yujie";/*实例id:密码*/
//        //static readonly RedisClient client = new RedisClient(host, 6379, password); 
//        #endregion
//        //public static IRedisTypedClient<string> redis = client.As<string>(); //复杂对象
//
//        public override void OnException(ExceptionContext filterContext)
//        {
//            base.OnException(filterContext);
//            client.EnqueueItemOnList("errorMsg", filterContext.Exception.ToString());
//
//            //filterContext.HttpContext.Response.Redirect("/Error.html");
//        }
    }
}