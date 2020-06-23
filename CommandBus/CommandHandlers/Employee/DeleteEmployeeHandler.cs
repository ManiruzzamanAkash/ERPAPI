using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Employee> {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeHandler (IEmployeeRepository employeeRepository) {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle (DeleteEmployeeCommand request, CancellationToken cancellationToken) {
            return await _employeeRepository.DeleteEmployee (request.Employee);
        }
    }
}