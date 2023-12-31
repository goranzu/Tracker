using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data.Configurations;

public sealed class RoutineBlockConfiguration : IEntityTypeConfiguration<RoutineBlock>
{
    public void Configure(EntityTypeBuilder<RoutineBlock> builder)
    {
        builder.Property(x => x.BlockNumber)
            .IsRequired();

        builder.HasOne<Routine>()
            .WithMany(x => x.RoutineBlocks);

        builder.HasMany<WorkoutDay>()
            .WithOne(x => x.RoutineBlock);
    }
}