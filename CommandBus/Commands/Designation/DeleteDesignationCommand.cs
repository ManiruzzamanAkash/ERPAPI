using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands
{
    public class DeleteDesignationCommand : IRequest<Designation>
    {
        public DeleteDesignationCommand(Designation designation)
        {
            Designation = designation;
        }
        public Designation Designation { get; }
    }
}