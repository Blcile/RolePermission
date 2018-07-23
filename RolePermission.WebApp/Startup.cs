using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RolePermission.BLL;
using RolePermission.DAL;
using RolePermission.DALSessionFactory;
using RolePermission.IBLL;
using RolePermission.IDAL;
using RolePermission.Model;
using RolePermission.WebApp.Models;

namespace RolePermission.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddDependencies(services);
            services.AddDbContext<RolePermissionEntities>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RoleP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();
            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60 * 60);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc()
                .AddJsonOptions(options =>
                    {
                        //忽略循环引用
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        //不使用驼峰样式的key,使用原本属性字段名
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                        //设置时间格式
                        options.SerializerSettings.DateFormatString = "yyy-MM-dd";
                    }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseResponseCompression();
            app.UseSession();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public IServiceCollection AddDependencies(IServiceCollection services)
        {
            services.AddScoped<DbContext, RolePermissionEntities>();
            services.AddScoped<IDBSession, DBSession>();

            services.AddScoped<ISMFIELDRepository, SMFIELDRepository>();
            services.AddScoped<ISMFUNCTBRepository, SMFUNCTBRepository>();
            services.AddScoped<ISMLOGRepository, SMLOGRepository>();
            services.AddScoped<ISMMENUROLEFUNCTBRepository, SMMENUROLEFUNCTBRepository>();
            services.AddScoped<ISMMENUTBRepository, SMMENUTBRepository>();
            services.AddScoped<ISMROLETBRepository, SMROLETBRepository>();
            services.AddScoped<ISMUSERTBRepository, SMUSERTBRepository>();

            services.AddScoped<SMFIELDService>();
            services.AddScoped<SMFUNCTBService>();
            services.AddScoped<SMMENUROLEFUNCTBService>();
            services.AddScoped<SMLOGService>();
            services.AddScoped<SMMENUTBService>();
            services.AddScoped<SMROLETBService>();
            services.AddScoped<SMUSERTBService>();

            services.AddScoped<SysFieldModels>();

            return services;
        }
    }
}