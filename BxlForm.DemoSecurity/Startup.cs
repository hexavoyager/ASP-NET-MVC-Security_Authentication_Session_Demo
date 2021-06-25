using BxlForm.DemoSecurity.Models.Client.Repositories;
using BxlForm.DemoSecurity.Models.Client.Services;
using GR = BxlForm.DemoSecurity.Models.Global.Repositories;
using GS = BxlForm.DemoSecurity.Models.Global.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Connections.Database;
using Microsoft.Data.SqlClient;
using BxlForm.DemoSecurity.Infrastructure.Session;

namespace BxlForm.DemoSecurity
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();

            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, Configuration.GetConnectionString("DemoSecurityDb")));
            services.AddSingleton<GR.IAuthRepository, GS.AuthService>();
            services.AddSingleton<GR.IContactRepository, GS.ContactService>();
            services.AddSingleton<GR.ICategoryRepository, GS.CategoryService>();
            services.AddSingleton<IContactRepository, ContactService>();
            services.AddSingleton<ICategoryRepository, CategoryService>();
            services.AddSingleton<IAuthRepository, AuthService>();
            services.AddScoped<ISessionManager, SessionManager>();
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
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}
