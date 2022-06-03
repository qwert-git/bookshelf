using Bookshelf.Application.BookAdvertFeature;
using Bookshelf.Infrastructure.Mapping;
using Bookshelf.Infrastructure.Persistence;
using Bookshelf.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookshelf.Infrastructure.DI;

public static class DependecyRegistrant
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // TODO: Move connection string to the configuration files.
        const string connectionString = "server=localhost;port=5433;database=bookshelf;uid=root;password=pswrd";
        var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();

        services.AddAutoMapper(typeof(BookAdvertEntityProfile).Assembly);

        return services
            .AddDbContext<BookshelfDbContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)));
            });
    }

    public static IServiceCollection AddDataReaders(this IServiceCollection services)
    {
        return services
            .AddScoped<IBookAdvertReader, BookAdvertRepository>();
    }
}