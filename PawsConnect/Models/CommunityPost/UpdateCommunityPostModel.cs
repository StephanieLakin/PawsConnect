namespace PawsConnect.Models.CommunityPost
{
    public class UpdateCommunityPostModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string Image { get; set; } // single image for simplicity at this time
       
    }
}
