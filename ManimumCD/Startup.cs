using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManimumCD.Repository;
using ManimumCD.Terminal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManimumCD
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
            var connection = string.Format(Configuration.GetConnectionString("DefaultConnectionString"), System.IO.Directory.GetCurrentDirectory());
            services.AddSingleton(connection);
            services.AddTransient<ITerminal, CmdTerminal>();
            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }


        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
