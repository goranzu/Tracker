namespace Tracker.Api.Data.Models;

public sealed class Routine
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int DurationInBlocks { get; set; }

    public List<RoutineBlock> RoutineBlocks { get; set; } = [];
}