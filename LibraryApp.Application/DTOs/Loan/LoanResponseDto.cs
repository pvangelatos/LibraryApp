using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Loan
{
    public record LoanResponseDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }
    }
}
