using Service;
using Caspian.UI;
using Caspian.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Caspian.Common.Service;
using System.Linq;
using Model.AcceptingInfo;
using Model.Enums;

namespace Learning
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
            services.AddSingleton<MyContext>(new Context());
            services.AddSingleton<FormAppState>();
            services.AddSingleton<WindowAppState>();
            foreach(var serviceType in Assembly.GetAssembly(typeof(CityService)).GetTypes())
            {
                services.AddTransient(serviceType);
                var interfaceType = serviceType.GetInterfaces().SingleOrDefault(t => t.Name.StartsWith("ISimpleService"));
                if (interfaceType != null)
                    services.AddTransient(interfaceType, serviceType);
            }
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
