using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models.Users
{
    public class UserRegisterRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required, EmailAddress] 
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(6, ErrorMessage ="Please enter at lest 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
