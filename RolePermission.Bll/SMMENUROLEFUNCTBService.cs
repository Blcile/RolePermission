using RolePermission.IBLL;
using RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RolePermission.IDAL;

namespace RolePermission.BLL
{
    public partial class SMMENUROLEFUNCTBService : BaseService<SMMENUROLEFUNCTB>, ISMMENUROLEFUNCTBService
    {
        /// <summary>
        /// 根据SysMenuIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public List<SMFUNCTB> GetByRefSysMenuIdAndSysRoleId(int id, List<int> sysRoleIds)
        {
            if (sysRoleIds.Count < 1)
            {
                return null;
            }
            else if (sysRoleIds.Count == 1)
            {
                int? roleId = sysRoleIds[0];
                return LoadEntities(c => c.MENUID == id && c.FUNC_ID != null && c.ROLEID == roleId).Select(s => s.SMFUNCTB)
                     .Where(o => o.STATUS == "Y" && o.SM_SYSTEM == "A").Distinct().OrderBy(o => o.ORDERCODE).AsQueryable().ToList<SMFUNCTB>();
            }
            else
            {
                return LoadEntities(c => c.MENUID == id && c.FUNC_ID != null && sysRoleIds.Any(a => a == c.ROLEID)).Select(s => s.SMFUNCTB).Distinct()
                     .OrderBy(o => o.ORDERCODE).ToList<SMFUNCTB>();
            }
        }
        /// <summary>
        /// 根据SysRoleIdId，获取所有角色菜单操作数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<SMMENUROLEFUNCTB> GetByRefSysRoleId(int id)
        {
            return LoadEntities(x=>x.ROLEID==id);
        }

        public SMMENUROLEFUNCTBService(IDBSession session) : base(session)
        {
        }
        public override void SetCurretnRepository()
        {
            CurrentRepository = GetCurrentDbSession.ISMMENUROLEFUNCTBRepository;
        }
    }
}
