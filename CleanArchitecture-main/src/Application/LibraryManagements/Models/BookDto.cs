using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.LibraryManagements.Models;
public class BookDto
{
    public string Title { get; set; } = string.Empty;
    public string Categories { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
