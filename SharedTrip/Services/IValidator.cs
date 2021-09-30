﻿namespace SharedTrip.Services
{
    using SharedTrip.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        //ICollection<string> ValidateCar(AddCarFormModel model);
    }
}
