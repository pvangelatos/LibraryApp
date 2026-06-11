using FluentValidation;
using LibraryApp.Application.DTOs.Loan;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Validators
{
    public class LoanCreateDtoValidator : AbstractValidator<LoanCreateDto>
    {

        public LoanCreateDtoValidator() 
        {
            RuleFor(x => x.BookId)
                .GreaterThan(0).WithMessage("BookId must be greater than 0");

            RuleFor(x => x.MemberId)
                .GreaterThan(0).WithMessage("MemberId must be greater than 0");
        }
    }
}
