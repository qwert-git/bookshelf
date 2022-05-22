namespace Bookshelf.Domain;

public class BookAdvert
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<string> PhotoLinks { get; set; } = Array.Empty<string>();

    public BookAdvertStatus Status { get; set; }
}