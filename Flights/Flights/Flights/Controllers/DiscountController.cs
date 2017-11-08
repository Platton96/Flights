using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Host.SystemWeb;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Flights.Entity;
using Flights.Concrete;
using Flights.DbProviders;
using Flights.Utils;

namespace Flights.Controllers
{
    public class DiscountController : ApiController
    {
        // private ApplicationDbContext db;
        private DbProvider dbProvider;
        private ApplicationUserManager userManager;
        private ApplicationUser user;

        public DiscountController()
        {
            dbProvider = new DbProvider();
            userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            user = userManager.FindByEmail("q@mail.ru");
        }

        public decimal Get(int flighsId)
        {
            Flight flight = dbProvider.GetFlight(flighsId);
            RegisteredFlight registeredFlight = dbProvider.GetRigisteredFlight(flighsId, user.Id);

            return DiscountUtil.GetPriceWithDiscount(flight, registeredFlight, user.statusUser);
           
        }
    }
}
