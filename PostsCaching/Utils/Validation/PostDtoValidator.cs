using FluentValidation;
using PostsCaching.Models.Dtos;

namespace PostsCaching.Utils.Validation
{
    public class PostDtoValidator : AbstractValidator<PostDto>
    {
        public PostDtoValidator()
        {
            RuleFor(post => post.Author).NotEmpty();
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
            RuleFor(post => post.Content).NotEmpty();
        }
    }
}
