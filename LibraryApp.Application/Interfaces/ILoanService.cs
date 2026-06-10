using LibraryApp.Application.DTOs.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanResponseDto>> GetAllAsync();
        Task<LoanResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<LoanResponseDto>> GetByMemberIdAsync(int memberId);
        Task<LoanResponseDto> CreateLoanAsync(LoanCreateDto loanCreateDto);
        Task<LoanResponseDto> ReturnBookAsync(int loanId);
    }
}
