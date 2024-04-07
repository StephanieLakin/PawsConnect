using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsConnectData.Entities
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? ServiceProviderName { get; set; }

        public string? ServiceType { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        public string? AvailabilitySchedule { get; set; }

        public string? Pricing { get; set; }

    }
}
