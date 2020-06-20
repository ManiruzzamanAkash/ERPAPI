using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.UpdateDepartment(request.Department);
        }
    }
}