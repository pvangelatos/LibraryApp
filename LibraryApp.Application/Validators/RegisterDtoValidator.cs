using FluentValidation;
using LibraryApp.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("The username is required")
                .MaximumLength(50).WithMessage("Maximum 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Maximum 100 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password is required")
                .MinimumLength(6).WithMessage("Minimum 6 characters");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0");
        }
    }
}
