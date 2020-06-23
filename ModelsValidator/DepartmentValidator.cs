using System;
using System.Collections.Generic;
using System.Linq;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using FluentValidation;

namespace APIFuelStation.ModelsValidator {

    public class DepartmentValidator : AbstractValidator<Department> {

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentValidator (IDepartmentRepository departmentRepository) {
            _departmentRepository = departmentRepository;

            RuleFor (department => department.Name).NotNull ().WithMessage ("Please give department name");
            RuleFor (department => department.Code).Must (IsCodeUnique).WithMessage ("Code Already Exists, Please give a new code");
        }

        public bool IsCodeUnique (Department editedUser, string newValue) {
            var departmentSearchByCode = _departmentRepository.GetDepartmentByCode (newValue);
            if (departmentSearchByCode == null)
                return true;
            return false;
        }
    }
}