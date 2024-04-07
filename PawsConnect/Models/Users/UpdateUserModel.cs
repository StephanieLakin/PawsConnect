namespace PawsConnect.Models.Users
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid? PasswordResetId { get; set; }

        public DateTime PassWordResetCreated { get; set; }

        public string? ProfilePicture { get; set; }
    }
}
