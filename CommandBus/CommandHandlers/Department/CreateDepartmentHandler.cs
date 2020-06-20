using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.CreateDepartment(request.Department);
        }
    }
}