using System;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using Npgsql;
using Should;
using Xunit;

namespace Hapthorn.Test
{
    public class ProgramSpecs
    {
        private IConfigurationRoot Configuration => Mock.Of<IConfigurationRoot>();
        private IWebHost WebHost => Program.BuildWebHost(Configuration);
        private IServiceProvider Services => WebHost.Services;

        [Fact]
        public void WebHostShouldBuild()
        {
            WebHost.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldResolveDatabaseConnection()
        {
            Services.GetService(typeof(IDbConnection)).ShouldNotBeNull();
            Services.GetService(typeof(IDbConnection)).ShouldBeType<NpgsqlConnection>();
        }
    }
}