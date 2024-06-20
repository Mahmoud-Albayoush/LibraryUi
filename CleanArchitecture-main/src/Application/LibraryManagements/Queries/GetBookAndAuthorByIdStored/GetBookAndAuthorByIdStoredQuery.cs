using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBookAndAuthorByIdStoredQuery : IRequest<List<GetBookAndAuthorByIdStoredQueryViewModel>>
{
    public Guid Id { get; set; }
}
