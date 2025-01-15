using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Ticket;

public class TicketChannelConfiguration
    : BaseEntityConfiguration<TicketChannel>, IEntityTypeConfiguration<TicketChannel>
{
    public void Configure(EntityTypeBuilder<TicketChannel> builder)
    {
        // Table name
        builder.ToTable("tblTicketChannel");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}