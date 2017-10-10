using System;
using System.Data;
using Hapthorn.Data.Migrator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            var logger = ServiceProvider.GetService<ILogger>();
            var dbConnection = ServiceProvider.GetService<IDbConnection>();

            var migrations = new AssemblyMigrationScanner(this.GetType().Assembly).GetMigrations();
        }
    }
}