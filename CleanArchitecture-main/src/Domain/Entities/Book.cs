using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities;
public class Book : BaseAuditableEntity
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public string Categories { get; set; } = string.Empty;
    public virtual Author? Author { get; set; }
}
