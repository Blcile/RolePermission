using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RolePermission.Model.Relationship;

namespace RolePermission.Model
{
    public partial class RolePermissionEntities : DbContext
    {
        public RolePermissionEntities(DbContextOptions<RolePermissionEntities> options)
            : base(options)
        { }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RoleP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.SMROLETB2)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.SMUSERTB2)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<MenuFunc>()
                .HasKey(t => new { t.MenuId, t.FuncId });

            modelBuilder.Entity<MenuFunc>()
                .HasOne(pt => pt.Menu)
                .WithMany(p => p.SMFUNCTB)
                .HasForeignKey(pt => pt.MenuId);

            modelBuilder.Entity<MenuFunc>()
                .HasOne(pt => pt.Func)
                .WithMany(t => t.SMMENUTB)
                .HasForeignKey(pt => pt.FuncId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SMFIELD> SMFIELD { get; set; }
        public DbSet<SMFUNCTB> SMFUNCTB { get; set; }
        public DbSet<SMLOG> SMLOG { get; set; }
        public DbSet<SMMENUROLEFUNCTB> SMMENUROLEFUNCTB { get; set; }
        public DbSet<SMMENUTB> SMMENUTB { get; set; }
        public DbSet<SMROLETB> SMROLETB { get; set; }
        public DbSet<SMUSERTB> SMUSERTB { get; set; }
    }
}
