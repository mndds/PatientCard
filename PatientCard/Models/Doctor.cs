using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models {
    public class Doctor {
        public int Id { get; set; }

        [Display(Name = "Специалист")]
        public string Specialist { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        public List<Client> Clients { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
    }
}
