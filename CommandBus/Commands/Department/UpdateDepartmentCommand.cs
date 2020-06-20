using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class UpdateDepartmentCommand : IRequest<Department>
    {
        public UpdateDepartmentCommand(Department department)
        {
            Department = department;
        }
        public Department Department { get; }
    }
}