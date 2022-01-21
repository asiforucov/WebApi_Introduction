using FluentValidation;
using Library.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Validators.Book
{
    public class BookPostDtoValidator: AbstractValidator<BookPostDto>
    {
        public BookPostDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Ad bos olmalidir")
               .MaximumLength(60)
               .WithMessage("simvol sayisi 60 dan cox olmamalidir");
            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("qiymet bos olmalidir");
        }
    }
}
