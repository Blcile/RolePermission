using RolePermission.Model;
using RolePermission.WebApp.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RolePermission.BLL;
using RolePermission.IBLL;

namespace RolePermission.WebApp.Controllers
{
//    [MyAuthorize]
    public class HomeController : BaseController
    {
        protected readonly SMUSERTBService SMUSERTBService;
        protected readonly SMMENUTBService SMMENUTBService;
        protected readonly SMMENUROLEFUNCTBService SMMENUROLEFUNCTBService;
        public HomeController(SMUSERTBService userService,
            SMMENUTBService menuService,
            SMMENUROLEFUNCTBService menuRoleService)
        {
            SMUSERTBService = userService;
            SMMENUTBService = menuService;
            SMMENUROLEFUNCTBService = menuRoleService;
        }
        public ActionResult Index()
        {
            var result = SMUSERTBService.LoadEntities(x => x.STATUS == "Y").ToList();
            ViewBag.Name =result!=null&&result.Count>0? result.FirstOrDefault().USER_NAME:"";
            Account account = GetCurrentAccount();
            if (account == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["PersonName"] = account.UID;

                ViewData["Menu"] = SMMENUTBService.GetMenuByAccount(ref account);// 获取菜单
            }
            return View();
        }
        /// <summary>
        /// 获取列表中的按钮导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetToolbar(int id)
        {
            Account account = GetCurrentAccount();
            if (account == null)
            {
                return Content(" <script type='text/javascript'> window.top.location='Account'; </script>");
            }

            List<SMFUNCTB> sysOperations = SMMENUROLEFUNCTBService.GetByRefSysMenuIdAndSysRoleId(id, account.RoleIds);
            List<toolbar> toolbars = new List<toolbar>();
            foreach (SMFUNCTB item in sysOperations)
            {
                toolbars.Add(new toolbar() { handler = item.EVENT_NAME, iconCls = item.ICONIC, text = item.FUNC_NAME });
            }
            //return Json(toolbars, JsonRequestBehavior.AllowGet);
            return Json(toolbars);
        }

        public ActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}
