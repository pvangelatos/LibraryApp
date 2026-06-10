using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Book
{
    public record BookResponseDto(int Id, string Title, string Author, string? ISBN, bool IsAvailable);
    
}
