using Tracker.Api.Data.Enums;

namespace Tracker.Api.Data.Entities;

public sealed class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ExerciseType ExerciseType { get; set; }
    public TargetMuscleGroup TargetMuscleGroup { get; set; }
}