namespace Tracker.Api.Data.Models;

public sealed class WorkoutDay
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public RoutineBlock RoutineBlock { get; set; } = null!;
    public int RoutineBlockId { get; set; }

    public List<WorkoutDayExercises> WorkoutDayExercises { get; set; } = [];
}