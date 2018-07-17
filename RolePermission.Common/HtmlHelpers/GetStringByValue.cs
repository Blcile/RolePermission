using System.Collections.Generic;
using System.Text;

namespace RolePermission.Common.HtmlHelpers
{
    public static class GetStringByValue
    {
        public static string GetGenderName(this string str)
        {
            return str == "M" ? "男" : "女";
        }
        /// <summary>
        /// 根据ID获取状态名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStatusName(this string str)
        {
            switch (str)
            {
                case "Y":
                    return "启用";
                case "N":
                    return "停用";
                case "D":
                    return "删除";
                default:
                    return "未知";

            }
        }
        public static string GetStringByList(this List<string> lst)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var v in lst)
            {
                sb.Append(v + " ");
            }
            return sb.ToString();
        }
    }
}
