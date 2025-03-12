namespace PostsCaching.Models
{
    public interface IPost
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
        string Author { get; }
        string Content { get; }
    }
}
