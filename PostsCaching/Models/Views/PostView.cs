namespace PostsCaching.Models.Views
{
    public record PostView(
        int Id,
        string Title,
        string Description,
        string Author,
        string Content,
        DateTime CreationDate
    ) : IPost;
}