using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hapthorn.Data
{
    public static class DataServiceConfiguration
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Add(
                new ServiceDescriptor(typeof(IDbConnection),
                p => new Npgsql.NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped)
            );
        }
    }
}