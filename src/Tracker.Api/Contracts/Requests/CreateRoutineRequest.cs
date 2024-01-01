namespace Tracker.Api.Contracts.Requests;

public record CreateRoutineRequest(string Name, int DurationInBlocks, int WorkoutDaysPerBlock);