using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaneSpotters.Api.Controllers
{
    /// <summary>
    /// AircraftController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private IConfiguration Configuration { get; }
        private readonly IAircraftService _aircraftService;
        public AircraftController(IAircraftService aircraftService, IConfiguration configuration)
        {
            _aircraftService = aircraftService;
            Configuration = configuration;
        }

        // GET: api/<AircraftController>
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Aircraft>> GetAsync()
        {
            return await _aircraftService.FetchAircraftsAsync();
        }

        // GET api/<AircraftController>/5
        [HttpGet("{id}")]
        public async Task<Aircraft> GetAsync(int id)
        {
            return await _aircraftService.FetchAircraftAsync(id);
        }

        // POST api/<AircraftController>
        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<Aircraft> PostAsync()
        {
            var file = Request.Form.Files[0];
            var folderName = Configuration["image_path"];
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Aircraft aircraft = new Aircraft()
                {
                    Id = Convert.ToInt32(Request.Form["Id"]),
                    Make = Convert.ToString(Request.Form["Make"]),
                    Model = Convert.ToString(Request.Form["Model"]),
                    Registration = Convert.ToString(Request.Form["Registration"]),
                    Image = fileName,
                    Sighting = Convert.ToBoolean(Request.Form["Sighting"]),
                };
                return await _aircraftService.CreateAircraft(aircraft);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<AircraftController>/5
        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<Aircraft> PostAsync(int id, [FromBody] Aircraft value)
        {
            return await _aircraftService.EditAircraftAsync(value, id);
        }

        // POST api/<AircraftController>/5
        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost("{id}"), DisableRequestSizeLimit]
        public async Task<Aircraft> PostAsync(int id)
        {
            var file = Request.Form.Files[0];
            var folderName = Configuration["image_path"];
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Aircraft aircraft = new Aircraft()
                {
                    Id = Convert.ToInt32(Request.Form["Id"]),
                    Make = Convert.ToString(Request.Form["Make"]),
                    Model = Convert.ToString(Request.Form["Model"]),
                    Registration = Convert.ToString(Request.Form["Registration"]),
                    Image = fileName,
                    Sighting = Convert.ToBoolean(Request.Form["Sighting"]),
                };
                return await _aircraftService.EditAircraftAsync(aircraft, id);
            }
            else
            {
                return null;
            }
        }

        // DELETE api/<AircraftController>/5
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IEnumerable<Aircraft>> DeleteAsync(int id)
        {
            if (await _aircraftService.DeleteAircraft(id))
            {
                return await _aircraftService.FetchAircraftsAsync();
            }
            return null;
        }
    }
}
