using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace Prototype
{
    using Infrastructure.Settings;
    using Microsoft.OpenApi.Models;
    using Prototype.Middleware;
    using System.Reflection;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddReferentialsServices();
            services.AddConfigurations();
            services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prototype v1"));
            }
            app.UseRouting();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
