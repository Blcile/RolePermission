using RolePermission.Common;
using RolePermission.IBLL;
using RolePermission.Model;
using RolePermission.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RolePermission.IDAL;

namespace RolePermission.BLL
{
    public partial class SMLOGService : BaseService<SMLOG>, ISMLOGService
    {
        /// <summary>
        /// 多条件搜索日志信息
        /// </summary>
        /// <param name="logParam">日志查询参数实体</param>
        /// <returns></returns>
        public IQueryable<SMLOG> LoadSearchEntities(LogParam logParam)
        {
            Expression<Func<SMLOG, bool>> whereLambda = PredicateBuilder.True<SMLOG>();
            if (!string.IsNullOrEmpty(logParam.OPERATION_TYPE))
            {
                whereLambda = whereLambda.And(u => u.OPERATION_TYPE == logParam.OPERATION_TYPE);
            }
            if (!string.IsNullOrEmpty(logParam.LOG_DATETIMEStart_Time))
            {
                DateTime startTime = Convert.ToDateTime(logParam.LOG_DATETIMEStart_Time);
                whereLambda = whereLambda.And(u => u.LOG_DATETIME >= startTime);
            }
            if (!string.IsNullOrEmpty(logParam.LOG_DATETIMEEnd_Time))
            {
                DateTime endTime = Convert.ToDateTime(logParam.LOG_DATETIMEEnd_Time);
                whereLambda = whereLambda.And(u => u.LOG_DATETIME <= endTime);
            }
            int count = 0;
            IQueryable<SMLOG> queryData = null;
            if (!string.IsNullOrEmpty(logParam.order) && !string.IsNullOrEmpty(logParam.sort))
            {
                bool isAsc = logParam.order == "asc" ? true : false;
                queryData =LoadPageEntities<SMLOG>(logParam.page, logParam.rows, out count, whereLambda, logParam.sort, isAsc);
            }
            else
            {
                queryData = LoadPageEntities<SMLOG>(logParam.page, logParam.rows, out count, whereLambda, logParam.sort, null);
            }
            logParam.TotalCount = count;

            foreach (var item in queryData)
            {
                item.OperaterTypeName = this.GetCurrentDbSession.ISMFIELDRepository.LoadEntities(x => x.MYTABLES == "SMLOG" && x.MYCOLUMS == "STATUS" && x.MYVALUES == item.OPERATION_TYPE).Select(x => x.MYTEXTS).FirstOrDefault();
            }
            return queryData;
        }

        public SMLOGService(IDBSession session) : base(session)
        {
        }
        public override void SetCurretnRepository()
        {
            CurrentRepository = GetCurrentDbSession.ISMLOGRepository;
        }
    }
}
