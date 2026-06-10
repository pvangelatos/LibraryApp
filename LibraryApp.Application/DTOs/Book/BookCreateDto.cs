using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Book
{
    public class BookCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? ISBN { get; set; }
    }
}
