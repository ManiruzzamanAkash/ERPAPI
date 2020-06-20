using APIFuelStation.ViewModel;
using MediatR;

namespace APIFuelStation.CommandBus.Commands {
    public class UserAuthCommand : IRequest<TokenViewModel> {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}