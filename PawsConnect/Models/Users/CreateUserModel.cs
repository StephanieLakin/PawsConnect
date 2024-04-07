namespace PawsConnect.Models.Users
{
    public class CreateUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string VerificationToken { get; set; }

        public Guid? PasswordResetToken { get; set; }

        public DateTime PassWordResetExpires { get; set; }

        public DateTime PassWordResetCreated { get; set; }        

        public string? ProfilePicture { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
