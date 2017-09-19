using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using Should;
using Xunit;

namespace Hapthorn.Test
{
    public class StartupSpecs
    {
        private IHostingEnvironment HostingEnvironment => Mock.Of<IHostingEnvironment>();
        private IConfigurationRoot Configuration => Mock.Of<IConfigurationRoot>();
        
        [Fact]
        public void CanCreateStartup()
        {
            new Startup(HostingEnvironment, Configuration).ShouldNotBeNull();
        }
    }
}