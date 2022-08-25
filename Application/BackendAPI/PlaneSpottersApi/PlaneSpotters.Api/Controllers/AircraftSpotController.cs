using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IEnumerable<AirCraftSpot>> GetAsync(int id)
        {
            return await _aircraftService.FetchAircraftSpotsAsync(id);
        }

        // POST api/<AircraftSpotController>
        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AirCraftSpot> PostAsync([FromBody] AirCraftSpot value)
        {
            return await _aircraftService.CreateAircraftSpotAsync(value);
        }

        // DELETE api/<AircraftSpotController>/5
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _aircraftService.DeleteAircraftSpot(id);
        }
    }
}
