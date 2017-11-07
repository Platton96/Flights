using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flights.Concrete;
using Flights.Entity;

namespace Flights.DbProviders
{

    public class DbProvider
    {
        private ApplicationDbContext db;
        public DbProvider()
        {
            db = new ApplicationDbContext();
        }
        public Flight GetFlight (int flightId)
        {
            Flight flight = db.Flights.FirstOrDefault(fl => fl.FlightId == flightId);
            return flight;
        }
        public RegisteredFlight GetRigisteredFlight(int flightId, string userId)
        {
            RegisteredFlight registeredFlight = db.RegisteredFlights.FirstOrDefault(rFl => rFl.FlightId == flightId && rFl.UserId == userId);

            return registeredFlight;
        }
        public ApplicationUser GetUser(string userId)
        {
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == userId);
            return user;
        }
    }
}