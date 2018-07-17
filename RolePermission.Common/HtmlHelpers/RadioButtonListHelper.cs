//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Text;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
//
//namespace RolePermission.Common.HtmlHelpers
//{
//    public static class RadioButtonListHelper
//    {
//        /// <summary>
//        /// Radio列表
//        /// </summary>
//        /// <param name="htmlHelper">辅助类</param>
//        /// <param name="selectList">集合</param>
//        /// <param name="htmlAttributes">html标签</param>
//        /// <param name="isChecked">默认单选状态</param>
//        /// <returns></returns>
//        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool isChecked = false)
//        {
//            string name = ExpressionHelper.GetExpressionText(expression);
//            return RadioButtonList(htmlHelper, name, selectList, htmlAttributes, isChecked);
//        }
//        /// <summary>
//        /// Radio列表
//        /// </summary>
//        /// <param name="htmlHelper">辅助类</param>
//        /// <param name="selectList">集合</param>
//        /// <param name="isChecked">默认单选状态</param>
//        /// <returns></returns>
//        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, bool isChecked = false)
//        {
//            string name = ExpressionHelper.GetExpressionText(expression);
//            return RadioButtonList(htmlHelper, name, selectList, new { }, isChecked);
//        }
//
//        /// <summary>
//        /// Radio列表
//        /// </summary>
//        /// <param name="htmlHelper">辅助类</param>
//        /// <param name="name">字段名称</param>
//        /// <param name="selectList">集合</param>
//        /// <param name="htmlAttributes">html标签</param>
//        /// <param name="isChecked">默认单选状态</param>
//        /// <returns></returns>
//        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes, bool isChecked = false)
//        {
//            IDictionary<string, object> HtmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
//            string defaultValue = string.Empty;
//            if (htmlHelper.ViewData.Model != null)
//            {
//                if (!string.IsNullOrWhiteSpace(name))
//                {
//                    defaultValue = htmlHelper.ViewData.Eval(name).GetString();
//
//                }
//                isChecked = false;
//            }
//
//            StringBuilder str = new StringBuilder();
//            foreach (SelectListItem item in selectList)
//            {
//                str.Append("<input ");
//                if (item.Value == defaultValue)
//                {
//                    str.Append("checked='checked' ");
//
//                }
//                if (isChecked)
//                {
//
//                    str.Append(" checked=true ");
//                    isChecked = false;
//                }
//                foreach (var bute in HtmlAttributes)
//                {
//                    str.Append(bute.Key + "=\"" + bute.Value);
//
//                }
//
//                str.Append("\" id=\"" + item.Value + "\" type=\"radio\"  value=\"" + item.Value + "\" name=\"" + name + "\"/>");
//                str.Append(item.Text);
//            }
//            return MvcHtmlString.Create(str.ToString());
//        }
//    }
//}
