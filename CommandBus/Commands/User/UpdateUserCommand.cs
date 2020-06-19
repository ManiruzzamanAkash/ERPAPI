using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class UpdateUserCommand : IRequest<User> {
        public UpdateUserCommand (User user) {
            User = user;
        }
        public User User { get; }
    }
}