using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using PostsCaching.Models.Db;
using PostsCaching.Models.Dtos;
using PostsCaching.Models.Views;
using PostsCaching.Repositories;
using PostsCaching.Services.Caching;
using PostsCaching.Utils.Extensions;
using System.Collections.Generic;

namespace PostsCaching.Services
{
    public class PostsService : IPostsService
    {
        private const string RecentPostsCacheKey = "recent_posts";

        private readonly IPostsRepository _repository;
        private readonly IValidator<PostDto> _validator;
        private readonly IRedisCacheService _cache;

        public PostsService(IPostsRepository repository, IValidator<PostDto> validator, IRedisCacheService cache)
        {
            _repository = repository;
            _validator = validator;
            _cache = cache;
        }

        public async Task AddPostAsync(PostDto post)
        {
            await _validator.ValidateAndThrowAsync(post);

            await _repository.AddPostAsync(post.ToDb());
            await _repository.SaveDbAsync();

            await _cache.InvalidateAsync(RecentPostsCacheKey);
        }

        public Task DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PostView> GetPostByIdAsync(int id)
        {
            Post? post = await _repository.GetPostByIdAsync(id) ?? throw new Exception($"Post with id {id} is not found");

            return post.ToView();
        }

        public async Task<IEnumerable<ShortPostView>> GetRecentPosts()
        {
            IEnumerable<ShortPostView>? posts = await _cache.GetDataAsync<IEnumerable<ShortPostView>>(RecentPostsCacheKey);

            if (posts is not null)
            {
                return posts;
            }

            IEnumerable<Post> dbPosts = await _repository.GetRecentPostsAsync();

            posts = dbPosts.Select(post => post.ToShortView()).ToArray();

            await _cache.SetDataAsync(RecentPostsCacheKey, posts);

            return posts;
        }
    }
}
