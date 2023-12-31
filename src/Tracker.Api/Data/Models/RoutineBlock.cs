namespace Tracker.Api.Data.Models;

public sealed class RoutineBlock
{
    public int Id { get; set; }
    public int BlockNumber { get; set; }

    public Routine Routine { get; set; } = null!;
    public int RoutineId { get; set; }

    public List<WorkoutDay> WorkoutDays { get; set; } = [];
}