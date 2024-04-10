using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.CommunityServices;
using PawsConnectData.Data;
using PawsConnectData.Entities;

namespace PawsConnect.Services
{
    public interface ICommunityServicesService
    {
        Task<CommunityServiceModel[]> GetCommunityServicess();

        Task<CommunityServiceModel> GetCommunityServicesById(Guid communityServicesId);

        Task CreateCommunityServices(CreateCommunityServiceModel communityServicesServices);

        Task EditCommunityServices(UpdateCommunityServiceModel UpdatedServices);

        Task DeleteCommunityServices(Guid communityServicesId);
    }
    public class CommunityServicesService : BaseService, ICommunityServicesService

    {
        public CommunityServicesService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<CommunityServiceModel[]> GetCommunityServicess()
        {
            CommunityServiceModel[] communityServicess = { };

            communityServicess = await _pcContext.Services
                .Select(cp => new CommunityServiceModel
                {
                    Id = cp.Id,
                    Address = cp.Address,
                    AvailabilitySchedule = cp.AvailabilitySchedule,
                    Description = cp.Description,
                    PhoneNumber = cp.PhoneNumber,
                    Pricing = cp.Pricing,
                    ServiceType = cp.ServiceType,
                    ServiceProviderName = cp.ServiceProviderName,
                }).ToArrayAsync();
            return communityServicess;
        }

        public async Task<CommunityServiceModel> GetCommunityServicesById(Guid communityServicesId)
        {
            var communityServices = await _pcContext.Services
                .FirstOrDefaultAsync(cp => cp.Id == communityServicesId);

            if (communityServices == null)
            {
                return null;
            }

            var communityServicesModel = new CommunityServiceModel
            {
                Id = communityServicesId,
                Address = communityServices.Address,
                AvailabilitySchedule = communityServices.AvailabilitySchedule,
                Description = communityServices.Description,
                PhoneNumber = communityServices.PhoneNumber,
                ServiceProviderName = communityServices.ServiceProviderName,
                ServiceType = communityServices.ServiceType,
                Pricing = communityServices.Pricing,
            };
            return communityServicesModel;
        }

        public async Task CreateCommunityServices(CreateCommunityServiceModel communityService)
        {
            Service service = new Service
            {
                Id = Guid.NewGuid(),
                Address = communityService.Address,
                AvailabilitySchedule = communityService.AvailabilitySchedule,
                Description = communityService.Description,
                PhoneNumber = communityService.PhoneNumber,
                ServiceProviderName = communityService.ServiceProviderName,
                ServiceType = communityService.ServiceType,
                Pricing = communityService.Pricing,
            };
            _pcContext.Services.Add(service);
            await _pcContext.SaveChangesAsync();
        }

        public async Task EditCommunityServices(UpdateCommunityServiceModel communityService)
        {
            var cservice = await _pcContext.Services.FirstOrDefaultAsync(cservice => cservice.Id == communityService.Id);
            if (cservice == null)
            {
                return;
            }

            cservice.Address = communityService.Address;
            cservice.Description = communityService.Description;
            cservice.ServiceProviderName = communityService.ServiceProviderName;
            cservice.PhoneNumber = communityService.PhoneNumber;
            cservice.AvailabilitySchedule = communityService.AvailabilitySchedule;
            cservice.ServiceType = communityService.ServiceType;
            cservice.Pricing = communityService.Pricing;

            await _pcContext.SaveChangesAsync();
        }

        public async Task DeleteCommunityServices(Guid communityServicesId)
        {
            var cservice = await _pcContext.Services.FirstOrDefaultAsync(cp => cp.Id == communityServicesId);
            if (cservice == null)
            {
                return;
            }

            _pcContext.Services.Remove(cservice);
            await _pcContext.SaveChangesAsync();
        }
    }
}
