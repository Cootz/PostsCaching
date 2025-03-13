using Microsoft.AspNetCore.Mvc;
using PostsCaching.Models.Dtos;
using PostsCaching.Services;

namespace PostsCaching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService) => this.postsService = postsService;

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentPosts()
        {
            try
            {
                return Ok(await postsService.GetRecentPosts());
            }
            catch (Exception ex)
            {
                var errorResponce = new { Code = 500, ErrorMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponce);
            }
        }

        [HttpGet("byId")]
        public async Task<IActionResult> GetPostById([FromQuery] int id)
        {
            try
            {
                return Ok(await postsService.GetPostByIdAsync(id));
            }
            catch (Exception ex)
            {
                var errorResponce = new { Code = 500, ErrorMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponce);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostDto post)
        {
            try
            {
                await postsService.AddPostAsync(post);
            }
            catch (Exception ex)
            {
                var errorResponce = new { Code = 500, ErrorMessage = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponce);
            }

            return Ok();
        }
    }
}
