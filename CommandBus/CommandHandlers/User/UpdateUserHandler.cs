using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User> {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler (IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle (UpdateUserCommand request, CancellationToken cancellationToken) {
            return await _userRepository.UpdateUser (request.User);
        }
    }
}