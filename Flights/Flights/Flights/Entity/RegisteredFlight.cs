﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Flights.Entity
{
    public class RegisteredFlight
    {
        [Key]
        public int RegisteredFlightId { get; set; }      
        public Flight Flight { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public StatusFlight Status { get; set; }
        public DateTime DataOfBooking { get; set; }
    }
    public enum StatusFlight
    {
        BookingFlights,
        CanseledFlight
    }
    
}