using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System.Linq;

namespace RolePermission.IBLL
{
    public partial interface ISMFUNCTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="roleParam">角色查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMFUNCTB> LoadSearchEntities(OperationParam operationParam);
    }
}
