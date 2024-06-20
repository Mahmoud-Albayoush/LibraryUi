using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Models;

namespace LibraryManagement.Application.LibraryManagements;
public class DeleteBookAndAuthorCommandHandler : IRequestHandler<DeleteBookAndAuthorCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;

    public DeleteBookAndAuthorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<string>> Handle(DeleteBookAndAuthorCommand request, CancellationToken cancellationToken)
    {
        var errorList = new List<string>();

        var author = _context.Authors
                        .Include(x => x.Books)
                        .FirstOrDefault(x => x.Id == request.Id);

        if (author == null)
        {
            errorList.Add("This object does not exist in DB");
            return Result<string>.Failure(errorList, null);
        }

        _context.Authors.Remove(author);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success("Author deleted");
    }
}
