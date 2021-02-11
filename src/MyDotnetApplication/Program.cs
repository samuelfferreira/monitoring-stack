using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Prometheus.DotNetRuntime;

namespace MyDotnetApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetRuntimeStatsBuilder.Customize()
                .WithThreadPoolSchedulingStats()
                .WithContentionStats()
                .WithGcStats()
                .WithJitStats()
                .WithThreadPoolStats()
                .WithExceptionStats()
                .WithErrorHandler(ex => Console.WriteLine("ERROR: " + ex.ToString()))
                .StartCollecting();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
