using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.QueryBus.Queries {
    public class GetSingleUserHandler : MediatR.IRequestHandler<GetSingleUserQuery, User> {
        private IUserRepository userRepository;

        public GetSingleUserHandler (IUserRepository repository) {
            userRepository = repository;
        }

        public Task<User> Handle (GetSingleUserQuery request, CancellationToken cancellationToken) {
            return Task.Run (() => {
                var user = userRepository.GetUserById (request.Id);
                if (user != null) {
                    return user;
                };
                return null;
            });
        }
    }
}