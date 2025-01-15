using AvivCRM.Environment.Domain.Entities;
using AvivCRM.Environment.Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class MessageConfiguration
    : BaseEntityConfiguration<Message>, IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        // Table name
        builder.ToTable("tblMessage");

        // Properties
        builder.Property(p => p.AllowChatClientEmployee)
            .HasDefaultValue(false);

        builder.Property(p => p.All)
            .HasDefaultValue(false);

        builder.Property(p => p.OnlyProjectMembercanwithclient)
            .HasDefaultValue(false);

        builder.Property(p => p.Allowchatclientadmin)
            .HasDefaultValue(false);

    }
}
