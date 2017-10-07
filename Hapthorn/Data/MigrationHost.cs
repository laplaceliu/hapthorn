using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Migr8;

namespace Hapthorn.Data
{
    public class MigrationHost
    {
        private IServiceProvider ServiceProvider { get; }
        private IConfigurationRoot Configuration { get; }

        public MigrationHost(IConfigurationRoot configuration, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            Configuration = configuration;
        }

        public void Run()
        {
            var options = GetMigrationOptions();
            Database.Migrate("DefaultConnection", Migr8.Migrations.FromThisAssembly(), options);
        }

        private Options GetMigrationOptions()
        {
            var logger = ServiceProvider.GetService<ILogger>();
            var dbConnection = ServiceProvider.GetService<IDbConnection>();
            var options = new Options(
                migrationTableName: "HapthornMigrations",
                logAction: msg => logger.LogInformation(msg),
                verboseLogAction: msg => logger.LogDebug(msg)
            );
            return options;
        }
    }
}