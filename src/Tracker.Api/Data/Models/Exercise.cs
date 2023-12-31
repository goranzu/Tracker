using Tracker.Api.Data.Enums;

namespace Tracker.Api.Data.Models;

public sealed class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ExerciseType ExerciseType { get; set; }
    public TargetMuscleGroup TargetMuscleGroup { get; set; }
    public List<WorkoutDayExercises> WorkoutDayExercises { get; set; } = [];
}