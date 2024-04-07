using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.Users;
using PawsConnectData.Data;
using PawsConnectData.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography;

namespace PawsConnect.Services
{
    public interface IUserService
    {
        Task<UserModel[]> GetUsers();

        Task<UserModel?> GetUserById(Guid userId);

        Task CreateUser(CreateUserModel user);

        Task EditUser(UpdateUserModel userId);

        Task DeleteUser(Guid userId);

        Task Register(UserRegisterRequestModel request);

        Task Login(UserLoginRequest login);

        Task Verify(string token);

        Task PasswordForgot(string email);

        Task PasswordReset(ResetPasswordRequest request);
    }

    public class UserService : BaseService, IUserService
    {
        public UserService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<UserModel[]> GetUsers()
        {
            UserModel[] users = { };

            users = await _pcContext.Users
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    Email = u.Email,
                    ProfilePicture = u.ProfilePicture                   
                }).ToArrayAsync();

            return users;
        }


        public async Task<UserModel?> GetUserById(Guid userId)
        {
            var user = await _pcContext.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                ProfilePicture = user.ProfilePicture,
            };
            return userModel;
        }

        public async Task CreateUser(CreateUserModel user)
        {
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                ProfilePicture = user?.ProfilePicture,
            };
            _pcContext.Users.Add(newUser);
            await _pcContext.SaveChangesAsync();
        }

        public async Task EditUser(UpdateUserModel updatedUser)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(user => user.Id == updatedUser.Id);

            if (user == null)
            {
                return;
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.ProfilePicture = updatedUser.ProfilePicture;

            await _pcContext.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid userId)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(user => user.Id == userId);

            if (user == null)
            {
                return;
            }

            _pcContext.Users.Remove(user);
            await _pcContext.SaveChangesAsync();
        }

        public async Task Register(UserRegisterRequestModel request)
        {
            if (_pcContext.Users.Any(u => u.Email == request.Email))
            {
                throw new Exception("User Already Exists");
            }

            CreatePasswordHash(request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken(),
                Password = request.Password
            };
            _pcContext.Users.Add(user);
            await _pcContext.SaveChangesAsync();
        }

        public async Task Login(UserLoginRequest request)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Incorrect Password");
            }
            if (user.VerifiedAt == null)
            {
                throw new Exception("User not verified");
            }
        }


        public async Task Verify(string token)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (user == null)
            {
                throw new Exception("Invalid Token");
            }

            user.VerifiedAt = DateTime.UtcNow;
            await _pcContext.SaveChangesAsync();
        }

        public async Task PasswordForgot(string email)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            user.PasswordResetToken = CreateRandomToken();
            user.PassWordResetExpires = DateTime.UtcNow.AddDays(1);
            await _pcContext.SaveChangesAsync();
        }

        public async Task PasswordReset(ResetPasswordRequest request)
        {
            var user = await _pcContext.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);
            if (user == null || user.PassWordResetExpires < DateTime.UtcNow)
            {
                throw new Exception("Invalid Token");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.PassWordResetExpires = null;
            await _pcContext.SaveChangesAsync();
        }


        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {   
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
