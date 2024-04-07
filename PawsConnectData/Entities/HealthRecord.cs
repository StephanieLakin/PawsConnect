using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class HealthRecord
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DogId { get; set; } // Foreign Key to associate with the dog

        public string? Vaccinations { get; set; }

        public string? Medications { get; set; }

        public string? Allergies { get; set; }

        public string? MedicalConditions { get; set; }

        public DateTime? LastVetVisitDate { get; set; }

        public DateTime? NextVetVisitDate { get; set; }

        public string? VeterinarianName { get; set; }

        public string? VeterinaryPracticeName { get; set; }

        public int VeterinarianPhoneNumber { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        [ForeignKey("DogId")]
        public Dog? Dog { get; set; } // Navigation property for the dog associated with this health record
    }
}
