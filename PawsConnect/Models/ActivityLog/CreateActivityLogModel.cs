using PawsConnect.Models.Dog;

namespace PawsConnect.Models.ActivityLog
{
    public class CreateActivityLogModel
    {
        public DateTime CreatedDate { get; set; } 

        public string? ActivityType { get; set; }

        public string? ActivityName { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public double CaloriesBurned { get; set; }

        public string? Notes { get; set; }
        public Guid DogId { get; set; } // Foreign key
        public DogModel Dog { get; set; } // Navigation property
    }
}
