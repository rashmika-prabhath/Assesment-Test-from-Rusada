using Microsoft.EntityFrameworkCore;
using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Repositories
{
    /// <summary>
    /// AircraftRepository
    /// </summary>
    /// <seealso cref="PlaneSpotters.Core.Repositories.IDataRepository&lt;PlaneSpotters.Core.Models.Aircraft&gt;" />
    /// <seealso cref="PlaneSpotters.Core.Repositories.IAircraftRepository" />
    public class AircraftRepository : IDataRepository<Aircraft>, IAircraftRepository
    {
        readonly AircraftContext aircraftContext;
        public AircraftRepository(AircraftContext context)
        {
            aircraftContext = context;
        }

        /// <summary>
        /// Creates the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <returns></returns>
        public async Task<Aircraft> CreateAircraftAsync(Aircraft aircraft)
        {
            return await this.AddAsync(aircraft);
        }

        /// <summary>
        /// Deletes the aircraft asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAircraftAsync(int Id)
        {
            return await this.DeleteAsync(Id);
        }

        /// <summary>
        /// Edits the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<Aircraft> EditAircraftAsync(Aircraft aircraft, long Id)
        {
            return await this.UpdateAsync(await this.GetAsync(Id),aircraft);
        }

        /// <summary>
        /// Fetches the aircraft asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<Aircraft> FetchAircraftAsync(int Id)
        {
            return await this.GetAsync(Id);
        }

        /// <summary>
        /// Fetches the aircrafts asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Aircraft>> FetchAircraftsAsync()
        {
            return await this.GetAllAsync();
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Aircraft> GetAsync(long id)
        {
            return await aircraftContext.Aircrafts
                  .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Gets the spot asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<AirCraftSpot> GetSpotAsync(long id)
        {
            return await aircraftContext.AirCraftSpots
                  .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Aircraft>> GetAllAsync()
        {
           return await aircraftContext.Aircrafts.Include(a => a.AirCraftSpots).ToListAsync();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Aircraft> AddAsync(Aircraft entity)
        {
            aircraftContext.Aircrafts.Add(entity);
            await aircraftContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Adds the spot asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<AirCraftSpot> AddSpotAsync(AirCraftSpot entity)
        {
            aircraftContext.AirCraftSpots.Add(entity);
            await aircraftContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="dbEntity">The database entity.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Aircraft> UpdateAsync(Aircraft dbEntity, Aircraft entity)
        {
            dbEntity.Make = entity.Make;
            dbEntity.Model = entity.Model;
            dbEntity.Registration = entity.Registration;
            dbEntity.Image = entity.Image;
            dbEntity.Sighting = entity.Sighting;
            aircraftContext.Update(dbEntity);
            await aircraftContext.SaveChangesAsync();
            return await aircraftContext.Aircrafts.FirstOrDefaultAsync(e => e.Id == entity.Id);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(long id)
        {
            aircraftContext.Aircrafts.Remove(await this.GetAsync(id));
            await aircraftContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Creates the aircraft spot asynchronous.
        /// </summary>
        /// <param name="aircraftSpot">The aircraft spot.</param>
        /// <returns></returns>
        public async Task<AirCraftSpot> CreateAircraftSpotAsync(AirCraftSpot aircraftSpot)
        {
            return await this.AddSpotAsync(aircraftSpot);
        }

        /// <summary>
        /// Deletes the aircraft spot asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAircraftSpotAsync(int id)
        {
            aircraftContext.AirCraftSpots.Remove(await this.GetSpotAsync(id));
            await aircraftContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Fetches the aircraft spots asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AirCraftSpot>> FetchAircraftSpotsAsync()
        {
            return await aircraftContext.AirCraftSpots.Include(a => a.Aircraft).ToListAsync();
        }
    }
}
