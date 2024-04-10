using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.LostAndFoundAlert;
using PawsConnect.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostAndFoundAlertController : ControllerBase
    {
        private ILostAndFoundAlertService _lostFoundAlertService;

        public LostAndFoundAlertController(ILostAndFoundAlertService lostFoundAlertService)
        {
            _lostFoundAlertService = lostFoundAlertService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetLostAndFoundAlerts()
        {
            try
            {
                var result = await _lostFoundAlertService.GetLostAndFoundAlerts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{lostFoundAlertId}")]
        public async Task<IActionResult> GetLostAndFoundAlertById(Guid lostFoundAlertId)
        {
            try
            {
                var result = await _lostFoundAlertService.GetLostAndFoundAlertById(lostFoundAlertId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateLostAndFoundAlert([FromBody] CreateLostAndFoundAlertModel lostFoundAlert)
        {
            try
            {
                await _lostFoundAlertService.CreateLostAndFoundAlert(lostFoundAlert);
                return Ok(lostFoundAlert);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{lostFoundAlertId}")]
        public async Task<IActionResult> EditLostAndFoundAlert([FromBody] UpdateLostAndFoundAlertModel updatedLostAndFoundAlert)
        {
            try
            {
                await _lostFoundAlertService.EditLostAndFoundAlert(updatedLostAndFoundAlert);
                return Ok(updatedLostAndFoundAlert);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{lostFoundAlertId}")]
        public async Task<IActionResult> DeleteLostAndFoundAlert(Guid lostFoundAlertId)
        {
            try
            {
                await _lostFoundAlertService.DeleteLostAndFoundAlert(lostFoundAlertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
