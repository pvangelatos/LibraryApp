using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllAsync();
        Task<Member?> GetByIdAsync(int id);
        Task AddAsync(Member member);
        void Update(Member member);
        void Delete(Member member);
        Task<bool> SaveChangesAsync();
    }
}
