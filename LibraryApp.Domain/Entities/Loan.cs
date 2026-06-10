using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public Book Book { get; set; } = null!;
        public Member Member { get; set; } = null!;

    }
}
