using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RolePermission.WebApp.Filter
{
    /// <summary>
    /// 数据压缩
    /// </summary>
    public class CompressFilterAttribute : ActionFilterAttribute
    {
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            //HttpRequestBase request = filterContext.HttpContext.Request;
//            HttpRequest request = filterContext.HttpContext.Request;
//
//            string acceptEncoding = request.Headers["Accept-Encoding"];
//
//            if (string.IsNullOrEmpty(acceptEncoding)) return;
//
//            acceptEncoding = acceptEncoding.ToUpperInvariant();
//
//            //HttpResponseBase response = filterContext.HttpContext.Response;
//            HttpResponse response = filterContext.HttpContext.Response;
//
//            if (acceptEncoding.Contains("GZIP"))
//            {
//                response.Headers.Add("Content-encoding", "gzip");
//                //response.AppendHeader("Content-encoding", "gzip");
//                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
//            }
//            else if (acceptEncoding.Contains("DEFLATE"))
//            {
//                response.Headers.Add("Content-encoding", "deflate");
//                //response.AppendHeader("Content-encoding", "deflate");
//                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
//            }
//        }
    }
}