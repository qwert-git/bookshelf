using Bookshelf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Infrastructure.DI
{
    public static class DependecyRegistrant
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            const string connectionString = "server=localhost;port=3306;database=bookshelf;uid=user1;password=pswrd";
            var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();
            
            return services
                .AddDbContext<BookshelfDbContext>(options =>
                {
                    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)));
                });
        }
    }
}