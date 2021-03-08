using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcClienteApi.Services;

namespace MvcClienteApi
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            String urlapidepartamentos =
                this.Configuration["urlapidepartamentos"];
            services.AddTransient(x => 
            new ServiceDepartamentos(urlapidepartamentos));
            String urldoctores =
                this.Configuration["urlapidoctores"];
            services.AddTransient(x => new ServiceDoctores(urldoctores));
            String urlapioauthempleados =
                this.Configuration["urlapioauthempleados"];
            services.AddTransient(x => new ServiceEmpleados(urlapioauthempleados));
            //CONFIGURAMOS LOS SERVICIOS PARA SESSION Y SEGURIDAD
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme =
                CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();

            services.AddControllersWithViews(options => {
                options.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(options =>
            {
                options.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
