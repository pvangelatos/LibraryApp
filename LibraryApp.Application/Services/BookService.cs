using AutoMapper;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<BookResponseDto> CreateAsync(BookCreateDto bookCreateDto)
        {
            var book = _mapper.Map<Book>(bookCreateDto);
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();
            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }
            _bookRepository.Delete(book);
            await _bookRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookResponseDto>>(books);
        }

        public async Task<BookResponseDto?> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book == null ? null : _mapper.Map<BookResponseDto>(book);
        }

        public async Task<BookResponseDto> UpdateAsync(int id, BookCreateDto bookCreateDto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Book with id {id} not found.");
            }
            _mapper.Map(bookCreateDto, existingBook);
            _bookRepository.Update(existingBook);
            await _bookRepository.SaveChangesAsync();
            return _mapper.Map<BookResponseDto>(existingBook);

        }
    }
}
