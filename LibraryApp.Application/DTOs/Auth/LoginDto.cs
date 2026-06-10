using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Auth
{
    public record LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
