using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Dtos.Enums;
using Cache.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AdessoRideShare.Infrastructure
{
    public class ApplicationDefaultsSeeder
    {
        private readonly ICacheService cacheService;

        public ApplicationDefaultsSeeder(ICacheService cacheService)
        {
            this.cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }
        public Task SetDefaults()
        {
            var mockedUser = new Boss
            {
                UserName = "test",
                Email = "test@gmail.com",
                Password = "Test123.",
                Role = Dtos.Enums.Role.Admin,
                Id = 1
            };
            this.cacheService.SetValue<Boss>(CacheKeys.CurrentUser, mockedUser);
            return Task.CompletedTask;
        }
    }
}
