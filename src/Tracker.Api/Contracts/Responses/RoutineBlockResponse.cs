using Tracker.Api.Data.Models;

namespace Tracker.Api.Contracts.Responses;

public sealed record RoutineBlockResponse(int Id, int BlockNumber, int RoutineId, List<WorkoutDayResponse> WorkoutDays);