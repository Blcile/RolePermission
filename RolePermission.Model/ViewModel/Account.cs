using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.Model
{
    /// <summary>
    /// 登录的用户信息
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int USER_ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string USER_NAME { get; set; }
        /// <summary>
        /// 登录的用户名
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 角色的集合
        /// </summary>
        public List<int> RoleIds { get; set; }

        /// <summary>
        /// 菜单的集合
        /// </summary>
        public List<int> MenuIds { get; set; }

        /// <summary>
        /// 行业编码
        /// </summary>
        public string GuidCode { get; set; }

    }
}
