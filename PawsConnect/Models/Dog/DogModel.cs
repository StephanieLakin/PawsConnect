using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.HealthRecord;
using PawsConnect.Models.Users;
using PawsConnectData.Entities;

namespace PawsConnect.Models.Dog
{
    public class DogModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public string MedicalHistory { get; set; }

        public string Allergies { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid UserId { get; set; } // Foreign key
        public UserModel User { get; set; } // Navigation property
        public List<HealthRecordModel> HealthRecords { get; set; } // Navigation property
        public List<ActivityLogModel> ActivityLogs { get; set; } // Navigation property
        public List<LostFoundAlert> LostFoundAlerts { get; set; } // Navigation property
    }
}
