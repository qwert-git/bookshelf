namespace Bookshelf.Domain;

public class BookshelfUser
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Address Address { get; set; } = new ();
}