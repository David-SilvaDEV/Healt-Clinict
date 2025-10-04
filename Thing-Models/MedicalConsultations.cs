namespace Healt_Clinict.Thing_Models
{
    public class MedicalConsultations
    {   
        public Guid Id { get; set; }

        public string AnimalName { get; set; }

        public string OwnerName { get; set; }

         public string NumberDocument { get; set; }
        public string OwnerContact { get; set; }

       
        private DateTime DateConsultation { get; set; }
        private string Diagnosis { get; set; }
        private string Treatment { get; set; }
        private string Veterinarian { get; set; }
        private string Notes { get; set; }
    }
}