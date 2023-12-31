namespace Tracker.Api.Data.Models;

public sealed class WorkoutDayExercises
{
    public int Id { get; set; }

    public WorkoutDay WorkoutDay { get; set; } = null!;
    public int WorkoutDayId { get; set; }

    public Exercise Exercise { get; set; } = null!;
    public int ExerciseId { get; set; }

    public List<ExerciseSet> ExerciseSets { get; set; } = [];
}