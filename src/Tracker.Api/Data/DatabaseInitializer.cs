using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data.Entities;
using Tracker.Api.Data.Enums;

namespace Tracker.Api.Data;

public sealed class DatabaseInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);

        var bench = new Exercise
        {
            Name = "Bench Press", ExerciseType = ExerciseType.Strength, TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var dumbbellPress = new Exercise
        {
            Name = "Dumbbell Press", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var fly = new Exercise
        {
            Name = "Chest Fly", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var dip = new Exercise
        {
            Name = "Dip", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var shoulderPress = new Exercise
        {
            Name = "Shoulder Press", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Shoulders
        };

        var latRaise = new Exercise
        {
            Name = "Lateral Raise", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Shoulders
        };

        var milPress = new Exercise
        {
            Name = "Military Press", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Shoulders
        };

        var cableRow = new Exercise
        {
            Name = "Cable Row", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var latPulldown = new Exercise
        {
            Name = "Lat Pulldown", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var facePull = new Exercise
        {
            Name = "Face Pull", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var dumbbellBicepCurl = new Exercise
        {
            Name = "Dumbbell Bicep Curl", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var cableCurl = new Exercise
        {
            Name = "Cable Bicep Curl", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var straightBar = new Exercise
        {
            Name = "Straight Bar Bicep Curl", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var dumbbellScullCrusher = new Exercise
        {
            Name = "Dumbbell Skull Crusher", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var pushDown = new Exercise
        {
            Name = "Cable Push-down", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var ropePushDown = new Exercise
        {
            Name = "Rope Push-down", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var overHeadExtension = new Exercise
        {
            Name = "Overhead Extension", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var squat = new Exercise
        {
            Name = "Squat", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var deadlift = new Exercise
        {
            Name = "Deadlift", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var bulgarianSplitSquat = new Exercise
        {
            Name = "Bulgarian Split Squat", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var stiffLefDeadlift = new Exercise
        {
            Name = "Stiff Leg Deadlift", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var calfRaise = new Exercise
        {
            Name = "Calf Raise", ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };


        var legPress = new Exercise
        {
            Name = "Leg Press",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var legExtension = new Exercise
        {
            Name = "Leg Extension",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var legCurl = new Exercise
        {
            Name = "Leg Curl",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var pecDeck = new Exercise
        {
            Name = "Pec Deck",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var seatedRow = new Exercise
        {
            Name = "Seated Row",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var barbellCurl = new Exercise
        {
            Name = "Barbell Curl",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var hammerCurl = new Exercise
        {
            Name = "Hammer Curl",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var tricepKickback = new Exercise
        {
            Name = "Tricep Kickback",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var lunges = new Exercise
        {
            Name = "Lunges",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };


        var calfRaisesSeated = new Exercise
        {
            Name = "Seated Calf Raise",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var hyperextensions = new Exercise
        {
            Name = "Hyperextensions",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var pullUps = new Exercise
        {
            Name = "Pull-Ups",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var barbellShrugs = new Exercise
        {
            Name = "Barbell Shrugs",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var legRaises = new Exercise
        {
            Name = "Leg Raises",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Abs
        };


        var bentOverRows = new Exercise
        {
            Name = "Bent Over Rows",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Back
        };

        var inclineBenchPress = new Exercise
        {
            Name = "Incline Bench Press",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Chest
        };

        var hackSquat = new Exercise
        {
            Name = "Hack Squat",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };

        var preacherCurls = new Exercise
        {
            Name = "Preacher Curls",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Biceps
        };

        var skullCrushers = new Exercise
        {
            Name = "Skull Crushers",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Triceps
        };

        var frontSquats = new Exercise
        {
            Name = "Front Squats",
            ExerciseType = ExerciseType.Strength,
            TargetMuscleGroup = TargetMuscleGroup.Legs
        };
        
        var exercises = new[]
        {
            bench, dumbbellPress, fly, dip, shoulderPress, latRaise, milPress, cableRow, latPulldown, facePull,
            dumbbellBicepCurl, cableCurl, straightBar, dumbbellScullCrusher, pushDown, overHeadExtension, squat,
            deadlift, bulgarianSplitSquat, stiffLefDeadlift, calfRaise, legPress, legExtension, legCurl, pecDeck,
            seatedRow, barbellCurl, hammerCurl, tricepKickback, lunges, calfRaisesSeated, hyperextensions, pullUps,
            barbellShrugs, legRaises, bentOverRows, inclineBenchPress,
            hackSquat, preacherCurls, skullCrushers, frontSquats
        };


        var dbExercises = await dbContext.Exercises.ToListAsync(cancellationToken: cancellationToken);

        foreach (var exercise in exercises)
        {
            if (dbExercises.All(x => x.Name != exercise.Name))
            {
                await dbContext.Exercises.AddAsync(exercise, cancellationToken);
            }
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}