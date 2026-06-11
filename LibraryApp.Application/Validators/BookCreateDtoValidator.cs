using FluentValidation;
using LibraryApp.Application.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LibraryApp.Application.Validators
{
    public class BookCreateDtoValidator : AbstractValidator<BookCreateDto>
    {
        public BookCreateDtoValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required")
                .MaximumLength(200).WithMessage("Maximum 200 characters");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("The author is required")
                .MaximumLength(100).WithMessage("Maximum 100 characters");

            RuleFor(x => x.ISBN)
                .MaximumLength(20).WithMessage("Maximum 20 characters")
                .When(x => x.ISBN != null);

        }
    }
}
