using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Models
{
    /// <summary>
    /// AircraftContext
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class AircraftContext : DbContext
    {
        public AircraftContext(DbContextOptions options)
            : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the aircrafts.
        /// </summary>
        /// <value>
        /// The aircrafts.
        /// </value>
        public DbSet<Aircraft> Aircrafts { get; set; }
        /// <summary>
        /// Gets or sets the air craft spots.
        /// </summary>
        /// <value>
        /// The air craft spots.
        /// </value>
        public DbSet<AirCraftSpot> AirCraftSpots { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// <para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
        /// </para>
        /// </remarks>
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
