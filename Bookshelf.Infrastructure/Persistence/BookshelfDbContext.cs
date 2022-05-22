using Bookshelf.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure.Persistence;

internal class BookshelfDbContext : DbContext
{
    public BookshelfDbContext(string connectionString) : base()
    {
        this.Database.SetConnectionString(connectionString);
    }

    public DbSet<BookAdvertEntity> BookAdverts { get; set; }

    public DbSet<BookshelfUserEntity> Users { get; set; }
}
