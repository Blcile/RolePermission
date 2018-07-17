using RolePermission.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolePermission.IBLL
{
    public partial interface ISMUSERTBService
    {
        bool ChangePassword(string personName, string oldPassword, string newPassword);
        SMUSERTB ValidateUser(string userName, string password);
        /// <summary>
        /// 多条件搜索用户信息
        /// </summary>
        /// <param name="userInfoSearchParam">用户查询参数实体</param>
        /// <returns></returns>
        IQueryable<SMUSERTB> LoadSearchEntities(Model.SearchParam.UserInfoParam userInfoSearchParam);
        /// <summary>
        /// 修改用户信息,为用户分配角色
        /// </summary>
        /// <param name="oldRoleIds"></param>
        /// <param name="entity"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        bool UpdateUserInfo(List<int> oldRoleIds, SMUSERTB entity, List<int> roleIdList);
    }
}
