using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Middleware
{
    using AutoMapper;
    using Infrastructure.Settings;
    using Entities;
    using DTOs.Request;
    using DTOs.Response;
    using Microsoft.OpenApi.Models;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Hosting;
    using Prototype.Extensions;

    public static class AppInjection
    {
        public static IServiceCollection AddReferentialsServices(this IServiceCollection services)
        {
            #region Injection
            services.AddSingleton<IAppSettings, AppSettings>();
            //services.AddTransient<IMonitor, Monitor>();
            //services.AddScoped<IPagosProcess, PagosProcess>();
            //services.AddScoped<ICobrosProcess, CobrosProcess>();
            //services.AddScoped<IPolicy, Policy>();
            #endregion Injection

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prototype", Version = "v1" });
            });

            return services;
        }
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            #region AutoMapper
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile(new Extensions.MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion AutoMapper

            #region Disabled DA
            services.Configure<ApiBehaviorOptions>(options => {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion Disabled DA

            #region DisabledCamelCaseControl
            services.AddControllers().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            #endregion DisabledCamelCaseControl

            services.AddMvc(); //Add SRVpg

            return services;
        }
        public static IApplicationBuilder AddReferentialsApplication(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
