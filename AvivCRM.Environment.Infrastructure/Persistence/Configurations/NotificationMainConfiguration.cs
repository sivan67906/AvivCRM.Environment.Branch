using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class NotificationMainConfiguration
    : BaseEntityConfiguration<NotificationMain>, IEntityTypeConfiguration<NotificationMain>
{
    public void Configure(EntityTypeBuilder<NotificationMain> builder)
    {
        // Table name
        builder.ToTable("tblNotificationMain");

        // call the base configuration
        base.Configure(builder);
    }
}