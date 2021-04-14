using AndcultureCode.CSharp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rws.Api.Business.Core.Extensions;
using Rws.Api.Data.SqlServer;
using Serilog;
using Serilog.Extensions.Logging;
using AutoMapper;
using Rws.Api.Presentation.Web.Models;
using AndcultureCode.CSharp.Core.Extensions;

namespace Web.Extensions.Startup
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfigurationRoot configuration, IHostEnvironment environment)
        {
            services
                .AddAutoMapper(typeof(MappingProfile))
                .AddContexts(configuration, environment.EnvironmentName);

            return services;
        }
        public static IServiceCollection AddContexts(this IServiceCollection services, IConfigurationRoot configuration, string environmentName)
        {
            var connectionString = configuration.GetDatabaseConnectionString();

            var loggerFactory = environmentName.ToLower() == "testing" ? null : new SerilogLoggerFactory(Log.Logger, false);

            // Context gets registered several different ways (will this still be the same instance in the single scope?)
            services.AddDbContext<RwsApiContext>(ServiceLifetime.Scoped);
            services.AddScoped((sp) => new RwsApiContext(connectionString, loggerFactory));
            services.AddScoped<RwsApiContext>((sp) => new RwsApiContext(connectionString, loggerFactory));
            services.AddScoped<IContext>((sp) => new RwsApiContext(connectionString, loggerFactory));
            services.AddScoped<RwsApiContext>((sp) => new RwsApiContext(connectionString, loggerFactory));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
