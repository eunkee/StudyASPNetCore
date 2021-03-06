using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCore.Services.Data;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Web
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
            //의존성 주입을 사용하기 위해 껍데기에 내용물을 넣어주는 서비스로 등록
            //껍데기             내용물
            //IUser인터페이스에 UserService 클래스 인스턴스를 주입
            services.AddScoped<IUser, UserService>();


            //DB접속정보, Migrations 프로젝트 지정
            //code-First
            //services.AddDbContext<CodeFirstDbContext>(options =>
            //options.UseSqlServer(connectionString: Configuration.GetConnectionString(name:"DefaultConnection"),
            //sqlServerOptionsAction:mig => mig.MigrationsAssembly(assemblyName:"NetCore.Services")));
            
            //Database-First : DB 접속 정보만
            services.AddDbContext<DBFirstDbContext>(options =>
            options.UseSqlServer(connectionString: Configuration.GetConnectionString(name: "DBFirstDBConnection")));


            //MVC 패턴을 사용하기 위해 서비스로 등록
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
