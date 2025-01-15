#region

using AvivCRM.Environment.Application.Contracts;
using AvivCRM.Environment.Infrastructure.Persistence.Data;

#endregion

namespace AvivCRM.Environment.Infrastructure.Repositories.Common;
public class UnitOfWork(EnvironmentDbContext context) : IUnitOfWork
{
    private readonly EnvironmentDbContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}