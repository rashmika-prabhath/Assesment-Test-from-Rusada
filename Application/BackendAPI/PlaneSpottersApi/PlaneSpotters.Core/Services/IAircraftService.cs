using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Services
{
    /// <summary>
    /// IAircraftService
    /// </summary>
    public interface IAircraftService
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
        /// Creates the aircraft.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <returns></returns>
        public Task<Aircraft> CreateAircraft(Aircraft aircraft);
        /// <summary>
        /// Edits the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<Aircraft> EditAircraftAsync(Aircraft aircraft, long Id);
        /// <summary>
        /// Deletes the aircraft.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAircraft(int Id);

        /// <summary>
        /// Fetches the aircraft spots asynchronous.
        /// </summary>
        /// <param name="AircraftId">The aircraft identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<AirCraftSpot>> FetchAircraftSpotsAsync(int AircraftId);
        /// <summary>
        /// Creates the aircraft spot asynchronous.
        /// </summary>
        /// <param name="aircraftSpot">The aircraft spot.</param>
        /// <returns></returns>
        public Task<AirCraftSpot> CreateAircraftSpotAsync(AirCraftSpot aircraftSpot);
        /// <summary>
        /// Deletes the aircraft spot.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAircraftSpot(int Id);
    }
}
