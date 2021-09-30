using SharedTrip.Data.Models;

namespace SharedTrip.Services
{
    using SharedTrip.Models.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using static DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UsernameMinLength} and {UsernameMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < PasswordMinLegth || model.Password.Length > PasswordMaxLegth)
            {
                errors.Add($"The provided password is not valid. It must be between {PasswordMinLegth} and {PasswordMaxLegth} characters long.");
            }
            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespace.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            

            return errors;
        }
    }
}
