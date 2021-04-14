using System;
using Microsoft.Extensions.Configuration;

namespace Rws.Api.Business.Core.Extensions
{
    public static class IConfigurationRootExtensions
    {
        /// <summary>
        /// Retrieves web application's primary database connection string
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string GetDatabaseConnectionString(this IConfigurationRoot configuration)
            // Note: Using colon vs underscore results in only the appsettings file being read and not the environment variable
            => configuration?.GetSection("ConnectionStrings")?.GetValue<string>(ApplicationConstants.DATABASE_CONFIGURATION_KEY);

        /// <summary>
        /// Retrieves the database name of the primary database connection string
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string GetDatabaseName(this IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetDatabaseConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return null;
            }

            var settings = connectionString.Split(';');

            foreach (var setting in settings)
            {
                if (!setting.ToLower().TrimStart().StartsWith("database"))
                {
                    continue;
                }

                return setting.Split('=')[1];
            }

            return null;
        }

        /// <summary>
        /// Loads and conditionally updates the Version number based upon environment
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="isDevelopment"></param>
        /// <returns></returns>
        public static string GetVersion(this IConfigurationRoot configuration, string environmentName)
        {
            var buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");
            var version = configuration.GetValue<string>("Version");

            if (string.IsNullOrWhiteSpace(buildNumber))
            {
                return version.Replace(
                    "{BUILD_NUMBER}",
                    string.IsNullOrWhiteSpace(environmentName) ? "dev" : environmentName
                );
            }

            return version.Replace("{BUILD_NUMBER}", buildNumber);
        }
    }
}