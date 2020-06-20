using System.Collections.Generic;
using System.Threading.Tasks;
using APIFuelStation.Models;

namespace APIFuelStation.IRepositories
{
    public interface IDesignationRepository
    {

        List<Designation> GetAllDesignations();
        Designation GetDesignationById(int id);
        Designation GetDesignationByCode(string code);
        Task<Designation> CreateDesignation(Designation designation);
        Task<Designation> UpdateDesignation(Designation designation);
        Task<Designation> DeleteDesignation(Designation designation);

    }
}