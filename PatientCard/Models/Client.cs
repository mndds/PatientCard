using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models {
    public class Client {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage ="Поле обязательно для ввода!" )]
        public string? FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public string? LastName { get; set; }

        [Display(Name = "ИИН")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Неверный формат ИИН")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public string? IIN { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        public string? Adress { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле обязательно для ввода!")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона")]
        public string? Phone { get; set; }
        public List<Doctor> Doctors { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        
    }
}
