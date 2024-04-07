namespace PawsConnect.Models.LostAndFoundAlert
{
    public class UpdateLostAndFoundAlertModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; } // Foreign Key to associate with the user who posted the alert

        public Guid DogId { get; set; } // Foreign Key to associate with the dog in the alert

        public string AlertType { get; set; }

        public string Description { get; set; }

        public string LastKnownLocation { get; set; }

        public string ContactInformation { get; set; }

        public DateTime DateTimePosted { get; set; }

        public string Notes { get; set; }
    }
}
