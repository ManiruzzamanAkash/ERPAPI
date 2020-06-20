using System.Collections.Generic;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus
{
    public class GetSingleDepartmentQuery : MediatR.IRequest<Department>
    {
        public GetSingleDepartmentQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}