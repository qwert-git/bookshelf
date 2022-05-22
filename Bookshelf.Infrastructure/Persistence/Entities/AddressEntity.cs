using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Infrastructure.Persistence.Entities;

[Table("Addresses")]
internal class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string City { get; set; } = string.Empty;

    public string AddressLine { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;
}