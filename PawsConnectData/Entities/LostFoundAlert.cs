using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class LostFoundAlert
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } // Foreign Key to associate with the user who posted the alert

        public Guid DogId { get; set; } // Foreign Key to associate with the dog in the alert

        public string AlertType { get; set; }

        public string Description { get; set; }

        public string LastKnownLocation { get; set; }

        public string ContactInformation { get; set; }

        public DateTime DateTimePosted { get; set; }

        public string Notes { get; set; }


        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property for the user who posted this lost/found alert

        [ForeignKey("DogId")]
        public Dog Dog { get; set; } // Navigation property for the dog associated with this lost/found alert
    }
}

