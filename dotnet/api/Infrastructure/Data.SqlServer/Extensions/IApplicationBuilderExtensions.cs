using Microsoft.AspNetCore.Builder;
using System;
using Data.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Data.SqlServer.Extensions
{
    /// <summary>
    /// Infrastructure Data IApplicationBuilder Extensions
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        #region Public Methods

        /// <summary>
        /// Performs application startup related database configuration tasks
        /// </summary>
        /// <param name="app"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="migrate">Should outstanding code-first migrations be run?</param>
        /// <param name="seeds">Optional instance of seeds to run</param>
        public static void ConfigureDatabase<TContext>(
            this IApplicationBuilder app,
            IServiceProvider serviceProvider,
            bool migrate = true
        ) where TContext : class, IDatabaseContext
        {
            var context = serviceProvider.GetService<TContext>();
            var logger = serviceProvider.GetService<ILogger<IApplicationBuilder>>();

            if (migrate)
            {
                Migrate(context.Database, logger);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static void Migrate(DatabaseFacade database, ILogger<IApplicationBuilder> logger)
        {
            logger.LogInformation("Migrating database...");
            database.SetCommandTimeout(int.MaxValue);
            database.Migrate();
            logger.LogInformation("Database migrated");
        }

        #endregion Private Methods
    }
}
