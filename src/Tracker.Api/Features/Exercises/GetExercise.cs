using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data;
using Tracker.Api.Data.Models;
using Tracker.Api.Shared;
using Tracker.Api.Shared.Abstractions;

namespace Tracker.Api.Features.Exercises;

public static class GetExercise
{
    public static async Task<IResult> HttpHandler(IQueryHandler<GetExerciseQuery, Result<Exercise, Error>> handler,
        int id, CancellationToken ct)
    {
        var query = new GetExerciseQuery { Id = id, CancellationToken = ct };
        var result = await handler.HandleAsync(query);
        return result.Match<IResult>(
            exercise => Results.Ok(exercise.AsResponse()),
            error => Results.Problem(error.Message, null, error.StatusCode));
    }

    public sealed class GetExerciseQuery : IQuery<Result<Exercise, Error>>
    {
        public int Id { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }

    public sealed class GetExercisesHandler : IQueryHandler<GetExerciseQuery, Result<Exercise, Error>>
    {
        private readonly AppDbContext _dbContext;

        public GetExercisesHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Exercise, Error>> HandleAsync(GetExerciseQuery query)
        {
            var exercise = await _dbContext.Exercises
                .FindAsync([query.Id], cancellationToken: query.CancellationToken);
            return exercise is null ? new Error("Exercise Not Found", StatusCodes.Status404NotFound) : exercise;
        }
    }
}