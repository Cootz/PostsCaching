using PostsCaching.Models;
using PostsCaching.Models.Db;
using PostsCaching.Models.Dtos;
using PostsCaching.Models.Views;

namespace PostsCaching.Utils.Extensions
{
    public static class PostExtensions
    {
        public static Post ToDb(this PostDto post) => (Post)(IPost)post;

        public static PostView ToView(this Post post) => (PostView)(IPost)post;

        public static ShortPostView ToShortView(this Post post) => new(
            Id: post.Id, 
            Author: post.Author, 
            Description: post.Description, 
            CreationDate: post.CreationDate
        );
    }
}
