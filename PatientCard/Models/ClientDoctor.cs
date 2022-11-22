namespace PatientCard.Models {
    public class ClientDoctor {

        public int ClientId { get; set; }

        public Client? Client { get; set; }

        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }


    }
}
