using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.QueryBus.Queries {
    public class GetSingleEmployeeHandler : MediatR.IRequestHandler<GetSingleEmployeeQuery, Employee> {
        private IEmployeeRepository employeeRepository;

        public GetSingleEmployeeHandler (IEmployeeRepository repository) {
            employeeRepository = repository;
        }

        public Task<Employee> Handle (GetSingleEmployeeQuery request, CancellationToken cancellationToken) {
            return Task.Run (() => {
                var employee = employeeRepository.GetEmployeeById (request.Id);
                if (employee != null) {
                    return employee;
                };
                return null;
            });
        }
    }
}