using RolePermission.DAL;
using RolePermission.IDAL;
using RolePermission.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RolePermission.DALSessionFactory
{
    /// <summary>
    /// DBSession;工厂类（数据会话层），作用：创建数据操作类的实例，业务层通过DBSession调用相应的数据操作类的实例，这样将业务层与数据层解耦。
    /// </summary>
    public partial class DBSession : IDBSession
    {
        private readonly DbContext db;

        public DBSession(DbContext context, ISMFIELDRepository smfieldRepository,
            ISMFUNCTBRepository smfunctbRepository, ISMLOGRepository smlogRepository,
            ISMMENUROLEFUNCTBRepository smmenurolefunctbRepository, ISMMENUTBRepository smmenutbRepository,
            ISMROLETBRepository smroletbRepository, ISMUSERTBRepository smusertbRepository)
        {
            this.db = context;
            this.ISMFIELDRepository = smfieldRepository;
            this.ISMFUNCTBRepository = smfunctbRepository;
            this.ISMLOGRepository = smlogRepository;
            this.ISMMENUROLEFUNCTBRepository = smmenurolefunctbRepository;
            this.ISMMENUTBRepository = smmenutbRepository;
            this.ISMROLETBRepository = smroletbRepository;
            this.ISMUSERTBRepository = smusertbRepository;
        }

        public ISMFIELDRepository ISMFIELDRepository { get; }

        public ISMFUNCTBRepository ISMFUNCTBRepository { get; }

        public ISMLOGRepository ISMLOGRepository { get; }

        public ISMMENUROLEFUNCTBRepository ISMMENUROLEFUNCTBRepository { get; }

        public ISMMENUTBRepository ISMMENUTBRepository { get; }

        public ISMROLETBRepository ISMROLETBRepository { get; }

        public ISMUSERTBRepository ISMUSERTBRepository { get; }

        /// <summary>
        /// 执行EF上下文的SaveChanges方法
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            //db.Configuration.ValidateOnSaveEnabled = false;
            return db.SaveChanges() > 0;
        }

        public int ExecuteSql(string sql, params System.Data.SqlClient.SqlParameter[] pars)
        {
            return pars == null ? db.Database.ExecuteSqlCommand(sql) : db.Database.ExecuteSqlCommand(sql, pars);
        }

//        public List<T> ExecuteSelectQuery<T>(string sql, params System.Data.SqlClient.SqlParameter[] pars)
//        {
//            return db.Database.SqlQuery<T>(sql, pars).ToList();
//        }
    }
}