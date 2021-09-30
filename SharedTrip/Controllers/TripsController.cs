using SharedTrip.Data;
using SharedTrip.Services;
using SharedTrip.Models;
using System;
using System.Globalization;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace SharedTrip.Controllers
{

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ITripsService tripsService;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ITripsService tripService,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.tripsService = tripsService;
            this.data = data;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.data.Trips.All(); //this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetTripById(tripId);
            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available.");
            }

            var userId = this.User.Id;
            if (this.tripsService.IsUserAlreadyInThisTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

    }
}