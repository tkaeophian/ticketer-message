using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticketer.Message.Core.ContributorAggregate;

namespace Ticketer.Message.Infrastructure.Data.Config;

public class MessageConfiguration : IEntityTypeConfiguration<Core.MessageAggregate.Message>
{
    public void Configure(EntityTypeBuilder<Core.MessageAggregate.Message> builder)
    {
        // builder.Property(p => p.Content)
        //     .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        //     .IsRequired();
    }
}
