using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaneSpotters.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftSpotController : ControllerBase
    {
        private IConfiguration Configuration { get; }
        private readonly IAircraftService _aircraftService;
        public AircraftSpotController(IAircraftService aircraftService, IConfiguration configuration)
        {
            _aircraftService = aircraftService;
            Configuration = configuration;
        }

        // GET api/<AircraftSpotController>/5
        [HttpGet("{id}")]
        public IEnumerable<AirCraftSpot> Get(int id)
        {
            return _aircraftService.FetchAircraftSpots(id);
        }

        // POST api/<AircraftSpotController>
        [HttpPost]
        public AirCraftSpot Post([FromBody] AirCraftSpot value)
        {
            return _aircraftService.CreateAircraftSpot(value);
        }

        // DELETE api/<AircraftSpotController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _aircraftService.DeleteAircraftSpot(id);
        }
    }
}
