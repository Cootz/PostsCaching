using PostsCaching.Models;
using PostsCaching.Models.Db;
using PostsCaching.Models.Dtos;
using PostsCaching.Models.Views;

namespace PostsCaching.Utils.Extensions
{
    public static class PostExtensions
    {
        public static Post ToDb(this PostDto post) => new Post
        {
            Id = post.Id,
            Author = post.Author,
            Title = post.Title,
            Description = post.Description,
            Content = post.Content,
        };

        public static PostView ToView(this Post post) => new PostView(
            Id: post.Id,
            Author: post.Author,
            Title: post.Title,
            Description: post.Description,
            Content: post.Content,
            CreationDate: post.CreationDate
        );

        public static ShortPostView ToShortView(this Post post) => new(
            Id: post.Id, 
            Author: post.Author, 
            Description: post.Description, 
            CreationDate: post.CreationDate
        );
    }
}
