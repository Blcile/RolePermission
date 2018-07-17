using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.IBLL
{
    public partial interface ISMMENUTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="menuParam">查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMMENUTB> LoadSearchEntities(MenuParam menuParam);
        /// <summary>
        /// 根据PersonId获取已经启用的菜单
        /// </summary>
        /// <param name="personId">人员的Id</param>
        /// <returns>菜单拼接的字符串</returns>
        string GetMenuByAccount(ref Account person);
        SMMENUTB Create(SMMENUTB entity);
        /// <summary>
        /// 编辑一个菜单
        /// </summary>
        bool Edit(SMMENUTB entity);
        bool Delete(SMMENUTB entity);
        IQueryable<SMMENUTB> GetAllMetadata();
    }
}
