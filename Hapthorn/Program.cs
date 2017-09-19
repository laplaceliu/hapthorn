using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hapthorn.Services.ConsoleArguments;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hapthorn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing Hapthorn");
            var manager = new ConsoleArgumentsManager(args);
            
            Console.WriteLine("Building Web Host");
            var configuration = BuildConfiguration();
            var webHost = BuildWebHost(configuration);

            if ("web" == manager.CommandName)
            {
                Console.WriteLine("Building and starting Web Host");
                webHost.Run();
            }
        }

        public static IWebHost BuildWebHost(IConfigurationRoot configuration) =>
            new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
        
        private static IConfigurationRoot BuildConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
    }
}