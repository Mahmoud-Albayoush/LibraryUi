using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBookAndAuthorByIdStoredQueryHandler : IRequestHandler<GetBookAndAuthorByIdStoredQuery, List<GetBookAndAuthorByIdStoredQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBookAndAuthorByIdStoredQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetBookAndAuthorByIdStoredQueryViewModel>> Handle(GetBookAndAuthorByIdStoredQuery request, CancellationToken cancellationToken)
    {
        var booksWithAuthors = await _context.Books
                    .FromSqlRaw("EXEC GetBooksWithAuthors")
                    .ToListAsync();


        var result = _mapper.Map<List<GetBookAndAuthorByIdStoredQueryViewModel>>(booksWithAuthors);

        return result;
    }
}
