using System.Security.Claims;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    public DbSet<Book> Books { get; }

    DbSet<Author> Authors { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
