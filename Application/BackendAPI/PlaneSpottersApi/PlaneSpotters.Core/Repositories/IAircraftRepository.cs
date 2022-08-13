using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneSpotters.Core.Repositories
{
    public interface IAircraftRepository
    {
        public IEnumerable<Aircraft> FetchAircrafts();
        public Aircraft FetchAircraft(int Id);
        public Aircraft CreateAircraft(Aircraft aircraft);
        public Aircraft EditAircraft(Aircraft aircraft, long Id);
        public bool DeleteAircraft(int Id);
    }
}
