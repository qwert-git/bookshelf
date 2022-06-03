using Bookshelf.Domain;

namespace Bookshelf.Application.BookAdvertFeature;

public interface IBookAdvertReader
{
    Task<BookAdvert> Get(int id);

    Task<ICollection<BookAdvert>> GetAllAsync();
}