using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LibraryApp.Domain.Entities
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Collection<Loan> Loans { get; } = new Collection<Loan>();
    }
}
