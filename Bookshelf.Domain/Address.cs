namespace Bookshelf.Domain;

public record Address
{
    public int Id { get; set; }

    public string City { get; set; } = string.Empty;

    public string AddressLine { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
}