namespace PawsConnect.Models.HealthRecord
{
    public class UpdateHealthRecord
    {
        public Guid Id { get; set; }

        public string? Vaccinations { get; set; }

        public string? Medications { get; set; }

        public string? Allergies { get; set; }

        public string? MedicalConditions { get; set; }

        public DateTime? LastVetVisitDate { get; set; }

        public DateTime? NextVetVisitDate { get; set; }

        public string? VeterinarianName { get; set; }

        public string? VeterinaryPracticeName { get; set; }

        public int VeterinarianPhoneNumber { get; set; }
    }
}
