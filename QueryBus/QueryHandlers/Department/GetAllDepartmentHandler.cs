using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus.Queries
{
    public class GetAllDepartmentHandler : MediatR.IRequestHandler<GetAllDepartmentQuery, List<Department>>
    {
        private IDepartmentRepository departmentRepository;

        public GetAllDepartmentHandler(IDepartmentRepository repository)
        {
            departmentRepository = repository;
        }

        public Task<List<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return departmentRepository.GetAllDepartments();
            });
        }
    }
}