using SharedTrip.Models;
using System;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<Trip> GetAll();

        string CreateTrip(AddTripInputModel inputModel);

        void AddUserToTrip(string tripId, string userId);

        TripDetails GetTripById(string tripId);

        bool HasAvailableSeats(string tripId);

        bool IsUserAlreadyInThisTrip(string userId, string tripId);
    }
}