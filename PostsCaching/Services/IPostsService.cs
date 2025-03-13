using PostsCaching.Models.Dtos;
using PostsCaching.Models.Views;

namespace PostsCaching.Services
{
    public interface IPostsService
    {
        Task AddPostAsync(PostDto post);
        Task DeletePostAsync(int id);
        Task<PostView> GetPostByIdAsync(int id);
        Task<IEnumerable<ShortPostView>> GetRecentPosts();
    }
}