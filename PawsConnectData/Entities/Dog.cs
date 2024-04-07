using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class Dog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } // Foreign Key to associate with the user who owns the dog

        public User User { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public string MedicalHistory { get; set; }

        public string Allergies { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;  

        public ICollection<HealthRecord> HealthRecords { get; set; }
        public ICollection<ActivityLog> ActivityLogs { get; set; }
        public ICollection<LostFoundAlert> LostFoundAlerts { get; set; }


        [ForeignKey("UserId")]
        public User? Owner { get; set; } // Navigation property for the owner of the dog
    }
}
