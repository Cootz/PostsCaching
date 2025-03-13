using PostsCaching.Models.Db;

namespace PostsCaching.Repositories
{
    public interface IPostsRepository
    {
        Task<Post?> GetPostByIdAsync(int id);
        Task<IEnumerable<Post>> GetRecentPostsAsync();
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task SaveDbAsync();
    }
}