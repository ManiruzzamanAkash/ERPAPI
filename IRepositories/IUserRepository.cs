using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories {
    public interface IUserRepository {

        List<User> GetAllUsers ();
        User GetUserById (int id);
        Task<User> CreateUser (User user);
        Task<User> UpdateUser (User user);
        Task<User> DeleteUser (User user);

    }
}