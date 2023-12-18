using Tracker.Api.Data;
using Tracker.Api.Data.Entities;
using Tracker.Api.Data.Enums;
using Tracker.Api.Handlers;
using Tracker.Api.Handlers.Responses;

namespace Tracker.Api.Extensions;

public static class ExerciseExtensions
{
    public static ExerciseResponse MapToResponse(this Exercise exercise)
    {
        var type = exercise.ExerciseType switch
        {
            ExerciseType.Cardio => "cardio",
            ExerciseType.Strength => "strength",
            _ => throw new ArgumentOutOfRangeException()
        };

        var muscleGroup = exercise.TargetMuscleGroup switch
        {
            TargetMuscleGroup.Legs => "legs",
            TargetMuscleGroup.Chest => "chest",
            TargetMuscleGroup.Back => "back",
            TargetMuscleGroup.Biceps => "biceps",
            TargetMuscleGroup.Triceps => "triceps",
            TargetMuscleGroup.Shoulders => "shoulders",
            TargetMuscleGroup.Abs => "abs",
            _ => throw new ArgumentOutOfRangeException()
        };

        var response = new ExerciseResponse(exercise.Id, exercise.Name, type, muscleGroup);
        return response;
    }
}