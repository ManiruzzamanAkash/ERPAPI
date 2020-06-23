using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories {
    public interface IEmployeeRepository {

        List<Employee> GetAllEmployees ();
        Employee GetEmployeeById (int id);
        Employee GetEmployeeByEmail (string email);
        Employee GetEmployeeByEmployeeName (string userName);
        Employee GetEmployeeByPhoneNo (string phoneNo);
        Task<Employee> CreateEmployee (Employee user);
        Task<Employee> UpdateEmployee (Employee user);
        Task<Employee> DeleteEmployee (Employee user);

    }
}