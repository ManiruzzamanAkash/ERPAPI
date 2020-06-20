using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus.Queries
{
    public class GetAllDesignationHandler : MediatR.IRequestHandler<GetAllDesignationQuery, List<Designation>>
    {
        private IDesignationRepository designationRepository;

        public GetAllDesignationHandler(IDesignationRepository repository)
        {
            designationRepository = repository;
        }

        public Task<List<Designation>> Handle(GetAllDesignationQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return designationRepository.GetAllDesignations();
            });
        }
    }
}