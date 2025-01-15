using AvivCRM.Environment.Domain.Entities.Project;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Project;
public class ProjectCategoryConfiguration
    : BaseEntityConfiguration<ProjectCategory>, IEntityTypeConfiguration<ProjectCategory>
{
    public void Configure(EntityTypeBuilder<ProjectCategory> builder)
    {
        // Table name
        builder.ToTable("tblProjectCategory");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
