using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class UpdateDesignationCommand : IRequest<Designation>
    {
        public UpdateDesignationCommand(Designation designation)
        {
            Designation = designation;
        }
        public Designation Designation { get; }
    }
}