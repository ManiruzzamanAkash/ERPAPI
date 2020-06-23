using APIFuelStation.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFuelStation.DbContexts {
    public class FuelDBContext : DbContext {

        public FuelDBContext (DbContextOptions<FuelDBContext> opt) : base (opt) {

        }

        // public DbSet<Command> Commands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // Keys
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            // User Model
            modelBuilder.Entity<User> ()
                .HasIndex (user => user.Email)
                .IsUnique ();
            modelBuilder.Entity<User> ()
                .HasIndex (user => user.PhoneNo)
                .IsUnique ();
            modelBuilder.Entity<User> ()
                .HasIndex (user => user.UserName)
                .IsUnique ();

            // Department Model
            modelBuilder.Entity<Department> ()
                .HasIndex (department => department.Code)
                .IsUnique ();

            // Designation Model
            modelBuilder.Entity<Designation> ()
                .HasIndex (designation => designation.Code)
                .IsUnique ();
        }
    }
}