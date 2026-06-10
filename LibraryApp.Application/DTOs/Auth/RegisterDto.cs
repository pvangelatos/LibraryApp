using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Auth
{
    public record RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
    }
}
