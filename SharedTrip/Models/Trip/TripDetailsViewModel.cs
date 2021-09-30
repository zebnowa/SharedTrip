using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Models
{
    public class TripDetails : Trip
    {
        public string DepartureTimeFormatted => this.DepartureTime.ToString("s");
    }
}