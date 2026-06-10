using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.DTOs.Member
{
    public record MemberResponseDto(int Id, string FirstName, string LastName, string Email, string? Phone, bool IsActive);
}
