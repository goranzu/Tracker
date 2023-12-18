namespace Tracker.Api.Handlers.Responses;

public sealed record ExerciseResponse(int Id, string Name, string ExerciseType, string TargetMuscleGroup);