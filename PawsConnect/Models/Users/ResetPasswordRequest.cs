using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models.Users
{
    public class ResetPasswordRequest
    {        
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage = "Please enter at lest 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
