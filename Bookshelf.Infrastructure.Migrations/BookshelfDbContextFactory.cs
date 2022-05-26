using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bookshelf.Infrastructure.Persistence
{
    internal class BookshelfDbContextFactory : IDesignTimeDbContextFactory<BookshelfDbContext>
    {
        public BookshelfDbContext CreateDbContext(string[] args)
        {
            // TODO: Add environment base config
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("BookshelfDb");

            var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();
            optionsBuilder.UseMySql(
                connectionString, 
                new MySqlServerVersion(new Version(8, 0, 29)), 
                b => 
                { 
                    b.MigrationsAssembly("Bookshelf.Infrastructure.Migrations"); 
                    b.EnableRetryOnFailure(3);
                });

            return new BookshelfDbContext(optionsBuilder.Options);
        }
    }
}