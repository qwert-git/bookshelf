using Bookshelf.Domain;

namespace Bookshelf.Application.BookAdvertFeature;

public interface IBookAdvertReader
{
    Task<BookAdvert> GetAsync(int id);

    Task<ICollection<BookAdvert>> GetAllAsync();
}