using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneSpotters.Core.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;
        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }
        public Aircraft CreateAircraft(Aircraft aircraft)
        {
            return (Aircraft)_aircraftRepository.CreateAircraft(aircraft);
        }

        public AirCraftSpot CreateAircraftSpot(AirCraftSpot aircraftSpot)
        {
            return (AirCraftSpot)_aircraftRepository.CreateAircraftSpot(aircraftSpot);
        }

        public bool DeleteAircraft(int Id)
        {
            return (_aircraftRepository.DeleteAircraft(Id));
        }

        public bool DeleteAircraftSpot(int Id)
        {
            return (_aircraftRepository.DeleteAircraftSpot(Id));
        }

        public Aircraft EditAircraft(Aircraft aircraft, long Id)
        {
            return (Aircraft)_aircraftRepository.EditAircraft(aircraft, Id);
        }

        public Aircraft FetchAircraft(int Id)
        {
            return _aircraftRepository.FetchAircraft(Id);
        }

        public IEnumerable<Aircraft> FetchAircrafts()
        {
            return _aircraftRepository.FetchAircrafts();
        }

        public IEnumerable<AirCraftSpot> FetchAircraftSpots(int AircraftId)
        {
            return _aircraftRepository.FetchAircraftSpots();
        }
    }
}
