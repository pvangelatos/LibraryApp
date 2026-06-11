using FluentValidation;
using LibraryApp.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("The username is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password is required");
        }
    }
}
