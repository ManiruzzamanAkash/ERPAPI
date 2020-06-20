using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFuelStation.DbContexts;
using APIFuelStation.IRepositories;
using APIFuelStation.Models;

namespace APIFuelStation.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly FuelDBContext _context;

        public DesignationRepository(FuelDBContext context)
        {
            this._context = context;
        }

        public async Task<Designation> CreateDesignation(Designation designation)
        {
            designation.Code = "DES" + designation.Name;
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> DeleteDesignation(Designation designation)
        {
            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public List<Designation> GetAllDesignations()
        {
            return _context.Designations.ToList();
        }

        public Designation GetDesignationById(int id)
        {
            return _context.Designations.FirstOrDefault(designation => designation.Id == id);
        }

        public Designation GetDesignationByCode(string code)
        {
            return _context.Designations.FirstOrDefault(designation => designation.Code == code);
        }

        public async Task<Designation> UpdateDesignation(Designation designation)
        {
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

    }
}