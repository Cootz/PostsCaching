using FluentValidation;
using PostsCaching.Models.Db;
using PostsCaching.Models.Dtos;
using PostsCaching.Models.Views;
using PostsCaching.Repositories;
using PostsCaching.Utils.Extensions;

namespace PostsCaching.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _repository;
        private readonly IValidator<PostDto> _validator;

        public PostsService(IPostsRepository repository, IValidator<PostDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task AddPostAsync(PostDto post)
        {
            await _validator.ValidateAndThrowAsync(post);

            await _repository.AddPostAsync(post.ToDb());
            await _repository.SaveDbAsync();
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
            IEnumerable<Post> posts = await _repository.GetRecentPostsAsync();

            return posts.Select(post => post.ToShortView());
        }
    }
}
