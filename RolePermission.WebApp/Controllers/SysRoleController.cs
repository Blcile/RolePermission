using RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RolePermission.BLL;
using RolePermission.Common.HtmlHelpers;
using RolePermission.Common;
using RolePermission.Model;
using RolePermission.WebApp.Filter;

namespace RolePermission.WebApp.Controllers
{
//    [MyAuthorize]
    public class SysRoleController : BaseController
    {
        private readonly SMLOGService SMLOGService;
        private readonly SMROLETBService SMROLETBService;

        public SysRoleController(SMLOGService logService,
            SMROLETBService roleService,
            SMFUNCTBService funcService)
        {
            SMLOGService = logService;
            SMROLETBService = roleService;
        }
        #region 查询

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Index(string view)
        {
            return View();
        }

        /// <summary>
        /// 异步加载数据
        /// </summary>
        [HttpPost]
        //[SupportFilter]
        public JsonResult GetData(string id, RoleParam roleParam)
        {
            int total = 0;
            var queryData = SMROLETBService.LoadSearchEntities(roleParam);
            total = roleParam.TotalCount;

            var data = queryData.ToList().Select(m => new { ROLE_ID = m.ROLE_ID, ROLE_NAME = m.ROLE_NAME, CREATION_TIME = m.CREATION_TIME, REMARK = m.REMARK, STATUS = m.STATUS.GetStatusName() });

            //构造成Json的格式传递
            var result = new { total = total, rows = data };
            //return Json(result, JsonRequestBehavior.AllowGet);
            return Json(result);
        }

        #endregion
        #region 分配权限

        /// <summary>
        /// 首次设置SysMenu
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        //[SupportFilter]
        public ActionResult SetSysMenu(int id)
        {
            var entity = SMROLETBService.LoadEntities(x => x.ROLE_ID == id).FirstOrDefault();
            ViewData["myname"] = entity.ROLE_NAME;
            ViewData["myid"] = id;
            return View(entity);
        }

        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        //[SupportFilter]
        public ActionResult Save(IFormCollection collection)
        {
            string returnValue = string.Empty;
            string[] ids = collection["ids"].GetString().Split(',');
            int id = collection["id"].GetInt();
            int userId = GetCurrentAccount().USER_ID;

            SMLOG OperLog = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "900009", USER_ID = userId, CLASSNAME = this.GetType().ToString() + ": Save" };

            try
            {
                if (SMROLETBService.SaveCollection(ids, id))
                {
                    OperLog.REMARK = "信息的Id为" + string.Join(",", ids) + Suggestion.InsertSucceed;
                    SMLOGService.AddEntity(OperLog);

                    return Json("OK");
                }
                else
                {
                    OperLog.REMARK = "信息的Id为" + string.Join(",", ids) + Suggestion.InsertFail;
                    SMLOGService.AddEntity(OperLog);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Json(returnValue);
        }

        #endregion

        #region 增

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        //[SupportFilter]
        public ActionResult Create(string id)
        {
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public ActionResult Create(SMROLETB entity)
        {
            if (entity != null && ModelState.IsValid)
            {
                entity.CREATION_TIME = DateTime.Now;
                entity.CREATION_USER = GetCurrentAccount().USER_ID;

                string returnValue = string.Empty;
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "N", FUNC_CODE = "010701", USER_ID = GetCurrentAccount().USER_ID, CLASSNAME = this.GetType().ToString() + ": Create" };
                var result = SMROLETBService.Create(entity);

                if (result != null)
                {
                    OperLog.REMARK = "角色:" + entity.ROLE_NAME + Suggestion.InsertSucceed;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.InsertSucceed);
                }
                else
                {
                    OperLog.REMARK = "角色:" + entity.ROLE_NAME + Suggestion.InsertFail;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.InsertFail + returnValue); //提示插入失败
                }
            }

            return Json(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 
        }

        #endregion

        #region 删

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        //[SupportFilter]
        public ActionResult Delete(IFormCollection collection)
        {
            string returnValue = string.Empty;

            List<int> lists = collection["query"].GetString().ToIntList();
            int[] deleteId = lists.ToArray();

            if (deleteId != null && deleteId.Length > 0)
            {
                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "D", FUNC_CODE = "010701", USER_ID = Convert.ToInt32(GetCurrentAccount().USER_ID), CLASSNAME = this.GetType().ToString() + ": Delete" };

                if (deleteId.Length == 1)
                {
                    int roleId=deleteId[0];
                    var role = SMROLETBService.LoadEntities(r => r.ROLE_ID == roleId).FirstOrDefault();

                    if (SMROLETBService.Delete(role))
                    {
                        OperLog.REMARK = "角色Id：" + deleteId[0] + Suggestion.DeleteSucceed;
                        SMLOGService.AddEntity(OperLog);//写入日志 

                        return Json("OK");
                    }
                    else
                    {
                        OperLog.REMARK = "角色Id：" + deleteId[0] + Suggestion.DeleteFail;
                    }
                    SMLOGService.AddEntity(OperLog);//写入日志 
                }
            }
            return Json(returnValue);
        }

        #endregion

        #region 改

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        //[SupportFilter]
        public ActionResult Edit(int id)
        {
            SMROLETB item = SMROLETBService.LoadEntities(r=>r.ROLE_ID==id).FirstOrDefault();
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public ActionResult Edit(int id, SMROLETB entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                entity.UPDATE_USER = GetCurrentAccount().USER_ID;
                string returnValue = string.Empty;

                SMLOG OperLog = new SMLOG { OPERATION_TYPE = "U", FUNC_CODE = "010701", USER_ID = Convert.ToInt32(GetCurrentAccount().USER_ID), CLASSNAME = this.GetType().ToString() + ": Edit" };

                if (SMROLETBService.Edit(entity))
                {
                    OperLog.REMARK = "角色:" + entity.ROLE_NAME + Suggestion.UpdateSucceed;
                    SMLOGService.AddEntity(OperLog);//写入日志 

                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                {
                    OperLog.REMARK = "角色:" + entity.ROLE_NAME + Suggestion.UpdateFail + returnValue;

                    return Json(Suggestion.UpdateFail + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               
        }

        #endregion

        #region 详细

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[SupportFilter]
        public JsonResult Details(int id)
        {
              var item = SMROLETBService.LoadEntities(r => r.ROLE_ID == id).Select(r => new
                {
                    ROLE_NAME = r.ROLE_NAME,
                    CREATION_TIME = r.CREATION_TIME,
                    CreateUserName = r.SMUSERTB1==null?string.Empty:r.SMUSERTB1.USER_NAME,
                    UPDATE_TIME = r.UPDATE_TIME,
                    UpdateUserName = r.SMUSERTB==null?string.Empty:r.SMUSERTB.USER_NAME,
                    REMARK = r.REMARK,
                    SysPersonId = r.SMUSERTB2.Select(u => u.User.USER_NAME),
                    StatusName =r.STATUS
                }).FirstOrDefault();

                string statusName=item.StatusName.GetStatusName();
                string sysPersonId=item.SysPersonId.ToList().GetStringByList();

                var result = new
                {
                    ROLE_NAME = item.ROLE_NAME,
                    CREATION_TIME = item.CREATION_TIME,
                    UPDATE_TIME = item.UPDATE_TIME,
                    CreateUserName = item.CreateUserName,
                    UpdateUserName = item.UpdateUserName,
                    REMARK=item.REMARK,
                    SysPersonId = sysPersonId,
                    StatusName = statusName
                };

                //return Json(result, JsonRequestBehavior.AllowGet);          
                return Json(result);          
        }
        #endregion

    }
}
