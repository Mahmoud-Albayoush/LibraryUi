using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Models;

namespace LibraryManagement.Application.LibraryManagements;
public class DeleteBookAndAuthorCommand : IRequest<Result<string>>
{
    public Guid Id { get; set; }
}
