using RolePermission.IBLL;
using RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RolePermission.WebApp.Models
{
    public class SysFieldModels
    {
        /// <summary>
        /// 是否添加选择行
        /// </summary>
        public static bool IsAddSelect = true;
        /// <summary>
        /// //选择项的文本
        /// </summary>
        public static string DefaultSelectText = "——请选择——";
        /// <summary>
        /// 默认选择项的值
        /// </summary>
        public static string DefaultSelectValue = "";

        private readonly ISMFIELDService FieldService;

        public SysFieldModels(ISMFIELDService fieldService)
        {
            FieldService = fieldService;
        }

//        public ISMFIELDService FieldService
//        {
//            get
//            {
//                return SpringHelper.GetObject<ISMFIELDService>("SMFIELDService");
//            }
//        }

        /// <summary>
        /// 获取字段，首选默认
        /// </summary>
        /// <returns></returns>
        public SelectList GetSysField(string table, string colum, string parentMyTexts)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum) || string.IsNullOrWhiteSpace(parentMyTexts))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            return new SelectList(FieldService.GetSysField(table, colum, parentMyTexts), "MYVALUES", "MYTEXTS");

        }
        public  SelectList GetSysField(string table, string colum, bool isSelect)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            List<SMFIELD> lists = FieldService.GetSysField(table, colum);
            if (isSelect)
            {
                if (IsAddSelect)
                {
                    lists.Insert(0, new SMFIELD { MYVALUES = DefaultSelectValue, MYTEXTS = DefaultSelectText });
                }
            }

            return new SelectList(lists, "MYVALUES", "MYTEXTS"); ;
        }

        /// <summary>
        /// 获取字段，首选默认，MyTexts做为value值
        /// </summary>
        /// <returns></returns>
        public  SelectList GetSysField(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            List<SMFIELD> lists = FieldService.GetSysField(table, colum);
            if (IsAddSelect)
            {
                if (IsAddSelect)
                {
                    lists.Insert(0, new SMFIELD { MYVALUES = DefaultSelectValue, MYTEXTS = DefaultSelectText });
                }
            }
            return new SelectList(lists, "MYVALUES", "MYTEXTS"); ;
        }
        /// <summary>
        /// 获取字段，首选默认，Id做为value值
        /// </summary>
        /// <returns></returns>
        public  SelectList GetSysFieldById(string table, string colum)
        {
            if (string.IsNullOrWhiteSpace(table) || string.IsNullOrWhiteSpace(colum))
            {
                List<SelectList> sl = new List<SelectList>();
                return new SelectList(sl);
            }
            return new SelectList(FieldService.GetSysField(table, colum), "MYVALUES", "MYTEXTS");

        }
        /// <summary>
        /// 根据主键id，获取数据字典的展示字段
        /// </summary>
        /// <param name="id">父亲节点的主键</param>
        /// <returns></returns>
        public string GetMyTextsById(int id)
        {
            if (id==0)
            {
                return string.Empty;
            }
            return FieldService.GetMyTextsById(id);
        }
    }
}