using RolePermission.Model;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RolePermission.IDAL
{
    public partial interface IDBSession
    {
        bool SaveChanges();
        int ExecuteSql(string sql, params System.Data.SqlClient.SqlParameter[] pars);
        //List<T> ExecuteSelectQuery<T>(string sql, params System.Data.SqlClient.SqlParameter[] pars);
    }
}
