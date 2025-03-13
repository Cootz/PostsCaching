using Microsoft.EntityFrameworkCore;
using PostsCaching.Models.Db;

namespace PostsCaching.Database
{
    public class PostsDbContext(DbContextOptions<PostsDbContext> contextOptions) : DbContext(contextOptions)
    {
        public required DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(post => post.CreationDate)
                .HasDefaultValueSql("now()");

            modelBuilder.Entity<Post>()
                .Property(post => post.LastUpdated)
                .ValueGeneratedOnUpdate();

            base.OnModelCreating(modelBuilder);
        }
    }
}
