using AdessoRideShare.Infrastructure.EntityFramework.Context;
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

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<Seeder>();
            //services.AddTransient<IPageRepository, PageRepository>();
            //services.AddTransient<ISectionRepository, SectionRepository>();
            //services.AddTransient<IDynamicSectionRepository, DynamicSectionRepository>();



        }
    }
}
