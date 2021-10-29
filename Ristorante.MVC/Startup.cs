using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ristorante.Core;
using Ristorante.Core.Interfaces;
using Ristorante.EF;
using Ristorante.EF.Repositories;
using Ristorante.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ristorante.MVC
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
            services.AddControllersWithViews(
                options => options.Filters.Add(new LogFilterAttribute()));
            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            services.AddTransient<IRepositoryMenu, RepositoryMenuEF>();
            services.AddTransient<IRepositoryPiatto, RepositoryPiattoEF>();
            services.AddTransient<IRepositoryUser, RepositoryUserEF>();
            services.AddDbContext<RistoranteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Week8Ristorante")));


            //FILTRO DI AUTENTICAZIONE
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.LoginPath = new PathString("/User/Login");
                        options.AccessDeniedPath = new PathString("/User/Forbidden");
                    }
                );

            //FILTRO DI AUTORIZZAZIONE
            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Ristoratore", policy => policy.RequireRole("Ristoratore"));
                    options.AddPolicy("Cliente", policy => policy.RequireRole("Cliente"));
                }
            );
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

            app.UseAuthentication();
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
