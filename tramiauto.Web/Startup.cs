using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models;
using tramiauto.Web.Models.Entities;
using tramiauto.Web.Models.InitDB;

namespace tramiauto.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded    = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddIdentity<UserLogin, IdentityRole>(cfg =>{ cfg.User.RequireUniqueEmail        = true;
                                                                 cfg.Password.RequireDigit           = false;
                                                                 cfg.Password.RequiredUniqueChars    = 0;
                                                                 cfg.Password.RequireLowercase       = false;
                                                                 cfg.Password.RequireNonAlphanumeric = false;
                                                                 cfg.Password.RequireUppercase       = false;
                                                                }).AddEntityFrameworkStores<DataContext>();

            /*** INYECCIÓN DE DEPENDENCIAS tres tipo: Transient(Solo se ejecuta una sola vez), singleton (carga en memoria se mantiene), scope (se inyecta cada vez que se necesita, crea una nueva instancia) ***/
            services.AddDbContext<DataContext>(cfg => { cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); });
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddTransient<SeedDb>();
            /*** INYECCIÓN DE DEPENDENCIAS ***/
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
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
