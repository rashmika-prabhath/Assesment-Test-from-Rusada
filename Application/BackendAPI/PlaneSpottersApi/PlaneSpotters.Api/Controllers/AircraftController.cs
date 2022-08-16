using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaneSpotters.Core.Models;
using PlaneSpotters.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaneSpotters.Api.Controllers
{
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
        [HttpPost, DisableRequestSizeLimit]
        public Aircraft Post()
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
                return _aircraftService.CreateAircraft(aircraft);
            }
            else
            {
                return null;
            }
        }

        // PUT api/<AircraftController>/5
        [HttpPut("{id}")]
        public Aircraft Post(int id, [FromBody] Aircraft value)
        {
            return _aircraftService.EditAircraft(value, id);
        }

        // POST api/<AircraftController>/5
        [HttpPost("{id}"), DisableRequestSizeLimit]
        public Aircraft Post(int id)
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
                return _aircraftService.EditAircraft(aircraft, id);
            }
            else
            {
                return null;
            }
        }

        // DELETE api/<AircraftController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Aircraft> Delete(int id)
        {
            if (_aircraftService.DeleteAircraft(id))
            {
                return _aircraftService.FetchAircrafts();
            }
            return null;
        }
    }
}
