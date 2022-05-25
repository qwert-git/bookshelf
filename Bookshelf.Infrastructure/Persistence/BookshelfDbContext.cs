using Bookshelf.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure.Persistence;

internal class BookshelfDbContext : DbContext
{
    public BookshelfDbContext(DbContextOptions<BookshelfDbContext> options) 
        : base(options) { }

    public DbSet<BookAdvertEntity> BookAdverts { get; set; }

    public DbSet<BookshelfUserEntity> Users { get; set; }
}
