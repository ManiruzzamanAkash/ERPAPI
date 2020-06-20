using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class CreateDepartmentCommand : IRequest<Department>
    {
        public CreateDepartmentCommand(Department department)
        {
            Department = department;
        }
        public Department Department { get; }
    }
}