using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class JobApplicationPositionConfiguration
    : BaseEntityConfiguration<JobApplicationPosition>, IEntityTypeConfiguration<JobApplicationPosition>
{
    public void Configure(EntityTypeBuilder<JobApplicationPosition> builder)
    {
        // Table name
        builder.ToTable("tblJobApplicationPosition");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.RecruitJobApplicationStatusSettings)
            .WithOne(b => b.JobApplicationPosition)
            .HasForeignKey(b => b.PositionId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
