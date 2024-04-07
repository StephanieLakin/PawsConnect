using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models.ActivityLog;
using PawsConnect.Models.CommunityPost;
using PawsConnect.Services;


namespace PawsConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityPostController : ControllerBase
    {
        private ICommunityPostService _communityPostService;

        public CommunityPostController(ICommunityPostService communityPostService)
        {
            _communityPostService = communityPostService;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetCommunityPosts()
        {
            try
            {
                var result = await _communityPostService.GetCommunityPosts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{communityPostId}")]
        public async Task<IActionResult> GetCommunityPostById(Guid communityPostId)
        {
            try
            {
                var result = await _communityPostService.GetCommunityPostById(communityPostId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> CreateCommunityPost([FromBody] CreateCommunityPostModel communityPost)
        {
            try
            {
                await _communityPostService.CreateCommunityPost(communityPost);
                return Ok(communityPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{communityPostId}")]
        public async Task<IActionResult> EditCommunityPost([FromBody] UpdateCommunityPostModel updatedCommunityPost)
        {
            try
            {
                await _communityPostService.EditCommunityPost(updatedCommunityPost);
                return Ok(updatedCommunityPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{communityPostId}")]
        public async Task<IActionResult> DeleteCommunityPost(Guid communityPostId)
        {
            try
            {
                await _communityPostService.DeleteCommunityPost(communityPostId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
