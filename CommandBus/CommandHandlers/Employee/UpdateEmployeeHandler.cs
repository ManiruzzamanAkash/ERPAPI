using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee> {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeHandler (IEmployeeRepository employeeRepository) {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle (UpdateEmployeeCommand request, CancellationToken cancellationToken) {
            return await _employeeRepository.UpdateEmployee (request.Employee);
        }
    }
}