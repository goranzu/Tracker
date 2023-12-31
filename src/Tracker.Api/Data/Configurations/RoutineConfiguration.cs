using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data.Configurations;

public sealed class RoutineConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.DurationInBlocks)
            .IsRequired();

        builder.HasMany<RoutineBlock>()
            .WithOne(x => x.Routine);
    }
}