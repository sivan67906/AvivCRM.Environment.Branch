using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Ticket;

public class TicketGroupConfiguration
    : BaseEntityConfiguration<TicketGroup>, IEntityTypeConfiguration<TicketGroup>
{
    public void Configure(EntityTypeBuilder<TicketGroup> builder)
    {
        // Table name
        builder.ToTable("tblTicketGroup");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        // Relationship
        builder.HasMany(a => a.TicketAgents)
            .WithOne(b => b.TicketGroup)
            .HasForeignKey(b => b.GroupId)
            .IsRequired()  // Ensure Id is required
            .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete
    }
}
