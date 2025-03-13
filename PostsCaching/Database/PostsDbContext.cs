using Microsoft.EntityFrameworkCore;
using PostsCaching.Models.Db;

namespace PostsCaching.Database
{
    public class PostsDbContext(DbContextOptions<PostsDbContext> contextOptions) : DbContext(contextOptions)
    {
        public required DbSet<Post> Posts { get; set; }
    }
}
