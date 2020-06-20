using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus
{

    public class CreateDesignationHandler : IRequestHandler<CreateDesignationCommand, Designation>
    {
        private readonly IDesignationRepository _designationRepository;
        public CreateDesignationHandler(IDesignationRepository designationRepository)
        {
            this._designationRepository = designationRepository;
        }

        public async Task<Designation> Handle(CreateDesignationCommand request, CancellationToken cancellationToken)
        {
            return await _designationRepository.CreateDesignation(request.Designation);
        }
    }
}