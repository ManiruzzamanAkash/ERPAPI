using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFuelStation.DbContexts;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;

namespace APIFuelStation.Repositories {
    public class UserRepository : IUserRepository {
        private readonly FuelDBContext _context;

        public UserRepository (FuelDBContext context) {
            this._context = context;
        }

        public async Task<User> CreateUser (User user) {
            _context.Users.Add (user);
            await _context.SaveChangesAsync ();
            return user;
        }

        public async Task<User> DeleteUser (User user) {
            _context.Users.Remove (user);
            await _context.SaveChangesAsync ();
            return user;
        }

        public List<User> GetAllUsers () {
            return _context.Users.ToList ();
        }

        public User GetUserById (int id) {
            return _context.Users.FirstOrDefault (x => x.Id == id);
        }

        public bool SaveChanges () {
            throw new System.NotImplementedException ();
        }

        public async Task<User> UpdateUser (User user) {
            _context.Users.Update (user);
            await _context.SaveChangesAsync ();
            return user;
        }
    }
}