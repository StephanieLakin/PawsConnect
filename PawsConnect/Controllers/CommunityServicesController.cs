using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.CommunityServices;
using PawsConnect.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityServicesController : ControllerBase
    {
        private ICommunityServicesService _communityServicesService;

        public CommunityServicesController(ICommunityServicesService communityServicesService)
        {
            _communityServicesService = communityServicesService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetCommunityServicess()
        {
            try
            {
                var result = await _communityServicesService.GetCommunityServicess();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{communityServicesId}")]
        public async Task<IActionResult> GetCommunityServicesById(Guid communityServicesId)
        {
            try
            {
                var result = await _communityServicesService.GetCommunityServicesById(communityServicesId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateCommunityServices([FromBody] CreateCommunityServiceModel communityServices)
        {
            try
            {
                await _communityServicesService.CreateCommunityServices(communityServices);
                return Ok(communityServices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{communityServicesId}")]
        public async Task<IActionResult> EditCommunityServices([FromBody] UpdateCommunityServiceModel updatedCommunityServices)
        {
            try
            {
                await _communityServicesService.EditCommunityServices(updatedCommunityServices);
                return Ok(updatedCommunityServices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{communityServicesId}")]
        public async Task<IActionResult> DeleteCommunityServices(Guid communityServicesId)
        {
            try
            {
                await _communityServicesService.DeleteCommunityServices(communityServicesId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
