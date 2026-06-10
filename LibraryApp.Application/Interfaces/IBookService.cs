using LibraryApp.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetAllAsync();
        Task<BookResponseDto?> GetByIdAsync(int id);
        Task<BookResponseDto> CreateAsync(BookCreateDto bookCreateDto);
        Task<BookResponseDto> UpdateAsync(int id, BookCreateDto bookCreateDto);
        Task<bool> DeleteAsync(int id);
    }
}
