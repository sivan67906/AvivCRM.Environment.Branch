using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class ToggleValueConfiguration
    : IEntityTypeConfiguration<ToggleValue>
{
    public void Configure(EntityTypeBuilder<ToggleValue> builder)
    {
        // Table name
        builder.ToTable("tblToggleValue");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();

        // Relationship
        builder.HasMany(a => a.RecruitFooterSettings)
            .WithOne(b => b.ToggleValue)
            .HasForeignKey(b => b.Id)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.RecruiterSettings)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.Id)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.RecruitCustomQuestionSettings)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.Id)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
        builder.HasMany(a => a.TicketAgents)
    .WithOne(b => b.ToggleValue)
    .HasForeignKey(b => b.Id)
    .IsRequired()  // Ensure Id is required
    .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
