//using MVC_Webshop.Data;
using MVC_Webshop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;
using Rotativa.AspNetCore;
using MVC_Webshop.Data;

namespace MVC_Webshop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// /
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dependency injection 
            services.AddScoped<IBookRepository, BookRepository>();
            
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ShoppingCartActions>(ci => ShoppingCartActions.GetCart(ci));

          
             services.AddDbContext<BookStoreDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("BookStoreDbContext")));
             

            // Register the services 

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(
                option => option.DefaultEngineName = V8JsEngine.EngineName).AddV8();
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddRazorPages();


            //dependency injection  
            // dependencies which will be used later with Identity and DbContext
            /*
            

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();
            */
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

            /// to be used later with React
            ///more information on  https://reactjs.net/tutorials/aspnetcore.html 
            /* 
            app.UseReact(config =>
            {
                 config.AddScript("file");
            });
            */

            // inject middleware in HTTP pipeline
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // must be before UseRouting
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            BookStoreDbInitializer.Seed(app);//Seed database
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");
        }
    }
}
