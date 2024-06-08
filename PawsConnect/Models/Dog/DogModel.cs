using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.HealthRecord;
using PawsConnect.Models.Users;
using PawsConnectData.Entities;
using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models.Dog
{
    public class DogModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public string MedicalHistory { get; set; }

        public string Allergies { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? ImageUrl1 { get; set; }

        public string? ImageUrl2 { get; set; }

        public string? ImageUrl3 { get; set; }

        public string? Bio { get; set; }


        public Guid UserId { get; set; } // Foreign key       
    }
}
