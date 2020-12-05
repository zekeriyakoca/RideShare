using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShare.Infrastructure.EntityFramework.Seed
{
    public class Seeder
    {
        private readonly DataContext context;

        public Seeder(DataContext context)
        {
            this.context = context;
        }
        public async Task SeedAsync()
        {
            if (context.Users.Count() > 0)
                return;
            var adminUser = new User
            {
                UserName = "test",
                Email = "test@gmail.com",
                Password = "Test123.",
                Role = Dtos.Enums.Role.Admin,
                CreatedTime = DateTime.Now,

            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();

            return;
        }
    }
}
