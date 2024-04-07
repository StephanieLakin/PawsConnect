namespace PawsConnect.Models.Dog
{
    public class UpdateDogModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public string MedicalHistory { get; set; }

        public string Allergies { get; set; }
    }
}
