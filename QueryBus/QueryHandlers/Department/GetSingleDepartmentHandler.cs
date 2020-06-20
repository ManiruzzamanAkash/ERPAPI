using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.QueryBus.Queries
{
    public class GetSingleDepartmentHandler : MediatR.IRequestHandler<GetSingleDepartmentQuery, Department>
    {
        private IDepartmentRepository departmentRepository;

        public GetSingleDepartmentHandler(IDepartmentRepository repository)
        {
            departmentRepository = repository;
        }

        public Task<Department> Handle(GetSingleDepartmentQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var department = departmentRepository.GetDepartmentById(request.Id);
                if (department != null)
                {
                    return department;
                };
                return null;
            });
        }
    }
}