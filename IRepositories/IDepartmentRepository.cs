using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories
{
    public interface IDepartmentRepository
    {

        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        Department GetDepartmentByCode(string code);
        Task<Department> CreateDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(Department department);

    }
}