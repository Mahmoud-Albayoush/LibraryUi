using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.LibraryManagements.Queries;
public class GetBooksByCategorieQueryViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public string Categories { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Book, GetBooksByCategorieQueryViewModel>();
        }
    }
}
