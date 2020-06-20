using APIFuelStation.Models;
using APIFuelStation.ViewModel;
using MediatR;

namespace APIFuelStation.CommandBus {
    public class UserRegisterCommand : IRequest<User> {
        public User User { get; }

        public UserRegisterCommand (User user) {
            User = user;
        }
    }
}