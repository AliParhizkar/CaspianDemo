using Service;
using Caspian.UI;
using Caspian.Common;
using Caspian.Common.Service;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.BaseInfo;
using FluentValidation.Internal;
using FluentValidation;
using System.Linq;
using Caspian.Common.RowNumber;

namespace CaspianDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<FormAppState>();
            services.AddSingleton<WindowAppState>();
            services.AddSingleton<IServiceCollection>(services);

            services.AddTransient<MyContext>(t => { return new Context(); });
            services.AddTransient<ProvinceService>();
            services.AddTransient<CityService>();
            services.AddTransient<AreaService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<BaseDefinationService>();
            
            services.AddTransient<ISimpleService<Province>>(t => { return new ProvinceService(); });
            services.AddTransient<ISimpleService<Area>>(t => { return new AreaService(); });
            services.AddTransient<ISimpleService<City>>(t => { return new CityService(); });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
       
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
