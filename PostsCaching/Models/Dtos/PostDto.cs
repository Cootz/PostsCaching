using System.Text.Json.Serialization;

namespace PostsCaching.Models.Dtos
{
    public record PostDto(
        [property: JsonIgnore] int Id, // We ignore ID as it will be generated automatically by DB
        string Title,
        string Description,
        string Author,
        string Content
    ) : IPost;
}