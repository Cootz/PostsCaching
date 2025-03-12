using PostsCaching.Models.Db;
using PostsCaching.Models.Views;

namespace PostsCaching.Repositories
{
    public interface IPostsRepository
    {
        Post GetPostById(int id);
        Task<IEnumerable<ShortPostView>> GetRecentPostsAsync();
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}