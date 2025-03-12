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
    }
}
