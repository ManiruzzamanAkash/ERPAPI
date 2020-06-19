using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories {
    public interface IUserRepository {

        List<User> GetAllUsers ();
        User GetUserById (int id);
        User GetUserByEmail (string email);
        User GetUserByUserName (string userName);
        User GetUserByPhoneNo (string phoneNo);
        Task<User> CreateUser (User user);
        Task<User> UpdateUser (User user);
        Task<User> DeleteUser (User user);

    }
}