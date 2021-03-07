using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTnetcoreAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DOTnetcoreAPI
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
           
            services.AddDbContext<DOTnetContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DOTnetConnectionString"));
            }
              );

            services.AddTransient<DOTnetSeader>();
            services.AddScoped<IDOTnetRepository, DOTnetRepository>();
            services.AddMvc().AddJsonOptions(opt=> opt.SerializerSettings.ReferenceLoopHandling= ReferenceLoopHandling.Ignore).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default", "/{Controller}/{action}/{id?}"
                   );
            });

       
        }
    }
}
