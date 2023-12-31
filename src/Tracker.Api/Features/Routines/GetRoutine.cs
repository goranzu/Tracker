using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data;
using Tracker.Api.Data.Models;
using Tracker.Api.Shared;
using Tracker.Api.Shared.Abstractions;

namespace Tracker.Api.Features.Routines;

public static class GetRoutine
{
    public static async Task<IResult> HttpHandler(CancellationToken ct, int id,
        IQueryHandler<GetRoutineQuery, Result<Routine, Error>> handler)
    {
        var query = new GetRoutineQuery(id, ct);
        var result = await handler.HandleAsync(query);

        return result.Match(routine => Results.Ok(routine.AsRoutineDetailWebResponse()),
            error => Results.Problem(error.Message, null, error.StatusCode));
    }

    public sealed class GetRoutineQueryHandler : IQueryHandler<GetRoutineQuery, Result<Routine, Error>>
    {
        private readonly AppDbContext _dbContext;

        public GetRoutineQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Routine, Error>> HandleAsync(GetRoutineQuery query)
        {
            var routine = await _dbContext.Routines
                .Where(x => x.Id == query.Id)
                .Include(x => x.RoutineBlocks)
                .SingleOrDefaultAsync(cancellationToken: query.CancellationToken);

            if (routine is null)
            {
                return new Error("Routine not found", StatusCodes.Status404NotFound);
            }

            return routine;
        }
    }

    public sealed record GetRoutineQuery(int Id, CancellationToken CancellationToken) : IQuery<Result<Routine, Error>>;
}