using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee> {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler (IEmployeeRepository employeeRepository) {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle (CreateEmployeeCommand request, CancellationToken cancellationToken) {
            return await _employeeRepository.CreateEmployee (request.Employee);
        }
    }
}