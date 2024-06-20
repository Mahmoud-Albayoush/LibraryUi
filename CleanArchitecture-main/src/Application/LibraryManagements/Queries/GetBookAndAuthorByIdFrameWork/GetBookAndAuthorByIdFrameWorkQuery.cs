using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBookAndAuthorByIdFrameWorkQuery : IRequest<GetBookAndAuthorByIdFrameWorkViewModel>
{
    public Guid Id { get; set; }
}
