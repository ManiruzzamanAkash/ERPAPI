using System;
using System.Collections.Generic;
using System.Linq;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using FluentValidation;

namespace APIFuelStation.ModelsValidator
{

    public class UserValidator : AbstractValidator<User>
    {

        private readonly IUserRepository _userRepository;
        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.FirstName).NotNull().WithMessage("Please give your first name");
            RuleFor(user => user.LastName).NotNull().WithMessage("Please give your last name");
            RuleFor(user => user.PhoneNo).Length(11).WithMessage("Please give your phone number of 11 digits");
            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Please give your password at least 8 characters");
            RuleFor(user => user.Email).NotNull().EmailAddress().WithMessage("Please give your valid email address");
            RuleFor(user => user.Email).Must(IsEmailUnique).WithMessage("Email already exists, Please give a new email address");
        }

        public bool IsEmailUnique(User editedUser, string newValue)
        {
            var userSearchByEmail = _userRepository.GetUserByEmail(newValue);
            if (userSearchByEmail == null)
                return true;
            return false;
        }
    }
}