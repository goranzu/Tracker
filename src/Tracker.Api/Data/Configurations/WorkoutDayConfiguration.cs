using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data.Configurations;

public sealed class WorkoutDayConfiguration : IEntityTypeConfiguration<WorkoutDay>
{
    public void Configure(EntityTypeBuilder<WorkoutDay> builder)
    {
        builder.Property(x => x.Date)
            .IsRequired();

        builder.HasOne<RoutineBlock>()
            .WithMany(x => x.WorkoutDays);

        builder.HasMany<WorkoutDayExercises>()
            .WithOne(x => x.WorkoutDay);
    }
}