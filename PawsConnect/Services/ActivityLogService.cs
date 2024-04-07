using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.Dog;
using PawsConnect.Models.HealthRecord;
using PawsConnectData.Data;
using PawsConnectData.Entities;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace PawsConnect.Services
{
    public interface IActivityLogService
    {
        Task<ActivityLogModel[]> GetActivityLogs();

        Task <ActivityLogModel> GetActivityLogById(Guid activityLogId);

        Task CreateActivityLog(CreateActivityLogModel activityLogPost);

        Task EditActivityLog(UpdateActivityLogModel activityLogId);

        Task DeleteActivityLog(Guid activityLogId);
    }
    public class ActivityLogService : BaseService, IActivityLogService
    {
        public ActivityLogService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<ActivityLogModel[]> GetActivityLogs()
        {
            ActivityLogModel[] activityLogs = { };

            activityLogs = await _pcContext.ActivityLogs
                .Select(al => new ActivityLogModel
                {
                    Id = al.Id,
                    ActivityName = al.ActivityName,
                    ActivityType = al.ActivityType,
                    CaloriesBurned = al.CaloriesBurned,
                    CreatedDate = al.Date,
                    Distance = al.Distance,                   
                    DogId = al.DogId,
                    Duration = al.Duration,
                    Notes = al.Notes

                }).ToArrayAsync();

            return activityLogs;
        }

        public async Task<ActivityLogModel> GetActivityLogById(Guid activityLogId)
        {       
            var activityLog = await _pcContext.ActivityLogs
                .FirstOrDefaultAsync(al => al.Id == activityLogId);

            if (activityLog == null)
            {
                return null;
            }

            var activityLogModel = new ActivityLogModel
            {
                Id = activityLog.Id,
                ActivityName = activityLog.ActivityName,
                ActivityType = activityLog.ActivityType,
                CaloriesBurned = activityLog.CaloriesBurned,
                CreatedDate = activityLog.Date,
                Distance = activityLog.Distance,
                DogId = activityLog.DogId,
                Duration = activityLog.Duration,
                Notes = activityLog.Notes
            };

            return activityLogModel;
        }

        public async Task CreateActivityLog(CreateActivityLogModel activityLog)
        {
            ActivityLog activity = new ActivityLog
            {
                Id = Guid.NewGuid(),
                ActivityName = activityLog.ActivityName,
                ActivityType = activityLog.ActivityType,
                CaloriesBurned = activityLog.CaloriesBurned,
                Date = DateTime.UtcNow,
                Distance = activityLog.Distance,
                DogId = activityLog.DogId,
                Duration = activityLog.Duration,
                Notes = activityLog.Notes
            };
            _pcContext.ActivityLogs.Add(activity);
            await _pcContext.SaveChangesAsync();
        }

        public async Task EditActivityLog(UpdateActivityLogModel updatedActivityLog)
        {            
            var activity = await _pcContext.ActivityLogs.FirstOrDefaultAsync(activity => activity.Id == updatedActivityLog.Id);
            
            if (activity == null)
            {               
                return;
            }
           
            activity.ActivityName = updatedActivityLog.ActivityName;
            activity.ActivityType = updatedActivityLog.ActivityType;
            activity.CaloriesBurned = updatedActivityLog.CaloriesBurned;
            activity.Distance = updatedActivityLog.Distance;
            activity.Duration = updatedActivityLog.Duration;
            activity.Notes = updatedActivityLog.Notes;
          
            await _pcContext.SaveChangesAsync();
        }



        public async Task DeleteActivityLog(Guid activityLogId)
        {           
            var activity = await _pcContext.ActivityLogs.FirstOrDefaultAsync(activity => activity.Id == activityLogId);
                       
            if (activity == null)
            {                
                return;
            }
           
            _pcContext.ActivityLogs.Remove(activity);           
            await _pcContext.SaveChangesAsync();
        }
    }
}
            
