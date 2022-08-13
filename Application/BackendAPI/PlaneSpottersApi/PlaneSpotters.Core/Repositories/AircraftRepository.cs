using PlaneSpotters.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaneSpotters.Core.Repositories
{
    public class AircraftRepository : IDataRepository<Aircraft>, IAircraftRepository
    {
        readonly AircraftContext aircraftContext;
        public AircraftRepository(AircraftContext context)
        {
            aircraftContext = context;
        }

        public Aircraft CreateAircraft(Aircraft aircraft)
        {
            return this.Add(aircraft);
        }

        public bool DeleteAircraft(int Id)
        {
            return this.Delete(Id);
        }

        public Aircraft EditAircraft(Aircraft aircraft, long Id)
        {
            return this.Update(this.Get(Id),aircraft);
        }

        public Aircraft FetchAircraft(int Id)
        {
            return this.Get(Id);
        }

        public IEnumerable<Aircraft> FetchAircrafts()
        {
            return this.GetAll();
        }

        public Aircraft Get(long id)
        {
            return aircraftContext.Aircrafts
                  .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Aircraft> GetAll()
        {
           return aircraftContext.Aircrafts.ToList();
        }

        public Aircraft Add(Aircraft entity)
        {
            aircraftContext.Aircrafts.Add(entity);
            aircraftContext.SaveChanges();
            return entity;
        }

        public Aircraft Update(Aircraft dbEntity, Aircraft entity)
        {
            dbEntity.Make = entity.Make;
            dbEntity.Model = entity.Model;
            dbEntity.Registration = entity.Registration;
            dbEntity.Location = entity.Location;
            dbEntity.DateTime = entity.DateTime;
            dbEntity.Image = entity.Image;
            dbEntity.Sighting = entity.Sighting;
            aircraftContext.SaveChanges();
            return aircraftContext.Aircrafts.FirstOrDefault(e => e.Id == entity.Id);
        }

        public bool Delete(long id)
        {
            aircraftContext.Aircrafts.Remove(this.Get(id));
            aircraftContext.SaveChanges();
            return true;
        }
    }
}
