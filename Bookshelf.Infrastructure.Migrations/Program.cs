using Bookshelf.Infrastructure.Migrations.Seed;
using Bookshelf.Infrastructure.Persistence;

Console.WriteLine("Program started");

var factory = new BookshelfDbContextFactory();
using var dbContext = factory.CreateDbContext(args: Array.Empty<string>());

Console.WriteLine("Ensure database was created...");
await dbContext.Database.EnsureCreatedAsync();

if(!dbContext.BookAdverts.Any())
{
    Console.WriteLine("Seed data to the database...");
    await SeedManager.SeedAsync(dbContext);
}

Console.WriteLine("Program has been finished.");