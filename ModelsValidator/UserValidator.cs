using APIFuelStation.Models;
using FluentValidation;

namespace APIFuelStation.ModelsValidator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().WithMessage("Please give your first name");
            RuleFor(user => user.LastName).NotNull().WithMessage("Please give your last name");
            RuleFor(user => user.PhoneNo).Length(11).WithMessage("Please give your phone number of 11 digits");
            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Please give your password at least 8 characters");
            RuleFor(user => user.Email).NotNull().EmailAddress().WithMessage("Please give your valid email address");
        }
    }
}