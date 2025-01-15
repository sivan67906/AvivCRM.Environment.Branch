using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;
public class TicketAgentConfiguration
    : BaseEntityConfiguration<TicketAgent>, IEntityTypeConfiguration<TicketAgent>
{
    public void Configure(EntityTypeBuilder<TicketAgent> builder)
    {
        // Table name
        builder.ToTable("tblTicketAgent");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

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