using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Project;

public class ProjectStatusConfiguration
    : BaseEntityConfiguration<ProjectStatus>, IEntityTypeConfiguration<ProjectStatus>
{
    public void Configure(EntityTypeBuilder<ProjectStatus> builder)
    {
        // Table name
        builder.ToTable("tblProjectStatus");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.ColorCode)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(p => p.IsDefaultStatus)
            .HasDefaultValue(true);
        builder.Property(p => p.Status)
            .HasDefaultValue(true);
    }
}
