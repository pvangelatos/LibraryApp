using FluentValidation;
using LibraryApp.Application.DTOs.Member;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Validators
{
    public class MemberCreateDtoValidator : AbstractValidator<MemberCreateDto>
    {
        public MemberCreateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("The firstname is required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("The lastname is required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Maximum 100 characters");

            RuleFor(x => x.Phone)
                .MaximumLength(20).WithMessage("Maximum 20 characters")
                .When(x => x.Phone != null);
        }
    }
}
