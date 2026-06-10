using AutoMapper;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.DTOs.Loan;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public LoanService(IBookRepository bookRepository, IMemberRepository memberRepository, ILoanRepository loanRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<LoanResponseDto> CreateLoanAsync(LoanCreateDto loanCreateDto)
        {
            var book = await _bookRepository.GetByIdAsync(loanCreateDto.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {loanCreateDto.BookId} not found.");
            }
            if (!book.IsAvailable)
            {
                throw new InvalidOperationException("Book is not available for loan.");
            }
            var member = await _memberRepository.GetByIdAsync(loanCreateDto.MemberId);
            if (member == null)
            {
                throw new KeyNotFoundException($"Member with id {loanCreateDto.MemberId} not found.");
            }
            if (member.IsActive == false)
            {
                throw new InvalidOperationException("Member is not active.");
            }
            var loan = new Loan
            {
                BookId = loanCreateDto.BookId,
                MemberId = loanCreateDto.MemberId,
                LoanDate = DateTime.UtcNow,
                IsReturned = false
            };
            book.IsAvailable = false;
            _bookRepository.Update(book);
            await _loanRepository.AddAsync(loan);
            await _loanRepository.SaveChangesAsync();
            return _mapper.Map<LoanResponseDto>(loan);
        }

        public async Task<IEnumerable<LoanResponseDto>> GetAllAsync()
        {
            var loans = await _loanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanResponseDto>>(loans);
        }

        public async Task<LoanResponseDto?> GetByIdAsync(int id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            return loan == null ? null : _mapper.Map<LoanResponseDto>(loan);
        }

        public async Task<IEnumerable<LoanResponseDto>> GetByMemberIdAsync(int memberId)
        {
            var loans = await _loanRepository.GetByMemberIdAsync(memberId);
            return _mapper.Map<IEnumerable<LoanResponseDto>>(loans);
        }

        public async Task<LoanResponseDto> ReturnBookAsync(int loanId)
        {
            var loan = await _loanRepository.GetByIdAsync(loanId);

            if (loan == null)
            {
                throw new KeyNotFoundException($"Loan with id {loanId} not found.");
            }

            if (loan.IsReturned)
            {
                throw new InvalidOperationException("Book has already been returned.");
            }
            var book = await _bookRepository.GetByIdAsync(loan.BookId);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {loan.BookId} not found.");
            }
            loan.IsReturned = true;
            loan.ReturnDate = DateTime.UtcNow;
            book.IsAvailable = true;
            _bookRepository.Update(book);
            _loanRepository.Update(loan);
            await _loanRepository.SaveChangesAsync();
            return _mapper.Map<LoanResponseDto>(loan);
        }
    }
}
