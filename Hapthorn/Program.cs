using System;
using System.IO;
using Hapthorn.Services.ConsoleArguments;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

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
            ConfigureLogger(configuration);

            Console.WriteLine("  CommandName: [{0}]", manager.CommandName);

            switch (manager.CommandName)
            {
                case "web":
                    Console.WriteLine("Building and starting Web Host");
                    var webHost = BuildWebHost(configuration);
                    webHost.Run();
                    break;
                case "migrate":
                    Console.WriteLine("Executing Migrations");
                    break;
            }
        }

        public static IWebHost BuildWebHost(IConfigurationRoot configuration) =>
            new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build();
        
        private static IConfigurationRoot BuildConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        
        private static void ConfigureLogger(IConfigurationRoot configuration) =>
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.LiterateConsole()
                .MinimumLevel.Is(LogEventLevel.Debug)
                .CreateLogger();
    }
}