using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvivCRM.Environment.Infrastructure.Persistence;

public class EnvironmentDbContext(DbContextOptions<EnvironmentDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
    //public DbSet<LeadCategory> LeadCategories { get; set; }
    public DbSet<LeadSource> LeadSources { get; set; }
}