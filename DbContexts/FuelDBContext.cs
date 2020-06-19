using APIFuelStation.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFuelStation.DbContexts {
    public class FuelDBContext : DbContext {
        public FuelDBContext (DbContextOptions<FuelDBContext> opt) : base (opt) {

        }

        // public DbSet<Command> Commands { get; set; }
        public DbSet<User> Users { get; set; }
    }
}