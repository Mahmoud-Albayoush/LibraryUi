using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Interfaces;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBooksByCategorieQueryHandler : IRequestHandler<GetBooksByCategorieQuery, List<GetBooksByCategorieQueryViewModel>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBooksByCategorieQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetBooksByCategorieQueryViewModel>> Handle(GetBooksByCategorieQuery request, CancellationToken cancellationToken)
    {
        var books = await _context.Books.Where(bok => bok.Categories.Contains(request.Categorie)).ToListAsync();

        var result = _mapper.Map<List<GetBooksByCategorieQueryViewModel>>(books);

        return result;
    }
}
