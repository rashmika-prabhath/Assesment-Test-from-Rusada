using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneSpotters.Core.Services
{
    public interface IAircraftService
    {
        public IEnumerable<Aircraft> FetchAircrafts();
        public Aircraft FetchAircraft(int Id);
        public Aircraft CreateAircraft(Aircraft aircraft);
        public Aircraft EditAircraft(Aircraft aircraft, long Id);
        public bool DeleteAircraft(int Id);



        public IEnumerable<AirCraftSpot> FetchAircraftSpots(int AircraftId);
        public AirCraftSpot CreateAircraftSpot(AirCraftSpot aircraftSpot);
        public bool DeleteAircraftSpot(int Id);
    }
}
