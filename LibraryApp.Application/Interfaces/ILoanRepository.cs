using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllAsync();
        Task<Loan?> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetByMemberIdAsync(int memberId);
        Task AddAsync(Loan loan);
        void Update(Loan loan);
        Task<bool> SaveChangesAsync();
    }
}
