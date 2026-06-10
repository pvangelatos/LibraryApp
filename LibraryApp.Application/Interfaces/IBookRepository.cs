using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task<bool> SaveChangesAsync();
    }
}
