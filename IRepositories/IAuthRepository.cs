using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories {
    public interface IAuthRepository {
        bool SaveChanges ();

        Task<User> Register (User user);
        Task<User> Login (User user);
    }
}