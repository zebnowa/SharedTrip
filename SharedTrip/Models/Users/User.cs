using SharedTrip.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SharedTrip.Models
{
    using static DataConstants;
    public class User
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(PasswordMinLegth)]
        public string Password { get; set; }

        public IEnumerable<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}

