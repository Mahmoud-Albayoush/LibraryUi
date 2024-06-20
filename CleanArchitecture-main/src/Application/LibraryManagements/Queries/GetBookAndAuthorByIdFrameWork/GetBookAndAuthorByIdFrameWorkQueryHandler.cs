using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBookAndAuthorByIdFrameWorkQueryHandler : IRequestHandler<GetBookAndAuthorByIdFrameWorkQuery, GetBookAndAuthorByIdFrameWorkViewModel>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBookAndAuthorByIdFrameWorkQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetBookAndAuthorByIdFrameWorkViewModel> Handle(GetBookAndAuthorByIdFrameWorkQuery request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors
                        .Include(x => x.Books)
                        .FirstOrDefaultAsync(x => x.Id == request.Id);

        var result = _mapper.Map<GetBookAndAuthorByIdFrameWorkViewModel>(author);

        return result;
    }
}
