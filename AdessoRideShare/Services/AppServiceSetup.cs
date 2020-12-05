using AdessoRideShare.Domain.Interface;
using AdessoRideShare.Domain.Interfaces;
using AdessoRideShare.Infrastructure;
using AdessoRideShare.Infrastructure.EntityFramework;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using AdessoRideShare.Infrastructure.EntityFramework.Seed;
using AdessoRideShare.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoRideShare.Panel.Services
{
    public class AppServiceSetup
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("AdessoRideShare")));
            services.AddSingleton<ApplicationDefaultsSeeder>();
            services.AddMemoryCache(); // TODO : Move into the Cache class library
            services.AddCache(Cache.Dtos.CachingServiceEnum.InMemory);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<Seeder>();
            services.AddTransient<IJourneyRepository, JourneyRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();



        }
    }
}
