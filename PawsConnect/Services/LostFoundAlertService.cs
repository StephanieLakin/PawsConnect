using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.LostAndFoundAlert;
using PawsConnectData.Data;
using PawsConnectData.Entities;

namespace PawsConnect.Services
{  
    public interface ILostAndFoundAlertService
    {
        Task<LostAndFoundAlertModel[]> GetLostAndFoundAlerts();

        Task<LostAndFoundAlertModel> GetLostAndFoundAlertById(Guid lostFoundAlertId);

        Task CreateLostAndFoundAlert(CreateLostAndFoundAlertModel lostFoundAlertPost);

        Task EditLostAndFoundAlert(UpdateLostAndFoundAlertModel UpdatedPost);

        Task DeleteLostAndFoundAlert(Guid lostFoundAlertId);
    }
    public class LostAndFoundAlertService : BaseService, ILostAndFoundAlertService
    {
        public LostAndFoundAlertService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<LostAndFoundAlertModel[]> GetLostAndFoundAlerts()
        {
            LostAndFoundAlertModel[] lostFoundAlerts = { };

            lostFoundAlerts = await _pcContext.LostFoundAlerts
                .Select(lfa => new LostAndFoundAlertModel
                {
                    Id = lfa.Id,
                    AlertType = lfa.AlertType,
                    ContactInformation = lfa.ContactInformation,
                    DateTimePosted = lfa.DateTimePosted,
                    Description = lfa.Description,
                    DogId = lfa.DogId,
                    LastKnownLocation = lfa.LastKnownLocation
                }).ToArrayAsync();
            return lostFoundAlerts;
        }

        public async Task<LostAndFoundAlertModel> GetLostAndFoundAlertById(Guid lostFoundAlertId)
        {
            var lostFoundAlert = await _pcContext.LostFoundAlerts
                .FirstOrDefaultAsync(lfa => lfa.Id == lostFoundAlertId);

            if (lostFoundAlert == null)
            {
                return null;
            }

            var lostFoundAlertModel = new LostAndFoundAlertModel
            {
                Id = lostFoundAlertId,
                AlertType = lostFoundAlert.AlertType,
                ContactInformation = lostFoundAlert.ContactInformation,
                DateTimePosted = lostFoundAlert.DateTimePosted,
                Description = lostFoundAlert.Description,
                DogId = lostFoundAlert.DogId,
                LastKnownLocation = lostFoundAlert.LastKnownLocation
            };
            return lostFoundAlertModel;
        }

        public async Task CreateLostAndFoundAlert(CreateLostAndFoundAlertModel lostFoundAlert)
        {
            LostFoundAlert alert = new LostFoundAlert
            {
                Id = Guid.NewGuid(),
                AlertType = lostFoundAlert.AlertType,
                ContactInformation = lostFoundAlert.ContactInformation,
                DogId = lostFoundAlert.DogId,
                Description = lostFoundAlert.Description,
                LastKnownLocation = lostFoundAlert.LastKnownLocation,
                DateTimePosted = DateTime.UtcNow,                
            };
            _pcContext.LostFoundAlerts.Add(alert);
            await _pcContext.SaveChangesAsync();
        }

        public async Task EditLostAndFoundAlert(UpdateLostAndFoundAlertModel lostFoundAlert)
        {
            var lfAlert = await _pcContext.LostFoundAlerts.FirstOrDefaultAsync(lfAlert => lfAlert.Id == lostFoundAlert.Id);
            if (lfAlert == null)
            {
                return;
            }

            lfAlert.AlertType = lostFoundAlert.AlertType;
            lfAlert.Description = lostFoundAlert.Description;
            lfAlert.LastKnownLocation = lostFoundAlert.LastKnownLocation;
            lfAlert.ContactInformation = lostFoundAlert.ContactInformation;
            lfAlert.DogId = lostFoundAlert.DogId;
             await _pcContext.SaveChangesAsync();
        }

        public async Task DeleteLostAndFoundAlert(Guid lostFoundAlertId)
        {
            var alert = await _pcContext.LostFoundAlerts.FirstOrDefaultAsync(lfa => lfa.Id == lostFoundAlertId);
            if (alert == null)
            {
                return;
            }

            _pcContext.LostFoundAlerts.Remove(alert);
            await _pcContext.SaveChangesAsync();
        }
    }
}
