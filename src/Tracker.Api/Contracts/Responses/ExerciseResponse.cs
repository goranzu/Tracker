namespace Tracker.Api.Contracts.Responses;

public sealed record ExerciseResponse(int Id, string Name, string ExerciseType, string TargetMuscleGroup);