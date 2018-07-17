﻿using RolePermission.Common;
using RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using RolePermission.BLL;

namespace RolePermission.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        private readonly SMUSERTBService SMUSERTBService;
        public LoginController(SMUSERTBService userService)
        {
            SMUSERTBService = userService;
        }
        
        /// <summary>
        /// 登录界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            CheckCookieInfo();
            return View();
        }
        /// <summary>
        /// 点击登录系统 
        /// </summary>
        /// <param name="model">登录信息</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]//防伪造令牌来避免CSRF攻击
        public ActionResult Index(LogOnModel model)
        {
            #region 验证码验证

            if (GetSession("ValidateCode") != null && model.ValidateCode != null && model.ValidateCode.ToLower() != GetSession("ValidateCode").ToString())
            {
                ModelState.AddModelError("Error_PersonLogin", "验证码错误！"); 
                return View();
            }
            SetSession("ValidateCode", null);
            #endregion

            if (ModelState.IsValid)
            {
                SMUSERTB person = SMUSERTBService.ValidateUser(model.PersonName, Encrypt.DecodeText(model.Password));
                if (person != null) //登录成功
                {
                    Account account = person.ToAccount();

                    string sessionId = Guid.NewGuid().ToString();//作为Memcache的key
                    try
                    {
                        MemcacheHelper.Set(sessionId, Common.SerializerHelper.SerializeToString(account), DateTime.Now.AddMinutes(20));//使用Memcache代替Session解决数据在不同Web服务器之间共享的问题。
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    //Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以cookie的形式返回到浏览器端的内存中，当用户再次请求其它的页面请求报文中会以Cookie将该值再次发送服务端。
                    SetCookies("sessionId", sessionId);
                    if (model.RememberMe)
                    {
//                        HttpCookie ckUid = new HttpCookie("ckUid", model.PersonName);
//                        HttpCookie ckPwd = new HttpCookie("ckPwd", Encrypt.DecodeText(model.Password));
//                        ckUid.Expires = DateTime.Now.AddDays(3);
//                        ckPwd.Expires = DateTime.Now.AddDays(3);
//                        Response.Cookies["sessionId"].Expires = DateTime.Now.AddDays(3);
//                        Response.Cookies.Add(ckUid);
//                        Response.Cookies.Add(ckPwd);
                        SetCookies("ckUid", model.PersonName, 60*60*24*3);
                        SetCookies("ckPwd", Encrypt.DecodeText(model.Password), 60*60*24*3);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Error_PersonLogin", "用户名或者密码出错。");
            return View();
        }
        //获取验证码
        public ActionResult ShowValidateCode()
        {
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            SetSession("ValidateCode", code);
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            if (Request.Cookies["sessionId"] != null)
            {
                string key = GetCookies("sessionId");
                Common.MemcacheHelper.Delete(key);
                //Response.Cookies["ckUid"].Expires = DateTime.Now.AddDays(-1);
                //Response.Cookies["ckPwd"].Expires = DateTime.Now.AddDays(-1);
                RemoveCookies("ckUid");
                RemoveCookies("ckPwd");
            }
            return RedirectToAction("Index", "Login");
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            string currentPerson = GetCurrentAccount().UID;
            ViewBag.PersonNamea = currentPerson;
            if (string.IsNullOrWhiteSpace(currentPerson))
            {
                ModelState.AddModelError("Error_PwdModify", "对不起，请重新登陆");
            }
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">修改密码的模型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            string currentPerson = GetCurrentAccount().UID;
            ViewBag.PersonNamea = currentPerson;
            if (string.IsNullOrWhiteSpace(currentPerson))
            {
                ModelState.AddModelError("Error_PwdModify", "对不起，请重新登陆");
                return View();
            }
            if (ModelState.IsValid)
            {
                if (null != (SMUSERTBService.ValidateUser(currentPerson, Encrypt.DecodeText(model.OldPassword))))
                {
                    if (SMUSERTBService.ChangePassword(currentPerson, Encrypt.DecodeText(model.OldPassword), Encrypt.DecodeText(model.NewPassword)))
                    {
                        ModelState.AddModelError("Error_PwdModify", "修改密码成功");
                        return View();
                    }
                }
            }
            ModelState.AddModelError("Error_PwdModify", "修改密码不成功，请核实数据");
            return View();
        }
        /// <summary>
        /// 判断Cookie信息
        /// </summary>
        private void CheckCookieInfo()
        {
            if (Request.Cookies["ckUid"] != null && Request.Cookies["ckPwd"] != null)
            {
                string userName = GetCookies("ckUid");
                string userPwd = GetCookies("ckPwd");
                //判断Cookie中存储的用户密码和用户名是否正确.
                SMUSERTB person = SMUSERTBService.ValidateUser(userName, userPwd);
                if (person != null)
                {
                    string sessionId = Guid.NewGuid().ToString();//作为Memcache的key
                    var account = person.ToAccount();
                    Common.MemcacheHelper.Set(sessionId, Common.SerializerHelper.SerializeToString(account), DateTime.Now.AddMinutes(20));//使用Memcache代替Session解决数据在不同Web服务器之间共享的问题。
                    //Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以cookie的形式返回到浏览器端的内存中，当用户再次请求其它的页面请求报文中会以Cookie将该值再次发送服务端。
                    SetCookies("sessionId", sessionId);
                    //Response.Redirect("/Home/Index"); 尽量不要用这样的写法
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    //如果说帐号秘密是错误的，就没必要再把登录用户名和密码存在cookies中了
                    //Response.Cookies["ckUid"].Expires = DateTime.Now.AddDays(-1);
                    //Response.Cookies["ckPwd"].Expires = DateTime.Now.AddDays(-1);
                    RemoveCookies("ckUid");
                    RemoveCookies("ckPwd");
                }
            }
        }
    }
}
