using System.Collections.Generic;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus
{
    public class GetSingleDesignationQuery : MediatR.IRequest<Designation>
    {
        public GetSingleDesignationQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}