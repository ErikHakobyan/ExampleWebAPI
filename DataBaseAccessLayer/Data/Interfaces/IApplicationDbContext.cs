using Microsoft.EntityFrameworkCore;

namespace DataBaseAccessLayer.Data.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

