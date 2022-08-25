using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaneSpotters.Core.Services
{
    /// <summary>
    /// AircraftService
    /// </summary>
    /// <seealso cref="PlaneSpotters.Core.Services.IAircraftService" />
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;
        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }
        /// <summary>
        /// Creates the aircraft.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <returns></returns>
        public async Task<Aircraft> CreateAircraft(Aircraft aircraft)
        {
            return (Aircraft)await _aircraftRepository.CreateAircraftAsync(aircraft);
        }

        /// <summary>
        /// Creates the aircraft spot asynchronous.
        /// </summary>
        /// <param name="aircraftSpot">The aircraft spot.</param>
        /// <returns></returns>
        public async Task<AirCraftSpot> CreateAircraftSpotAsync(AirCraftSpot aircraftSpot)
        {
            return (AirCraftSpot)await _aircraftRepository.CreateAircraftSpotAsync(aircraftSpot);
        }

        /// <summary>
        /// Deletes the aircraft.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAircraft(int Id)
        {
            return await (_aircraftRepository.DeleteAircraftAsync(Id));
        }

        /// <summary>
        /// Deletes the aircraft spot.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAircraftSpot(int Id)
        {
            return await (_aircraftRepository.DeleteAircraftSpotAsync(Id));
        }

        /// <summary>
        /// Edits the aircraft asynchronous.
        /// </summary>
        /// <param name="aircraft">The aircraft.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<Aircraft> EditAircraftAsync(Aircraft aircraft, long Id)
        {
            return (Aircraft)await _aircraftRepository.EditAircraftAsync(aircraft, Id);
        }

        /// <summary>
        /// Fetches the aircraft asynchronous.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public async Task<Aircraft> FetchAircraftAsync(int Id)
        {
            return await _aircraftRepository.FetchAircraftAsync(Id);
        }

        /// <summary>
        /// Fetches the aircrafts asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Aircraft>> FetchAircraftsAsync()
        {
            return await _aircraftRepository.FetchAircraftsAsync();
        }

        /// <summary>
        /// Fetches the aircraft spots asynchronous.
        /// </summary>
        /// <param name="AircraftId">The aircraft identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<AirCraftSpot>> FetchAircraftSpotsAsync(int AircraftId)
        {
            return await _aircraftRepository.FetchAircraftSpotsAsync();
        }
    }
}
