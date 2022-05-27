using AutoFixture;
using Bookshelf.Infrastructure.Persistence;
using Bookshelf.Infrastructure.Persistence.Entities;
using Bookshelf.Infrastructure.Persistence.Enums;

namespace Bookshelf.Infrastructure.Migrations.Seed
{
    internal static class SeedManager
    {
        public static async Task SeedAsync(BookshelfDbContext dbContext)
        {
            var fixture = new Fixture();

            // Seed BookAdverts
            var bookAdverts = fixture
                .Build<BookAdvertEntity>()
                .With(b => b.Status, (int)BookAdvertStatus.Open)
                .CreateMany<BookAdvertEntity>();

            await dbContext.BookAdverts.AddRangeAsync(bookAdverts);

            // Seed Users
            var users = fixture.CreateMany<BookshelfUserEntity>();
            await dbContext.Users.AddRangeAsync(users);

            await dbContext.SaveChangesAsync();
        }
    }
}