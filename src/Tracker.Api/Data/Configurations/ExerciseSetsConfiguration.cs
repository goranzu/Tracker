using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data.Configurations;

public sealed class ExerciseSetsConfiguration : IEntityTypeConfiguration<ExerciseSet>
{
    public void Configure(EntityTypeBuilder<ExerciseSet> builder)
    {
        builder.Property(x => x.Reps)
            .IsRequired();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.HasOne<WorkoutDayExercises>()
            .WithMany(x => x.ExerciseSets);
    }
}