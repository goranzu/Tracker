using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data;
using Tracker.Api.Extensions;

namespace Tracker.Api.Handlers;

public static class ExerciseHandlers
{
    public static async Task<IResult> GetAllAsync(AppDbContext db)
    {
        var exercises = await db.Exercises.ToListAsync();

        var response = exercises.Select(exercise => exercise.MapToResponse());
        return Results.Ok(response);
    }

    public static async Task<IResult> GetByIdAsync(AppDbContext db, int id)
    {
        var exercise = await db.Exercises.FindAsync(id);
        if (exercise is null)
        {
            return Results.Problem("Exercise not found", null, StatusCodes.Status404NotFound);
        }

        var response = exercise.MapToResponse();
        return Results.Ok(response);
    }
}