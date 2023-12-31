using Tracker.Api.Contracts.Responses;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Features.WorkoutBlocks;

public static class Extensions
{
    public static RoutineBlockResponse AsWebResponse(this RoutineBlock routineBlock)
    {
        return new RoutineBlockResponse(routineBlock.Id, routineBlock.BlockNumber, routineBlock.RoutineId);
    }
}