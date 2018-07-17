using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System.Linq;

namespace RolePermission.IBLL
{
    public partial interface ISMROLETBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="roleParam">角色查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMROLETB> LoadSearchEntities(RoleParam roleParam);
        SMROLETB Create(SMROLETB entity);
        bool Edit(SMROLETB entity);
        bool Delete(SMROLETB model);
        bool SaveCollection(string[] ids, int id);
    }
}
