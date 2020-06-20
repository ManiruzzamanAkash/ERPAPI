using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.QueryBus.Queries
{
    public class GetSingleDesignationHandler : MediatR.IRequestHandler<GetSingleDesignationQuery, Designation>
    {
        private IDesignationRepository designationRepository;

        public GetSingleDesignationHandler(IDesignationRepository repository)
        {
            designationRepository = repository;
        }

        public Task<Designation> Handle(GetSingleDesignationQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var designation = designationRepository.GetDesignationById(request.Id);
                if (designation != null)
                {
                    return designation;
                };
                return null;
            });
        }
    }
}