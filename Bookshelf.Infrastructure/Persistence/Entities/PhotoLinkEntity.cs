using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Infrastructure.Persistence.Entities;

[Table("PhotoLinks")]
internal class PhotoLinkEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Link { get; set; } = string.Empty;
}