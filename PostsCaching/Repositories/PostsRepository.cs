using Microsoft.EntityFrameworkCore;
using PostsCaching.Database;
using PostsCaching.Models.Db;

namespace PostsCaching.Repositories
{
    public class PostsRepository(PostsDbContext dbContext) : IPostsRepository
    {
        private readonly PostsDbContext _dbContext = dbContext;

        public Task AddPostAsync(Post post) => _dbContext.AddAsync(post).AsTask();

        public Task DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetPostByIdAsync(int id) => _dbContext.Posts.FindAsync(id).AsTask();

        public async Task<IEnumerable<Post>> GetRecentPostsAsync() => await _dbContext.Posts.OrderByDescending(post => post.CreationDate).Take(10).ToListAsync();

        public Task SaveDbAsync() => _dbContext.SaveChangesAsync();

        public Task UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
