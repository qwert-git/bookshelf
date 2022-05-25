using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bookshelf.Infrastructure.Persistence
{
    internal class BookshelfDbContextFactory : IDesignTimeDbContextFactory<BookshelfDbContext>
    {
        public BookshelfDbContext CreateDbContext(string[] args)
        {
            
            var connectionString = "server=localhost;port=3306;database=bookshelf;uid=root;password=my-secret-pw";

            var optionsBuilder = new DbContextOptionsBuilder<BookshelfDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 27)), b => b.MigrationsAssembly("Bookshelf.Infrastructure.Migrations"));

            return new BookshelfDbContext(optionsBuilder.Options);
        }
    }
}