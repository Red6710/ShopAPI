using Microsoft.EntityFrameworkCore;

namespace ShopAPI.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
