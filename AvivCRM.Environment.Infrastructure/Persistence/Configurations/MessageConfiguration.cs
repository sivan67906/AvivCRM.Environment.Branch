using AvivCRM.Environment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivCRM.Environment.Infrastructure.Persistence.Configurations;

public class MessageConfiguration
    : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        // Table name
        builder.ToTable("tblMessage");

        // Primary key
        builder.HasKey(p => p.Id);

        // Properties
        builder.Property(p => p.AllowChatClientEmployee)
            .HasDefaultValue(false);

        builder.Property(p => p.All)
            .HasDefaultValue(false);

        builder.Property(p => p.OnlyProjectMembercanwithclient)
            .HasDefaultValue(false);

        builder.Property(p => p.Allowchatclientadmin)
            .HasDefaultValue(false);

        builder.Property(p => p.SoundNotifyAlert)
            .HasDefaultValue(false);

        builder.Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ModifiedOn)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAddOrUpdate();


    }
}
