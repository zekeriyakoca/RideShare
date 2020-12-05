using AdessoRideShare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShare.Infrastructure.EntityFramework.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Adventurer> Customer { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Journey>()
            .HasOne(c => c.Boss)
            .WithMany(a=>a.Journeys)
            .OnDelete(DeleteBehavior.Restrict);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
        }
    }
}
