using AutoMapper;
using Bookshelf.Domain;
using Bookshelf.Infrastructure.Persistence.Entities;

namespace Bookshelf.Infrastructure.Mapping;

public class BookAdvertEntityProfile : Profile
{
    public BookAdvertEntityProfile()
    {
        CreateMap<BookAdvertEntity, BookAdvert>()
            .ForMember(dest => dest.PhotoLinks, opt => opt.MapFrom(src => src.PhotoLinks.Select(p => p.Link)));
    }
}
