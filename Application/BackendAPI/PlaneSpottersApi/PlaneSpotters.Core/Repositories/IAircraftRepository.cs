using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Repositories
{
    /// <summary>
    /// IAircraftRepository
    /// </summary>
    public interface IAircraftRepository
    {
        /// <summary>
        /// Fetches the aircrafts asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Aircraft>> FetchAircraftsAsync();
        /// <summary>
        /// Fetches the aircraft asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<Aircraft> FetchAircraftAsync(int Id);
        /// <summary>
        /// Creates the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <returns></returns>
        public Task<Aircraft> CreateAircraftAsync(Aircraft aircraft);
        /// <summary>
        /// Edits the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<Aircraft> EditAircraftAsync(Aircraft aircraft, long Id);
        /// <summary>
        /// Deletes the aircraft asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAircraftAsync(int Id);
        /// <summary>
        /// Creates the aircraft spot asynchronous.
        /// </summary>
        /// <param name="aircraftSpot">The aircraft spot.</param>
        /// <returns></returns>
        public Task<AirCraftSpot> CreateAircraftSpotAsync(AirCraftSpot aircraftSpot);
        /// <summary>
        /// Deletes the aircraft spot asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAircraftSpotAsync(int id);
        /// <summary>
        /// Fetches the aircraft spots asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AirCraftSpot>> FetchAircraftSpotsAsync();
    }
}
