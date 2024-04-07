using PawsConnect.Models.CommunityPost;
using PawsConnect.Models.Dog;
using PawsConnectData.Entities;
using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models.Users
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string VerificationToken { get; set; }

        public Guid? PasswordResetToken { get; set; }

        public DateTime? PassWordResetExpires { get; set; }

        public DateTime? PassWordResetCreated { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime VerifiedAt { get; set; }

        //public List<DogModel> Dogs { get; set; } // Navigation property
        //public List<CommunityPostModel> CommunityPosts { get; set; } // Navigation property
        //public List<LostFoundAlert> LostFoundAlerts { get; set; }
    }
}
