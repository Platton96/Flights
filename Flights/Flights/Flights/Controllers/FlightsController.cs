using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Flights.Concrete;
using Flights.Entity;
using Flights.DbProviders;

namespace Flights.Controllers
{
    public class FlightsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DbProvider dbProvider;

        public FlightsController()
        {
            dbProvider = new DbProvider();
        }

        // GET: api/Flights
        public Flight GetFlights()
        { 
            return this.dbProvider.GetFlight(1);
        }


        // GET: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult GetFlight(int id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // PUT: api/Flights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlight(int id, Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.FlightId)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Flights
        [ResponseType(typeof(Flight))]
        public IHttpActionResult PostFlight(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flights.Add(flight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flight.FlightId }, flight);
        }

        // DELETE: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult DeleteFlight(int id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            db.SaveChanges();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(int id)
        {
            return db.Flights.Count(e => e.FlightId == id) > 0;
        }
    }
}