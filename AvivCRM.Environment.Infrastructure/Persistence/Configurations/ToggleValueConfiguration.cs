using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ToggleValueConfiguration
    : BaseEntityConfiguration<ToggleValue>, IEntityTypeConfiguration<ToggleValue>
{
    public void Configure(EntityTypeBuilder<ToggleValue> builder)
    {
        // Table name
        builder.ToTable("tblToggleValue");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.RecruitFooterSettings)
            .WithOne(b => b.ToggleValue)
            .HasForeignKey(b => b.StatusId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.RecruiterSettings)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.StatusId)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.RecruitCustomQuestionSettings)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.StatusId)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.TicketAgents)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.StatusId)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
