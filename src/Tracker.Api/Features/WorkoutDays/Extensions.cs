using Tracker.Api.Contracts.Responses;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Features.WorkoutDays;

public static class Extensions
{
   public static WorkoutDayResponse AsWebResponse(this WorkoutDay workoutDay)
   {
      return new WorkoutDayResponse(workoutDay.Id, workoutDay.Date, workoutDay.RoutineBlockId);
   }
}