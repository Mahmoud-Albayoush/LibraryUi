using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Application.Common.Models;

namespace LibraryManagement.Application.LibraryManagements;
public class UpdateBookAndAuthorCommandHandler : IRequestHandler<UpdateBookAndAuthorCommand, Result<string>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateBookAndAuthorCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<string>> Handle(UpdateBookAndAuthorCommand request, CancellationToken cancellationToken)
    {
        var errorList = new List<string>();

        if (request == null)
        {
            errorList.Add("Object is null");
            return Result<string>.Failure(errorList, null);
        }

        var author = _context.Authors
                        .Include(x => x.Books)
                        .FirstOrDefault(x => x.Id == request.Id);

        if (author == null)
        {
            errorList.Add("This object does not exist in DB");
            return Result<string>.Failure(errorList, null);
        }

        _mapper.Map(request, author);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<string>.Success(author.Id.ToString());
    }
}
