using Microsoft.Extensions.Configuration;
using Migr8;

namespace Hapthorn.Data
{
    public class MigrationHost
    {
        private readonly IConfigurationRoot _configuration;

        public MigrationHost(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public void Run()
        {
            Database.Migrate("DefaultConnection", Migr8.Migrations.FromThisAssembly());
        }
    }
}