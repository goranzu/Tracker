namespace Tracker.Api.Contracts.Responses;

public sealed record WorkoutDayResponse(int Id, DateTime Date, int RoutineBlockId);