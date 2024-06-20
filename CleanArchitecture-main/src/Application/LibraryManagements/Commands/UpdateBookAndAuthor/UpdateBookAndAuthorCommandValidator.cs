using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.LibraryManagements;
public class UpdateBookAndAuthorCommandValidator : AbstractValidator<UpdateBookAndAuthorCommand>
{
    public UpdateBookAndAuthorCommandValidator()
    {
        RuleFor(x => x.Gender)
           .NotNull()
           .IsInEnum();

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();

        RuleForEach(x => x.Books).ChildRules(book =>
        {
            book.RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(12);
        });
    }
}
