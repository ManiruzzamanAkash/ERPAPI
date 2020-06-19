using System.Threading;
using System.Threading.Tasks;
using APIFuelStation.CommandBus.Commands;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus {

    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User> {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler (IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle (DeleteUserCommand request, CancellationToken cancellationToken) {
            return await _userRepository.DeleteUser (request.User);
        }
    }
}