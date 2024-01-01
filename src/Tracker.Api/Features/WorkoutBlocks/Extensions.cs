using Tracker.Api.Contracts.Responses;
using Tracker.Api.Data.Models;
using Tracker.Api.Features.WorkoutDays;

namespace Tracker.Api.Features.WorkoutBlocks;

public static class Extensions
{
    public static RoutineBlockResponse AsWebResponse(this RoutineBlock routineBlock)
    {
        var workoutDays = routineBlock.WorkoutDays
            .Select(x => x.AsWebResponse())
            .ToList();
        return new RoutineBlockResponse(routineBlock.Id, routineBlock.BlockNumber, routineBlock.RoutineId, workoutDays);
    }
}