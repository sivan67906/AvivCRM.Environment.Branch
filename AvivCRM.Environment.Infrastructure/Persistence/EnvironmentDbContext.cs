using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvivCRM.Environment.Infrastructure.Persistence;

public class EnvironmentDbContext(DbContextOptions<EnvironmentDbContext> options)
    : DbContext(options)
{
    public DbSet<LeadSource> LeadSources => Set<LeadSource>();
    public DbSet<ProjectCategory> ProjectCategories => Set<ProjectCategory>();
    public DbSet<LeadStatus> LeadStatuss => Set<LeadStatus>();
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<LeadAgent> LeadAgents => Set<LeadAgent>();
    public DbSet<LeadCategory> LeadCategories => Set<LeadCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("aiv");

        modelBuilder.Entity<LeadSource>().ToTable("tblLeadSource");
        modelBuilder.Entity<ProjectCategory>().ToTable("tblProjectCategory");
        modelBuilder.Entity<LeadStatus>().ToTable("tblLeadStatus");
        modelBuilder.Entity<Contract>().ToTable("tblContract");
        modelBuilder.Entity<LeadAgent>().ToTable("tblLeadAgent");
        modelBuilder.Entity<LeadCategory>().ToTable("tblLeadCategory");
    }

}