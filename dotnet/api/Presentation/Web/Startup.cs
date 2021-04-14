using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Utilities.Configuration;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Extensions.Startup;

namespace Web
{
    public class Startup
    {
        #region Properties

        public IConfigurationRoot _configuration { get; }
        public IHostEnvironment _environment { get; }

        #endregion Properties

        #region Constructor

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Program>();
            //}

            _configuration = builder.Build();
            _environment = env;

            ConfigurationUtils.SetConfiguration(_configuration);
            ConfigurationUtils.GetConnectionString("RwsApi");
        }

        #endregion Constructor

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApi(_configuration, _environment).AddControllers();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddViewLocalization().AddDataAnnotationsLocalization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "mvc controllers",
            //         template: "{controller}/{action=Index}/{id?}");
            // });

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });

                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
