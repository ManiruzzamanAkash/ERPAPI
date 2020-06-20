using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentCommand, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.DeleteDepartment(request.Department);
        }
    }
}