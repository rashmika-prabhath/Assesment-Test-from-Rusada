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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().HasData(new Aircraft
            {
                Id = 1,
                Make = "Boeing",
                Model = "777-300ER",
                Registration = "G-RNAC",
                Location = "London Gatwick",
                DateTime = new DateTime(2019, 09, 23, 10, 30, 00),
                Sighting = true
            });
        }
    }
}
