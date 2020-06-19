using System.Collections.Generic;
using APIFuelStation.Models;

namespace APIFuelStation.QueryBus.Queries {
    public class GetSingleUserQuery : MediatR.IRequest<User> {
        public GetSingleUserQuery (int id) {
            this.Id = id;
        }

        public int Id { get; }
    }
}