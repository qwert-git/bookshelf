using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Infrastructure.Persistence.Entities;

[Table("Users")]
internal class BookshelfUserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;


    public AddressEntity Address { get; set; } = new();
}