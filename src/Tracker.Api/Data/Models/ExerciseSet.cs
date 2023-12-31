namespace Tracker.Api.Data.Models;

public sealed class ExerciseSet
{
    public int Id { get; set; }
    public int Reps { get; set; }
    public int Weight { get; set; }

    public WorkoutDayExercises WorkoutDayExercises { get; set; } = null!;
    public int WorkoutDayExercisesId { get; set; }
}