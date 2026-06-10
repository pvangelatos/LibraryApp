using LibraryApp.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberResponseDto>> GetAllAsync();
        Task<MemberResponseDto?> GetByIdAsync(int id);
        Task<MemberResponseDto> CreateAsync(MemberCreateDto memberCreateDto);
        Task<MemberResponseDto> UpdateAsync(int id, MemberCreateDto memberCreateDto);
        Task<bool> DeleteAsync(int id);
    }
}
