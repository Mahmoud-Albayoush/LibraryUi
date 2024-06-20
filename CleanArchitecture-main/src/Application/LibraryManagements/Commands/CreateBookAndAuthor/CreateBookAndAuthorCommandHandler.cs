using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Models;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.LibraryManagements;
public class CreateBookAndAuthorCommandHandler : IRequestHandler<CreateBookAndAuthorCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookAndAuthorCommandHandler(IApplicationDbContext context , IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<string>> Handle(CreateBookAndAuthorCommand request, CancellationToken cancellationToken)
    {
        var errorList = new List<string>();

        if (request == null)
        {
            errorList.Add("Object is null");
            return Result<string>.Failure(errorList, null);
        }

        var author = _mapper.Map<Author>(request);

        _context.Authors.Add(author);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(author.Id.ToString());
    }
}
