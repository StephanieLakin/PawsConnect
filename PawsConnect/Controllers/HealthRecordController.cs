using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.HealthRecord;
using PawsConnect.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordController : ControllerBase
    {
        private IHealthRecordService _healthRecordService;

        public HealthRecordController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetHealthRecords()
        {
            try
            {
                var result = await _healthRecordService.GetHealthRecords();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{healthRecordId}")]
        public async Task<IActionResult> GetHealthRecordById(Guid healthRecordId)
        {
            try
            {
                var result = await _healthRecordService.GetHealthRecordById(healthRecordId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateHealthRecord([FromBody] CreateHealthRecordModel healthRecord)
        {
            try
            {
                await _healthRecordService.CreateHealthRecord(healthRecord);
                return Ok(healthRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{healthRecordId}")]
        public async Task<IActionResult> EditHealthRecord([FromBody] UpdateHealthRecordModel updatedHealthRecord)
        {
            try
            {
                await _healthRecordService.EditHealthRecord(updatedHealthRecord);
                return Ok(updatedHealthRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{healthRecordId}")]
        public async Task<IActionResult> DeleteHealthRecord(Guid healthRecordId)
        {
            try
            {
                await _healthRecordService.DeleteHealthRecord(healthRecordId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
