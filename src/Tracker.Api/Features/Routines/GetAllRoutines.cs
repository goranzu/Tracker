using Microsoft.EntityFrameworkCore;
using Tracker.Api.Data;
using Tracker.Api.Data.Models;
using Tracker.Api.Shared.Abstractions;

namespace Tracker.Api.Features.Routines;

public static class GetAllRoutines
{
    public static async Task<IResult> HttpHandler(CancellationToken cancellationToken,
        IQueryHandler<GetAllRoutinesQuery, List<Routine>> handler)
    {
        var query = new GetAllRoutinesQuery(cancellationToken);
        var routines = await handler.HandleAsync(query);

        var response = routines.Select(x => x.AsWebResponse());
        return Results.Ok(response);
    }

    public sealed class GetAllRoutinesQueryHandler : IQueryHandler<GetAllRoutinesQuery, List<Routine>>
    {
        private readonly AppDbContext _dbContext;

        public GetAllRoutinesQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Routine>> HandleAsync(GetAllRoutinesQuery query)
        {
            var routines = await _dbContext.Routines
                .AsNoTracking()
                .ToListAsync(cancellationToken: query.CancellationToken);
            return routines;
        }
    }

    public sealed record GetAllRoutinesQuery(CancellationToken CancellationToken) : IQuery<List<Routine>>;
}