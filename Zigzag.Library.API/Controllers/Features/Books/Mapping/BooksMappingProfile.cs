using AutoMapper;
using Zigzag.Library.API.Controllers.Features.Books.Dtos;
using Zigzag.Library.API.Model;

namespace Zigzag.Library.API.Controllers.Features.Books.Mapping;

public class BooksMappingProfile : Profile
{
    public BooksMappingProfile()
    {
        CreateMap<BookParamDto, Book>();
        CreateMap<Book, BooksDto>()
            .ForMember(d =>d.PublishedDate,
                opt => opt.MapFrom(b => DateOnly.FromDateTime(b.PublishedDate)));
    }
}
