using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, User> {
        private readonly IUserRepository _userRepository;
        public UserRegisterCommandHandler (IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle (UserRegisterCommand request, CancellationToken cancellationToken) {
            return await _userRepository.CreateUser (request.User);
        }
    }
}