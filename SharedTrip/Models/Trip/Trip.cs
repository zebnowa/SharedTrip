using SharedTrip.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    using static DataConstants;
    public class Trip
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; init; } = DateTime.UtcNow;

        [Required]
        [MinLength(SeatsMinValue)]
        [MaxLength(SeatsMaxValue)]
        public int Seats { get; set; }
        
        [Required]
        [MaxLength(DescriptionMaxValue)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<UserTrip> UserTrips { get; init; } = new List<UserTrip>();

    }
}
