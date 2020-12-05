using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdessoRideShare.Infrastructure.EntityFramework.Seed;
using AdessoRideShare.Infrastructure;

namespace AdessoRideShare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            SetApplicationDefaults(host);
            host.Run();
        }

        private static void SetApplicationDefaults(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetService<DataContext>();
                dataContext.Database.Migrate();

                var seeder = scope.ServiceProvider.GetService<Seeder>();
                if (seeder != null)
                {
                    seeder.SeedAsync().Wait();
                }

                var applicationDefaultsSeeder = scope.ServiceProvider.GetService<ApplicationDefaultsSeeder>();
                if (applicationDefaultsSeeder != null)
                {
                    applicationDefaultsSeeder.SetDefaults().Wait();
                }

            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
