using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class CreateDesignationCommand : IRequest<Designation>
    {
        public CreateDesignationCommand(Designation designation)
        {
            Designation = designation;
        }
        public Designation Designation { get; }
    }
}