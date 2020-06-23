using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFuelStation.DbContexts;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;
using BCrypt.Net;

namespace APIFuelStation.Repositories {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly FuelDBContext _context;

        public EmployeeRepository (FuelDBContext context) {
            this._context = context;
        }

        public async Task<Employee> CreateEmployee (Employee user) {
            user.Password = BCrypt.Net.BCrypt.HashPassword (user.Password);
            _context.Employees.Add (user);
            await _context.SaveChangesAsync ();
            return user;
        }

        public async Task<Employee> DeleteEmployee (Employee user) {
            _context.Employees.Remove (user);
            await _context.SaveChangesAsync ();
            return user;
        }

        public List<Employee> GetAllEmployees () {
            return _context.Employees.ToList ();
        }

        public Employee GetEmployeeById (int id) {
            return _context.Employees.FirstOrDefault (x => x.Id == id);
        }

        public Employee GetEmployeeByEmail (string email) {
            return _context.Employees.FirstOrDefault (x => x.Email == email);
        }

        public Employee GetEmployeeByEmployeeName (string userName) {
            return _context.Employees.FirstOrDefault (x => x.UserName == userName);
        }

        public Employee GetEmployeeByPhoneNo (string phoneNo) {
            return _context.Employees.FirstOrDefault (x => x.PhoneNo == phoneNo);
        }

        public async Task<Employee> UpdateEmployee (Employee user) {
            _context.Employees.Update (user);
            await _context.SaveChangesAsync ();
            return user;
        }

    }
}