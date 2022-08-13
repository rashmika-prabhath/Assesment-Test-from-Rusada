using Microsoft.AspNetCore.Mvc;
using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaneSpotters.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;
        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }
        // GET: api/<AircraftController>
        [HttpGet]
        public IEnumerable<Aircraft> Get()
        {
            return _aircraftService.FetchAircrafts();
        }

        // GET api/<AircraftController>/5
        [HttpGet("{id}")]
        public Aircraft Get(int id)
        {
            return _aircraftService.FetchAircraft(id);
        }

        // POST api/<AircraftController>
        [HttpPost]
        public Aircraft Post([FromBody] Aircraft value)
        {
            return _aircraftService.CreateAircraft(value);
        }

        // PUT api/<AircraftController>/5
        [HttpPut("{id}")]
        public Aircraft Put(int id, [FromBody] Aircraft value)
        {
            return _aircraftService.EditAircraft(value, id);
        }

        // DELETE api/<AircraftController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _aircraftService.DeleteAircraft(id);
        }
    }
}
