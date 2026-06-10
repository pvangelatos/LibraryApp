using AutoMapper;
using LibraryApp.Application.DTOs.Loan;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Mappings
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanResponseDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Member.FirstName + " " + src.Member.LastName));

            CreateMap<LoanCreateDto, Loan>();
        }
    }
}
