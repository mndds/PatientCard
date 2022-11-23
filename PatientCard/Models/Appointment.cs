using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models {

    public class Appointment {        
        public int id { get; set; }

        [Display(Name = "Id доктора")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [Display(Name = "Id клиента")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Display(Name = "Диагноз")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public string? Diagnosis { get; set; }

        [Display(Name = "Жалобы")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public string? Complaints { get; set; }

        [Display(Name = "Дата посещения")]
        public DateTime CreatedDate { get; set; }

    }
}
