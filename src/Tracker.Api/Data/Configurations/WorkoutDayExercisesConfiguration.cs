using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data.Configurations;

public sealed class WorkoutDayExercisesConfiguration : IEntityTypeConfiguration<WorkoutDayExercises>
{
    public void Configure(EntityTypeBuilder<WorkoutDayExercises> builder)
    {
        builder.HasMany<ExerciseSet>()
            .WithOne(x => x.WorkoutDayExercises);

        builder.HasOne<WorkoutDay>()
            .WithMany(x => x.WorkoutDayExercises);

        builder.HasOne<Exercise>()
            .WithMany(x => x.WorkoutDayExercises);
    }
}