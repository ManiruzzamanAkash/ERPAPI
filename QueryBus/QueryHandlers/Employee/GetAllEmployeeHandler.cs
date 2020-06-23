using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus.Queries {
    public class GetAllEmployeeHandler : MediatR.IRequestHandler<GetAllEmployeeQuery, List<Employee>> {
        private IEmployeeRepository employeeRepository;

        public GetAllEmployeeHandler (IEmployeeRepository repository) {
            employeeRepository = repository;
        }

        public Task<List<Employee>> Handle (GetAllEmployeeQuery request, CancellationToken cancellationToken) {
            return Task.Run (() => {
                return employeeRepository.GetAllEmployees ();
            });
        }
    }
}