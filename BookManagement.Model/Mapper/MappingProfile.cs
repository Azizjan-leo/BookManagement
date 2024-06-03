using AutoMapper;
using BookManagement.Infrastructure.Models;
using BookManagement.Model.Entities;

namespace BookManagement.Model.Mapper;
public sealed class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<AuthorModel, Author>().ReverseMap();
        CreateMap<BookModel, Book>().ReverseMap();
        CreateMap<GenreModel, Genre>().ReverseMap();
        CreateMap<Book, PutBookModel>().ReverseMap();
    }
}
