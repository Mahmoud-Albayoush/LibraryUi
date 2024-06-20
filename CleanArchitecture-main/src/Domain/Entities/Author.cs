using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities;
public class Author : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string? Achievements { get; set; }
    public IList<Book> Books { get; set; } = new List<Book>();
}
