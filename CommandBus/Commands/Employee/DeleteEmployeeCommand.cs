using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class DeleteEmployeeCommand : IRequest<Employee> {
        public DeleteEmployeeCommand (Employee employee) {
            Employee = employee;
        }
        public Employee Employee { get; }
    }
}