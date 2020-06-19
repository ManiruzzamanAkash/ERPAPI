using APIFuelStation.Models;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class CreateUserCommand : IRequest<User> {
        public CreateUserCommand (User user) {
            User = user;
        }
        public User User { get; }
    }
}