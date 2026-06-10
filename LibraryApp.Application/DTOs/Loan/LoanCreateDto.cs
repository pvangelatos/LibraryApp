using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Loan
{
    public class LoanCreateDto
    {
        public int BookId { get; set; }

        public int MemberId { get; set; }
    }
}
