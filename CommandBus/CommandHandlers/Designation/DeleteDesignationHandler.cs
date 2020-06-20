using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class DeleteDesignationHandler : IRequestHandler<DeleteDesignationCommand, Designation>
    {
        private readonly IDesignationRepository _designationRepository;
        public DeleteDesignationHandler(IDesignationRepository designationRepository)
        {
            this._designationRepository = designationRepository;
        }

        public async Task<Designation> Handle(DeleteDesignationCommand request, CancellationToken cancellationToken)
        {
            return await _designationRepository.DeleteDesignation(request.Designation);
        }
    }
}