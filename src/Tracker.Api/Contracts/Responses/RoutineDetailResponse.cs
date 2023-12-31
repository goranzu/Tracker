using Tracker.Api.Data.Models;

namespace Tracker.Api.Contracts.Responses;

public sealed record RoutineDetailResponse(int Id, string Name, int DurationInBlocks, List<RoutineBlockResponse> Blocks);