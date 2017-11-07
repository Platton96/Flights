using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flights.Entity
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string DepartureSity { get; set; }
        public string SityOfEntry { get; set; }
        public DateTime DateFlight { get; set; }
        public int Destance { get; set; }
        public decimal Price { get; set; }
        public ICollection<RegisteredFlight> RegisteredFlights { get; set; }
        
    }
}
