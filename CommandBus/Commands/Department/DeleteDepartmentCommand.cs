using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class DeleteDepartmentCommand : IRequest<Department>
    {
        public DeleteDepartmentCommand(Department department)
        {
            Department = department;
        }
        public Department Department { get; }
    }
}