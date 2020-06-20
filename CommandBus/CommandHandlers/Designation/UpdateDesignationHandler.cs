using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class UpdateDesignationHandler : IRequestHandler<UpdateDesignationCommand, Designation>
    {
        private readonly IDesignationRepository _designationRepository;
        public UpdateDesignationHandler(IDesignationRepository designationRepository)
        {
            this._designationRepository = designationRepository;
        }

        public async Task<Designation> Handle(UpdateDesignationCommand request, CancellationToken cancellationToken)
        {
            return await _designationRepository.UpdateDesignation(request.Designation);
        }
    }
}