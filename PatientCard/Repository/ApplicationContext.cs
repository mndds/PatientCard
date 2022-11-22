using Microsoft.EntityFrameworkCore;
using PatientCard.Models;

namespace PatientCard.Repository {
    public class ApplicationContext:DbContext {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {
            Database.EnsureCreated();   
        }
    }
}
