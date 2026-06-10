using AutoMapper;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.DTOs.Member;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<MemberResponseDto> CreateAsync(MemberCreateDto memberCreateDto)
        {
            var member = _mapper.Map<Member>(memberCreateDto);
            await _memberRepository.AddAsync(member);
            await _memberRepository.SaveChangesAsync();
            return _mapper.Map<MemberResponseDto>(member);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                throw new KeyNotFoundException($"Member with id {id} not found.");
            }
            _memberRepository.Delete(member);
            await _memberRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MemberResponseDto>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MemberResponseDto>>(members);
        }

        public async Task<MemberResponseDto?> GetByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            return member == null ? null : _mapper.Map<MemberResponseDto>(member);
        }

        public async Task<MemberResponseDto> UpdateAsync(int id, MemberCreateDto memberCreateDto)
        {
            var existingMember = await _memberRepository.GetByIdAsync(id);
            if (existingMember == null)
            {
                throw new KeyNotFoundException($"Member with id {id} not found.");
            }
            _mapper.Map(memberCreateDto, existingMember);
            _memberRepository.Update(existingMember);
            await _memberRepository.SaveChangesAsync();
            return _mapper.Map<MemberResponseDto>(existingMember);
        }
    }
}
