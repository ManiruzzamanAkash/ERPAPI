using System;
using System.Collections.Generic;
using System.Linq;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using FluentValidation;

namespace APIFuelStation.ModelsValidator {

    public class EmployeeValidator : AbstractValidator<Employee> {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeValidator (IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;

            RuleFor (employee => employee.FirstName).NotNull ().WithMessage ("Please give your first name");
            RuleFor (employee => employee.LastName).NotNull ().WithMessage ("Please give your last name");
            RuleFor (employee => employee.PhoneNo).Length (11).WithMessage ("Please give your phone number of 11 digits");
            RuleFor (employee => employee.Email).NotNull ().EmailAddress ().WithMessage ("Please give your valid email address");
            RuleFor (employee => employee.Email).Must (IsEmailUnique).WithMessage ("Email already exists, Please give a new email address");
        }

        public bool IsEmailUnique (Employee editedEmployee, string newValue) {
            var employeeSearchByEmail = _employeeRepository.GetEmployeeByEmail (newValue);
            if (employeeSearchByEmail == null)
                return true;
            return false;
        }
    }
}