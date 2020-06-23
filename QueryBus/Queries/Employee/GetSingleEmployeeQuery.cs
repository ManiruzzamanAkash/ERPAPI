using System.Collections.Generic;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus.Queries {
    public class GetSingleEmployeeQuery : MediatR.IRequest<Employee> {
        public GetSingleEmployeeQuery (int id) {
            this.Id = id;
        }

        public int Id { get; }
    }
}