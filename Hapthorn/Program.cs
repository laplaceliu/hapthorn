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