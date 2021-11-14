using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTGBL;
using TTGDL;

namespace TTGWebUI
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
            services.AddDbContext<database1Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ReferenceToDB")));
           
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ICustRepository, CustomerCloudRepo>();
           
            services.AddScoped<IStoreBL, StoreBL>();
            services.AddScoped<IStoreRepository, StoreCloudRepo>();
           
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IProductRepo, ProductCloudRepo>();

            services.AddScoped<ILineItemBL, LineItemBL>();
            services.AddScoped<ILineItemRepo, LineItemCloudRepo>();

            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IOrdersRepository, OrderCloudRepo>();

            services.AddScoped<IItemsInOrderBL, ItemsInOrderBL>();
            services.AddScoped<IItemsInOrderRepo, ItemsInOrderCloudRepo>();

            services.AddScoped<ILogInBL, LogInBL>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
                    pattern: "{controller=Customer}/{action=LogIn}/{id?}");
                    //pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
