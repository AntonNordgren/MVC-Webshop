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

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<BookStoreDbContext>();
            //dependency injection 
            services.AddScoped<IBookRepository, BookRepository>();
            
            services.AddScoped<IGenreRepository, GenreRepository>();
          //  services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ShoppingCartActions>(ci => ShoppingCartActions.GetCart(ci));

          
             services.AddDbContext<BookStoreDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("BookStoreDbContext")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<BookStoreDbContext>()
            //.AddDefaultUI()
            //.AddDefaultTokenProviders();

            services.AddDefaultIdentity<ApplicationUser>
                (options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BookStoreDbContext>()
            .AddDefaultUI().AddDefaultTokenProviders(); 

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //  .AddEntityFrameworkStores<BookStoreDbContext>();


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

        /// to be used later with React
        ///more information on  https://reactjs.net/tutorials/aspnetcore.html 
        /* 
        app.UseReact(config =>
        {
             config.AddScript("file");
        });
        */

        // inject middleware in HTTP pipeline
        // Page not Found
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Pages500");
            }
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    context.Request.Path = "/Pages404";
                    await next();
                }
            });
            

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
