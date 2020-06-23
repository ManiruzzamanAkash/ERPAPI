using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class CreateEmployeeCommand : IRequest<Employee> {
        public CreateEmployeeCommand (Employee employee) {
            Employee = employee;
        }
        public Employee Employee { get; }
    }
}