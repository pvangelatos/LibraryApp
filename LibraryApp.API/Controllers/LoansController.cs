using LibraryApp.Application.DTOs.Loan;
using LibraryApp.Application.DTOs.Member;
using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }   

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            var loans = await _loanService.GetAllAsync();
            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _loanService.GetByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpGet("member/{memberId}")]
        public async Task<IActionResult> GetLoansByMemberId(int memberId)
        {
            var loans = await _loanService.GetByMemberIdAsync(memberId);
            return Ok(loans);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] LoanCreateDto loanCreateDto)
        {
            var createdLoan = await _loanService.CreateLoanAsync(loanCreateDto);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.Id }, createdLoan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var updatedLoan = await _loanService.ReturnBookAsync(id);
            return Ok(updatedLoan);
        }
    }
}
