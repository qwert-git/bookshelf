using AutoMapper;
using Bookshelf.Application.BookAdvertFeature;
using Bookshelf.Domain;
using Bookshelf.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Infrastructure.Repository;

internal class BookAdvertRepository : IBookAdvertReader
{
    private readonly BookshelfDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookAdvertRepository(BookshelfDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<BookAdvert> GetAsync(int id)
    {
        var entity = await _dbContext.BookAdverts
            .Include(b => b.PhotoLinks)
            .FirstOrDefaultAsync(b => b.Id == id);

        return _mapper.Map<BookAdvert>(entity);
    }

    public async Task<ICollection<BookAdvert>> GetAllAsync()
    {
        var allAdvertEntities = await _dbContext.BookAdverts
            .Include(b => b.PhotoLinks)
            .ToListAsync();

        return _mapper.Map<ICollection<BookAdvert>>(allAdvertEntities);
    }
}