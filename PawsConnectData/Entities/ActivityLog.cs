using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PawsConnectData.Entities
{
    public class ActivityLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public Guid DogId { get; set; } // Foreign Key to associate with the dog

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string? ActivityType { get; set; }

        public string? ActivityName { get; set; }

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }

        public double CaloriesBurned { get; set; }

        public string? Notes { get; set; }       


        [ForeignKey("DogId")]
        public Dog Dog { get; set; } // Navigation property for the dog associated with this activity log
    }
}

