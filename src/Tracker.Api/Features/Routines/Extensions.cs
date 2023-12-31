using Tracker.Api.Contracts.Responses;
using Tracker.Api.Data.Models;
using Tracker.Api.Features.WorkoutBlocks;

namespace Tracker.Api.Features.Routines;

public static class Extensions
{
    public static RoutineResponse AsWebResponse(this Routine routine)
    {
        return new RoutineResponse(routine.Id, routine.Name, routine.DurationInBlocks);
    }

    public static RoutineDetailResponse AsRoutineDetailWebResponse(this Routine routine)
    {
        var blocks = routine.RoutineBlocks
            .Select(x => x.AsWebResponse())
            .ToList();
        return new RoutineDetailResponse(routine.Id, routine.Name, routine.DurationInBlocks, blocks);
    }
}