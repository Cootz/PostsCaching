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
        }

        public Task DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public PostView GetPostById(int id) => _repository.GetPostById(id).ToView();

        public Task<IEnumerable<ShortPostView>> GetRecentPosts() => _repository.GetRecentPostsAsync();
    }
}
