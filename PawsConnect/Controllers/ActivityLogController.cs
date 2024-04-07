using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.ActivityLog;
using PawsConnect.Services;

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityLogController : ControllerBase
    {
        private IActivityLogService _activityLogService;

        public ActivityLogController(IActivityLogService activityLogService)
        {
            _activityLogService = activityLogService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetActivityLogs()
        {
            try
            {
                var result = await _activityLogService.GetActivityLogs();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityLogById(Guid activityLogId)
        {
            try
            {
                var result = await _activityLogService.GetActivityLogById(activityLogId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateActivityLog([FromBody] CreateActivityLogModel activityLogPost)
        {
            try
            {
                await _activityLogService.CreateActivityLog(activityLogPost);
                return Ok(activityLogPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivityLog([FromBody] UpdateActivityLogModel updatedActivityLog)
        {
            try
            {
                await _activityLogService.EditActivityLog(updatedActivityLog);
                return Ok(updatedActivityLog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{activityLogId}")]
        public async Task<IActionResult> DeleteActivityLog(Guid activityLogId)
        {
            try
            {
                await _activityLogService.DeleteActivityLog(activityLogId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
