using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.IBLL
{
    public partial interface ISMLOGService
    {
        /// <summary>
        /// 多条件搜索日志信息
        /// </summary>
        /// <param name="logParam">日志查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMLOG> LoadSearchEntities(LogParam logParam);
    }
}
