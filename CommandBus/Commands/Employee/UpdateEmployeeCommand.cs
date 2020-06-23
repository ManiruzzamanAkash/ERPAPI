using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class UpdateEmployeeCommand : IRequest<Employee> {
        public UpdateEmployeeCommand (Employee employee) {
            Employee = employee;
        }
        public Employee Employee { get; }
    }
}