using AutoMapper;
using LibraryApp.Application.DTOs.Member;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        {
            CreateMap<Member, MemberResponseDto>();
            CreateMap<MemberCreateDto, Member>();
        }
    }
}
