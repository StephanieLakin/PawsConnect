using PawsConnect.Models.Users;

namespace PawsConnect.Models.CommunityPost
{
    public class CreateCommunityPostModel
    {
        public string Content { get; set; }

        public string Image { get; set; } // single image for simplicity at this time

        public DateTime DateTimePosted { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; } // Foreign key
        public UserModel User { get; set; } // Navigation property
    }
}
