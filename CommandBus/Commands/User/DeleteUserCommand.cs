using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class DeleteUserCommand : IRequest<User> {
        public DeleteUserCommand (User user) {
            User = user;
        }
        public User User { get; }
    }
}