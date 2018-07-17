using RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.IBLL
{
    public partial interface ISMMENUROLEFUNCTBService
    {
        /// <summary>
        /// 根据SysMenuIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        List<SMFUNCTB> GetByRefSysMenuIdAndSysRoleId(int id, List<int> sysRoleIds);
        IQueryable<SMMENUROLEFUNCTB> GetByRefSysRoleId(int id);
    }
}
