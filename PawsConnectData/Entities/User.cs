using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }    
        
        public string LastName { get; set; }    
        
        public string UserName { get; set; }

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[32];

        public byte[] PasswordSalt { get; set; } = new byte[32];

        public string VerificationToken { get; set; }

        public string Password { get; set; }

        public string? PasswordResetToken { get; set; }

        public DateTime? PassWordResetExpires { get; set; }

        public string? ProfilePicture { get; set; }

        public DateTime? VerifiedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ActivityLog>? ActivityLogs { get; set; }
        public ICollection<CommunityPost>? CommunityPosts { get; set; }       
        public ICollection<Dog>? Dogs { get; set; }
        public ICollection<LostFoundAlert>?  LostFoundAlerts { get; set; }

    }
}
