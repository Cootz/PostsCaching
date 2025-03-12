namespace PostsCaching.Models.Views
{
    public record ShortPostView(
        int Id,
        string Author,
        string Description,
        DateTime CreationDate
    );
}