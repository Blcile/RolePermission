using Microsoft.EntityFrameworkCore;
using RolePermission.Model;
using RolePermission.IDAL;

namespace RolePermission.DAL
{
    public partial class SMFIELDRepository : BaseRepository<SMFIELD>, ISMFIELDRepository
    {
        public SMFIELDRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMFUNCTBRepository : BaseRepository<SMFUNCTB>, ISMFUNCTBRepository
    {
        public SMFUNCTBRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMLOGRepository : BaseRepository<SMLOG>, ISMLOGRepository
    {
        public SMLOGRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMMENUROLEFUNCTBRepository : BaseRepository<SMMENUROLEFUNCTB>, ISMMENUROLEFUNCTBRepository
    {
        public SMMENUROLEFUNCTBRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMMENUTBRepository : BaseRepository<SMMENUTB>, ISMMENUTBRepository
    {
        public SMMENUTBRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMROLETBRepository : BaseRepository<SMROLETB>, ISMROLETBRepository
    {
        public SMROLETBRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public partial class SMUSERTBRepository : BaseRepository<SMUSERTB>, ISMUSERTBRepository
    {
        public SMUSERTBRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}