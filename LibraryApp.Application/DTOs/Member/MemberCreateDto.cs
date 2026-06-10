using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Member
{
    public class MemberCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
