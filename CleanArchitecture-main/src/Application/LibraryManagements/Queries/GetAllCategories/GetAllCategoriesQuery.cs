using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetAllCategoriesQuery : IRequest<List<string>>
{
    public string? Id { get; set; }
}
