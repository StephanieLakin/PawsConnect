using PawsConnect.Models.Users;

namespace PawsConnect.Models.CommunityPost
{
    public class CommunityPostModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string Image { get; set; } // single image for simplicity at this time

        public DateTime DateTimePosted { get; set; } 

        public Guid UserId { get; set; } // Foreign key        
    }
}

