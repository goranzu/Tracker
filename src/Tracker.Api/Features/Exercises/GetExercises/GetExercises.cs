using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data;
using Tracker.Api.Data.Models;
using Tracker.Api.Shared;

namespace Tracker.Api.Features.Exercises.GetExercises;

public static class GetExercises
{
    public static async Task<IResult> RequestHandler(CancellationToken ct,
        IQueryHandler<GetExercisesQuery, IEnumerable<Exercise>> handler)
    {
        var query = new GetExercisesQuery { CancellationToken = ct };
        var exercises = await handler.HandleAsync(query);
        var response = exercises.Select(x => x.AsResponse());
        return Results.Ok(response);
    }

    public sealed class GetExercisesQuery : IQuery<IEnumerable<Exercise>>
    {
        public CancellationToken CancellationToken { get; set; }
    }

    public sealed class GetExercisesHandler : IQueryHandler<GetExercisesQuery, IEnumerable<Exercise>>
    {
        private readonly AppDbContext _dbContext;

        public GetExercisesHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Exercise>> HandleAsync(GetExercisesQuery query)
        {
            var exercises = await _dbContext.Exercises.ToListAsync(query.CancellationToken);
            return exercises;
        }
    }
}