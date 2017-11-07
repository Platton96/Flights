using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flights.Entity;

namespace Flights.Utils
{
    public static class DiscountUtil
    {

        public static double CalculateCoeffForDiscountDependOnDistance(Flight flight)
        {
            double cofficientForDiscount = 0;
            int tempVarForCalculeteCoeff = flight.Destance / 10000;

            if (tempVarForCalculeteCoeff >= 15)
            {
                cofficientForDiscount = 0.15;
            }
            else
            {
                cofficientForDiscount = tempVarForCalculeteCoeff / 100.0;
            }

            return cofficientForDiscount;
        }
        public static double CalculateCoeffForDiscountDependOnBookinge(Flight flight, RegisteredFlight registeredFlight)
        {
            if (registeredFlight == null)
            {
                return 0;
            }

            double coffForDiscount = 0;
            DateTime dateFlight = flight.DateFlight;
            DateTime dateBookingFlight = registeredFlight.DataOfBooking;
            if (dateBookingFlight.AddDays(30) < dateFlight)
            {
                coffForDiscount = 0.05;
            }
            else
            {
                coffForDiscount = 0;
            }
            return coffForDiscount;
        }
        public static double CalculateCoeffForDiscountDepentOfStatusUser(string role)
        {
            switch (role)
            {
                case "normalUser": return 0;
                case "frequentClient": return 0.5;
                case "vip": return 0.15;
                default: return 0;
            }
            
        }

    }
    
}
