using RolePermission.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using RolePermission.BLL;
using RolePermission.Model;
using RolePermission.Model.SearchParam;
using RolePermission.WebApp.Models;

namespace RolePermission.WebApp.Controllers
{
    public class SysLogController : BaseController
    {
        private readonly SMLOGService SMLOGService;
        private readonly SysFieldModels SysFieldModels;

        public SysLogController(SMLOGService logService,
            SysFieldModels sysFieldModels)
        {
            SMLOGService = logService;
            SysFieldModels = sysFieldModels;
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        //[CompressFilter]
//          [MyAuthorize]
        public ActionResult Index()
        {
            ViewBag.LogStatus = SysFieldModels.GetSysField("SMLOG", "STATUS");
            return View();
        }

        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData(LogParam logParam)
        {
            var queryData = SMLOGService.LoadSearchEntities(logParam);

            var data = queryData.Select(o => new
            {
                LOG_ID = o.LOG_ID,
                OPERATION_TYPE = o.OperaterTypeName,
                USER_ID = o.SMUSERTB.USER_NAME,
                LOG_DATETIME = o.LOG_DATETIME,
                FUNC_CODE = o.FUNC_CODE,
                REMARK = o.REMARK
            });

            //构造成Json的格式传递
            var result = new { total = logParam.TotalCount, rows = data };
            //return Json(result, JsonRequestBehavior.AllowGet);
            return Json(result);
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Details(int id)
        {
            SMLOG logInfo = SMLOGService.LoadEntities(x=>x.LOG_ID==id).FirstOrDefault();

            //return Json(logInfo, JsonRequestBehavior.AllowGet);
            return Json(logInfo);
        }

    }
}
