using RolePermission.IBLL;
using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RolePermission.IDAL;

namespace RolePermission.BLL
{
    public partial class SMFUNCTBService : BaseService<SMFUNCTB>, ISMFUNCTBService
    {
        /// <summary>
        /// 多条件搜索角色信息
        /// </summary>
        /// <param name="operationParam">查询参数实体</param>
        /// <returns></returns>
       public IQueryable<SMFUNCTB> LoadSearchEntities(OperationParam operationParam)
        {
            Expression<Func<SMFUNCTB, bool>> whereLambda = PredicateBuilder.True<SMFUNCTB>();
            if (!string.IsNullOrEmpty(operationParam.FUNC_NAME))
            {
                whereLambda = whereLambda.And(u => u.FUNC_NAME.Contains(operationParam.FUNC_NAME));
            }
            if (!string.IsNullOrEmpty(operationParam.STATUS))
            {
                whereLambda = whereLambda.And(u => u.STATUS == operationParam.STATUS);
            }
            int count = 0;
            IQueryable<SMFUNCTB> queryData = null;
            if (!string.IsNullOrEmpty(operationParam.order) && !string.IsNullOrEmpty(operationParam.sort))
            {
                bool isAsc = operationParam.order == "asc" ? true : false;
                queryData = LoadPageEntities<SMFUNCTB>(operationParam.page, operationParam.rows, out count, whereLambda, operationParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMFUNCTB>(operationParam.page, operationParam.rows, out count, whereLambda, operationParam.sort, null);
            }
            operationParam.TotalCount = count;

            return queryData;
        }

        public SMFUNCTBService(IDBSession session) : base(session)
        {
        }
        public override void SetCurretnRepository()
        {
            CurrentRepository = GetCurrentDbSession.ISMFUNCTBRepository;
        }
    }
}
