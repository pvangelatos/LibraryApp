using AutoMapper;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<Book, BookResponseDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
