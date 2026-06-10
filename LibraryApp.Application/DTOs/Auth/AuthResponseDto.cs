using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Auth
{
    public record AuthResponseDto(string Username, string Email, string Token);
    
}
