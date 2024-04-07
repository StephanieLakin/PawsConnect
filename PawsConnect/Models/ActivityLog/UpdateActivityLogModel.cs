namespace PawsConnect.Models.ActivityLog
{
    public class UpdateActivityLogModel
    {
        public Guid Id { get; set; }

        public string? ActivityType { get; set; }

        public string? ActivityName { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public double CaloriesBurned { get; set; }

        public string? Notes { get; set; }
    }
}
