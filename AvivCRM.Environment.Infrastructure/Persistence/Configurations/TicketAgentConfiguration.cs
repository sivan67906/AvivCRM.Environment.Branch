using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;
public class TicketAgentConfiguration
    : IEntityTypeConfiguration<TicketAgent>
{
    public void Configure(EntityTypeBuilder<TicketAgent> builder)
    {
        // Table name
        builder.ToTable("tblTicketAgent");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
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
        builder.HasOne(ci => ci.TicketGroup)
           .WithMany(s => s.TicketAgents)
           .HasForeignKey(ci => ci.GroupId)
           .IsRequired()  // Ensure GroupId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

        builder.HasOne(ci => ci.TicketType)
           .WithMany(s => s.TicketAgents)
           .HasForeignKey(ci => ci.TypeId)
           .IsRequired()  // Ensure TypeId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

        builder.HasOne(ci => ci.ToggleValue)
           .WithMany(s => s.TicketAgents)
           .HasForeignKey(ci => ci.StatusId)
           .IsRequired()  // Ensure StatusId is required
           .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}