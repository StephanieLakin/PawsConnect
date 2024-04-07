using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class CommunityPost
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } // Foreign Key to associate with the user who posted

        public string Content { get; set; }

        public string Image { get; set; } // single image for simplicity at this time

        public DateTime DateTimePosted { get; set; } = DateTime.UtcNow;
       

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property for the user who posted this community post
    }
}
