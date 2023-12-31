using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data.Models;

namespace Tracker.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Exercise> Exercises => Set<Exercise>();
    public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();
    public DbSet<Routine> Routines => Set<Routine>();
    public DbSet<RoutineBlock> RoutineBlocks => Set<RoutineBlock>();
    public DbSet<WorkoutDay> WorkoutDays => Set<WorkoutDay>();
    public DbSet<WorkoutDayExercises> WorkoutDayExercises => Set<WorkoutDayExercises>();
}