using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.Users;
using PawsConnect.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase  
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequestModel request)
        {
            try
            {
                await _userService.Register(request);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
                await _userService.Login(request);
                return Ok("User logged in successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            try
            {
                await _userService.Verify(token);
                return Ok("User verified.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> PasswordForgot(string email)
        {
            try
            {
                await _userService.PasswordForgot(email);
                return Ok("Please reset your password now.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("password-reset")]
        public async Task<IActionResult> PasswordReset(ResetPasswordRequest request)
        {
            try
            {
                await _userService.PasswordReset(request);
                return Ok("Password Successfully Reset");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var result = await _userService.GetUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            try
            {
                var result = await _userService.GetUserById(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel user)
        {
            try
            {
                await _userService.CreateUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> EditActivityLog([FromBody] UpdateUserModel userId)
        {
            try
            {
                await _userService.EditUser(userId);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
