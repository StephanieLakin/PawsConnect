using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.CommunityPost;
using PawsConnect.Models.HealthRecord;
using PawsConnectData.Data;
using PawsConnectData.Entities;

namespace PawsConnect.Services
{
    public interface IHealthRecordService
    {
        Task<HealthRecordModel[]> GetHealthRecords();

        Task<HealthRecordModel> GetHealthRecordById(Guid healthRecordId);

        Task CreateHealthRecord(CreateHealthRecordModel healthRecordPost);

        Task EditHealthRecord(UpdateHealthRecordModel UpdatedPost);

        Task DeleteHealthRecord(Guid healthRecordId);
    }
    public class HealthRecordService : BaseService, IHealthRecordService
    {
        public HealthRecordService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<HealthRecordModel[]> GetHealthRecords()
        {
            HealthRecordModel[] healthRecords = { };

            healthRecords = await _pcContext.HealthRecords
                .Select(hr => new HealthRecordModel
                {
                    Id = hr.Id,
                    Vaccinations = hr.Vaccinations,
                    MedicalConditions = hr.MedicalConditions,
                    Medications = hr.Medications,
                    Allergies = hr.Allergies,
                    LastVetVisitDate = hr.LastVetVisitDate,
                    NextVetVisitDate = hr.NextVetVisitDate,
                    VeterinarianName = hr.VeterinarianName,
                    VeterinarianPhoneNumber = hr.VeterinarianPhoneNumber,
                    VeterinaryPracticeName = hr.VeterinaryPracticeName,
                    
                }).ToArrayAsync();
            return healthRecords;
        }

        public async Task<HealthRecordModel> GetHealthRecordById(Guid healthRecordId)
        {
            var healthRecord = await _pcContext.HealthRecords
                .FirstOrDefaultAsync(hr => hr.Id == healthRecordId);

            if (healthRecord == null)
            {
                return null;
            }

            var healthRecordModel = new HealthRecordModel
            {
                Id = healthRecord.Id,
                Vaccinations = healthRecord.Vaccinations,
                MedicalConditions = healthRecord.MedicalConditions,
                Medications = healthRecord.Medications,
                Allergies = healthRecord.Allergies,
                LastVetVisitDate = healthRecord.LastVetVisitDate,
                NextVetVisitDate = healthRecord.NextVetVisitDate,
                VeterinarianName = healthRecord.VeterinarianName,
                VeterinarianPhoneNumber = healthRecord.VeterinarianPhoneNumber,
                VeterinaryPracticeName = healthRecord.VeterinaryPracticeName,

            };
            return healthRecordModel;
        }

        public async Task CreateHealthRecord(CreateHealthRecordModel healthRecord)
        {
            HealthRecord post = new HealthRecord
            {
                Id = Guid.NewGuid(),
                
            };
            _pcContext.HealthRecords.Add(post);
            await _pcContext.SaveChangesAsync();
        }

        public async Task EditHealthRecord(UpdateHealthRecordModel healthRecord)
        {
            var record = await _pcContext.HealthRecords.FirstOrDefaultAsync(record => record.Id == healthRecord.Id);
            if (record == null)
            {
                return;
            }

            record.Vaccinations = healthRecord.Vaccinations;
            record.Medications = healthRecord.Medications;
            record.Allergies = healthRecord.Allergies;
            record.MedicalConditions = healthRecord.MedicalConditions;
            record.LastVetVisitDate = healthRecord.LastVetVisitDate;
            record.NextVetVisitDate = healthRecord?.NextVetVisitDate;
            record.VeterinarianName = healthRecord?.VeterinarianName;
            record.VeterinarianPhoneNumber = healthRecord.VeterinarianPhoneNumber;

            await _pcContext.SaveChangesAsync();
        }

        public async Task DeleteHealthRecord(Guid healthRecordId)
        {
            var record = await _pcContext.HealthRecords.FirstOrDefaultAsync(hr => hr.Id == healthRecordId);
            if (record == null)
            {
                return;
            }

            _pcContext.HealthRecords.Remove(record);
            await _pcContext.SaveChangesAsync();
        }
    }
}
