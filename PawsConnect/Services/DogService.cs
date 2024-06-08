using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.Dog;
using PawsConnectData.Data;
using PawsConnectData.Entities;

namespace PawsConnect.Services
{
    public interface IDogService
    {
        Task<DogModel[]> GetDogs();

        Task<DogModel> GetDogById(Guid dogId);

        Task CreateDog(CreateDogModel dogPost);

        Task EditDog(UpdateDogModel UpdatedPost);

        Task DeleteDog(Guid dogId);
    }
    public class DogService : BaseService, IDogService
    {
        public DogService(PawsConnectContext PcContext) : base(PcContext)
        {
        }

        public async Task<DogModel[]> GetDogs()
        {
            DogModel[] dogs = { };

            dogs = await _pcContext.Dogs
                .Select(d => new DogModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Breed = d.Breed,
                    Gender = d.Gender,
                    Weight = d.Weight,
                    DateOfBirth = d.DateOfBirth,
                    MedicalHistory = d.MedicalHistory,
                    Allergies = d.Allergies,
                    CreatedDate = d.CreatedDate,
                    UserId = d.UserId, 
                    Bio = d.Bio,
                    ImageUrl1 = d.ImageUrl1,
                    ImageUrl2 = d.ImageUrl2,
                    ImageUrl3 = d.ImageUrl3

                }).ToArrayAsync();
            return dogs;
        }

        public async Task<DogModel> GetDogById(Guid dogId)
        {
            var dog = await _pcContext.Dogs
                .FirstOrDefaultAsync(d => d.Id == dogId);

            if (dog == null)
            {
                return null;
            }

            var dogModel = new DogModel
            {
                Id = dog.Id,
                Name = dog.Name,
                Breed = dog.Breed,
                Gender = dog.Gender,
                Weight = dog.Weight,
                DateOfBirth = dog.DateOfBirth,
                MedicalHistory = dog.MedicalHistory,
                Allergies = dog.Allergies,
                CreatedDate = dog.CreatedDate,
                UserId = dog.UserId,
                Bio = dog.Bio,
                ImageUrl1 = dog.ImageUrl1,
                ImageUrl2 = dog.ImageUrl2,
                ImageUrl3 = dog.ImageUrl3
            };
            return dogModel;
        }

     

        public async Task CreateDog(CreateDogModel dog)
        {
            var user = await _pcContext.Users.FindAsync(dog.UserId);
            if (user == null)
            {
                throw new Exception($"User ID {dog.UserId} does not exist");
            }

            Dog doggy = new Dog
            {
                Id = Guid.NewGuid(),
                Name = dog.Name,
                Breed = dog.Breed,
                Description = dog.Description,
                Gender = dog.Gender,
                Weight = dog.Weight,
                DateOfBirth = dog.DateOfBirth,
                MedicalHistory = dog.MedicalHistory,
                Allergies = dog.Allergies,
                CreatedDate = DateTime.UtcNow,
                Bio = dog.Bio,
                ImageUrl1 = dog.ImageUrl1,
                ImageUrl2 = dog.ImageUrl2,
                ImageUrl3 = dog.ImageUrl3,
                UserId = dog.UserId
            };

            _pcContext.Dogs.Add(doggy);
            await _pcContext.SaveChangesAsync();
        }


        public async Task EditDog(UpdateDogModel dog)
        {
            var doggy = await _pcContext.Dogs.FirstOrDefaultAsync(doggy => doggy.Id == dog.Id);
            if (doggy == null)
            {
                return;
            }

            doggy.Name = dog.Name;
            doggy.Breed = dog.Breed;
            doggy.Description = dog.Description;
            doggy.Gender = dog.Gender;
            doggy.Weight = dog.Weight;
            doggy.DateOfBirth = dog.DateOfBirth;
            doggy.MedicalHistory = dog.MedicalHistory;
            doggy.Allergies = dog.Allergies;
            doggy.UserId = dog.UserId;
            doggy.Bio = dog.Bio;
            doggy.ImageUrl1 = dog.ImageUrl1;
            doggy.ImageUrl2 = dog.ImageUrl2;
            doggy.ImageUrl3 = dog.ImageUrl3;

            await _pcContext.SaveChangesAsync();
        }

        public async Task DeleteDog(Guid dogId)
        {
            var doggy = await _pcContext.Dogs.FirstOrDefaultAsync(d => d.Id == dogId);
            if (doggy == null)
            {
                return;
            }

            _pcContext.Dogs.Remove(doggy);
            await _pcContext.SaveChangesAsync();
        }
    }

}
