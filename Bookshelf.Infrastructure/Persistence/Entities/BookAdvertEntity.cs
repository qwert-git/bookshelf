using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.Infrastructure.Persistence.Entities;

[Table("BookAdverts")]
internal class BookAdvertEntity
{
    [Key]
    public int Id { get; set; }

    [Required]    
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public ICollection<PhotoLinkEntity> PhotoLinks { get; set; } = Array.Empty<PhotoLinkEntity>();

    public int Status { get; set; }
}