using AvivCRM.Environment.Domain.Entities.Ticket;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations.Ticket;

public class TicketReplyTemplateConfiguration
    : BaseEntityConfiguration<TicketReplyTemplate>, IEntityTypeConfiguration<TicketReplyTemplate>
{
    public void Configure(EntityTypeBuilder<TicketReplyTemplate> builder)
    {
        // Table name
        builder.ToTable("tblTicketReplyTemplate");

        // call the base configuration
        base.Configure(builder);

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        // UTC Date as Default
        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();
    }
}
