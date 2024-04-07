﻿namespace PawsConnect.Models.CommunityServices
{
    public class CreateCommunityServiceModel
    {
        public string? ServiceProviderName { get; set; }

        public string? ServiceType { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public int PhoneNumber { get; set; }

        public string? AvailabilitySchedule { get; set; }

        public string? Pricing { get; set; }
    }
}