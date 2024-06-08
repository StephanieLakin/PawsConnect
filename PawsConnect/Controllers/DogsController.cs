using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PawsConnect.Models.Dog;
using PawsConnect.Services;
using System;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private IDogService _dogService;
        private readonly IUserService _userService;

        public DogsController(IDogService dogService, IUserService userService)
        {
            _dogService = dogService;
            _userService = userService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetDogs()
        {
            try
            {
                var result = await _dogService.GetDogs();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{dogId}")]
        public async Task<IActionResult> GetDogById(Guid dogId)
        {
            try
            {
                var result = await _dogService.GetDogById(dogId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateDog([FromBody] CreateDogModel dog)
        {
            try
            {
                Console.WriteLine("Received create dog request: " + JsonConvert.SerializeObject(dog));
                await _dogService.CreateDog(dog);
                return Ok(dog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{dogId}")]
        public async Task<IActionResult> EditDog(Guid dogId,[FromBody] UpdateDogModel updatedDog)
        {
            try
            {
               
                await _dogService.EditDog(updatedDog);
                return Ok(updatedDog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{dogId}")]
        public async Task<IActionResult> DeleteDog(Guid dogId)
        {
            try
            {
                await _dogService.DeleteDog(dogId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
