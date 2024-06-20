using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Common.Models;
using LibraryManagement.Application.LibraryManagements.Models;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;

namespace LibraryManagement.Application.LibraryManagements;
public class CreateBookAndAuthorCommand : IRequest<Result<string>>
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string? Achievements { get; set; }
    public IList<BookDto> Books { get; set; } = new List<BookDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateBookAndAuthorCommand, Author>();
        }
    }
}
