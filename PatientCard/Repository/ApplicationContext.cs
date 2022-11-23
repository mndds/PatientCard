using Microsoft.EntityFrameworkCore;
using PatientCard.Models;

namespace PatientCard.Repository {
    public class ApplicationContext:DbContext {
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;

        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {
            
            Database.EnsureCreated();   
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
            .Entity<Client>()
            .HasMany(c => c.Doctors)
            .WithMany(s => s.Clients)
            .UsingEntity<Appointment>(
               j => j
                .HasOne(pt => pt.Doctor)
                .WithMany(t => t.Appointments)
                .HasForeignKey(pt => pt.DoctorId),
            j => j
                .HasOne(pt => pt.Client)
                .WithMany(p => p.Appointments)
                .HasForeignKey(pt => pt.ClientId),
            j => {
                j.Property(pt => pt.Diagnosis);
                j.Property(pt => pt.Complaints);
                j.Property(pt => pt.CreatedDate);                
                j.HasKey(t => new { t.id });               
                j.ToTable("Appointments");
                
            });
        }
    }
}
