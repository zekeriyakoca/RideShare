using AdessoRideShare.Domain.Entities;
using AdessoRideShare.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
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
            var adminUser = new Boss
            {
                UserName = "test",
                Email = "test@gmail.com",
                Password = "Test123.",
                Role = Dtos.Enums.Role.Owner,
                CreatedTime = DateTime.Now,

            };

            context.Users.Add(adminUser);

            var testAdventurer = new Adventurer
            {
                UserName = "crazyMan",
                Email = "crazy@gmail.com",
                Password = "Test123.",
                Role = Dtos.Enums.Role.Adventurer,
                CreatedTime = DateTime.Now,

            };

            context.Users.Add(testAdventurer);

            context.Locations.AddRange(new List<Location> {

            new Location{  Name = "testOrigin"},
               new Location{  Name = "testDestination"}
            });

            await context.SaveChangesAsync();

            return;
        }
    }
}
