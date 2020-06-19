using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User> {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler (IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle (CreateUserCommand request, CancellationToken cancellationToken) {
            return await _userRepository.CreateUser (request.User);
        }
    }
}