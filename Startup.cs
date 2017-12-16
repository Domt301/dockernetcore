using System;
using DockerCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace DockerCore
{
    public class Startup
    {
           private IConfiguration Configuration;

           public Startup(IHostingEnvironment env) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IRepository, DummyRepository>();
            services.AddMvc();
        }

         public void Configure(IApplicationBuilder app,
                IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      //  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
          //  if (env.IsDevelopment())
           // {
             //   app.UseDeveloperExceptionPage();
            //}
            //else
            //{
             //   app.UseExceptionHandler("/Home/Error");
            //}

            //app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
              //  routes.MapRoute(
                //    name: "default",
                  //  template: "{controller=Home}/{action=Index}/{id?}");
            //});
        //}
    }
}
