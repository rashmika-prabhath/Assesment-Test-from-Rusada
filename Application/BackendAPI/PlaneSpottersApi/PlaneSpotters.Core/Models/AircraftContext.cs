using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Models
{
    public class AircraftContext : DbContext
    {
        public AircraftContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AirCraftSpot> AirCraftSpots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>()
                .HasMany(c => c.AirCraftSpots)
                .WithOne(e => e.Aircraft)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aircraft>()
                .HasData(new Aircraft()
                {
                    Id = 1,
                    Make = "Boeing",
                    Model = "777-300ER",
                    Registration = "G-RNAC",
                    Image = null,
                    Sighting = true
                });

            modelBuilder.Entity<AirCraftSpot>()
                .HasData(new AirCraftSpot()
                {
                    Id = 1,
                    Location = "London Gatwick",
                    DateTime = new DateTime(2019, 09, 23, 10, 30, 00),
                    AircraftId = 1
                });
        }
    }
}
