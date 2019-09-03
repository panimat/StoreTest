using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POSStore.Data;
using POSStore.Data.Interfaces;
using POSStore.Data.Model;
using POSStore.Data.Repositories;
using Microsoft.AspNetCore.Rewrite;

namespace POSStore
{
    public class Startup
    {
        private IConfigurationRoot _configStr;
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment host, IConfiguration configuration)
        {
            _configStr = new ConfigurationBuilder().SetBasePath(host.ContentRootPath).AddJsonFile("dbConnect.json").Build();
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });


            services.AddDbContext<AppDBInfo>(options => options.UseSqlServer(_configStr.GetConnectionString("DefaultConnection")));
            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc();
            services.AddTransient<IProduct, ProductRepos>();
            services.AddTransient<IProductCategory, CategoryRepos>();
            services.AddTransient<IAllOrders, OrderRepos>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Several cart for different users
            services.AddScoped(sc => StoreCart.storeCart(sc));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", action = "List" });
            });
            
            var options = new RewriteOptions().AddRedirectToHttps();

            app.UseRewriter(options);
            AppDBInfo content;

            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDBInfo>();
                DBObject.Initial(content);
            }
        }
    }
}
