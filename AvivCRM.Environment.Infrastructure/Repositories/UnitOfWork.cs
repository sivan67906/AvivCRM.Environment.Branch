using AvivCRM.Environment.Domain.Contracts;
using AvivCRM.Environment.Infrastructure.Persistence;

namespace AvivCRM.Environment.Infrastructure.Repositories;

public class UnitOfWork(EnvironmentDbContext context) : IUnitOfWork
{
    private readonly EnvironmentDbContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}