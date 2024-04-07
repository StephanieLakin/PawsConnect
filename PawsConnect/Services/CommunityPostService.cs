using Microsoft.EntityFrameworkCore;
using PawsConnect.Models.CommunityPost;
using PawsConnectData.Data;
using PawsConnectData.Entities;

namespace PawsConnect.Services
{
    public interface ICommunityPostService
    {
        Task<CommunityPostModel[]> GetCommunityPosts();

        Task<CommunityPostModel> GetCommunityPostById(Guid communityPostId);

        Task CreateCommunityPost(CreateCommunityPostModel communityPostPost);

        Task EditCommunityPost(UpdateCommunityPostModel communityPostId);

        Task DeleteCommunityPost(Guid communityPostId);

    }
    public class CommunityPostService : BaseService, ICommunityPostService
    {
        public CommunityPostService(PawsConnectContext PcContext) : base(PcContext)
        {
            
        }

        public async Task<CommunityPostModel[]> GetCommunityPosts()
        {
            CommunityPostModel[] communityPosts = { };

            communityPosts = await _pcContext.CommunityPosts
                .Select(cp => new CommunityPostModel
                {
                    Id = cp.Id,
                    Content = cp.Content,
                    DateTimePosted = cp.DateTimePosted,
                    Image = cp.Image,
                    UserId = cp.UserId,
                }).ToArrayAsync();
            return communityPosts;
        }

        public async Task<CommunityPostModel> GetCommunityPostById(Guid communityPostId)
        {
            var communityPost = await _pcContext.CommunityPosts
                .FirstOrDefaultAsync(cp => cp.Id == communityPostId);

            if (communityPost == null)
            {
                return null;
            }

            var communityPostModel = new CommunityPostModel
            {
                Id = communityPostId,
                Content = communityPost.Content,
                DateTimePosted = communityPost.DateTimePosted,
                Image = communityPost.Image,
                UserId = communityPost.UserId,
            };
            return communityPostModel;
        }

        public async Task CreateCommunityPost(CreateCommunityPostModel communityPost)
        {
            CommunityPost post = new CommunityPost
            {
                Id = Guid.NewGuid(),
                Content = communityPost.Content,
                DateTimePosted =  DateTime.UtcNow,
                Image = communityPost.Image,
                UserId = communityPost.UserId
            };
            _pcContext.CommunityPosts.Add(post);
            await _pcContext.SaveChangesAsync();                
        }

        public Task EditCommunityPost(UpdateCommunityPostModel communityPostId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCommunityPost(Guid communityPostId)
        {
            throw new NotImplementedException();
        }

    

      
    }
}
