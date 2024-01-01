using Tracker.Api.Contracts.Requests;
using Tracker.Api.Data;
using Tracker.Api.Data.Models;
using Tracker.Api.Shared.Abstractions;

namespace Tracker.Api.Features.Routines;

public static class CreateRoutine
{
    public static async Task<IResult> HttpHandler(CancellationToken ct, CreateRoutineRequest request,
        ICommandHandler<CreateRoutineCommand> commandHandler)
    {
        var command = new CreateRoutineCommand(request.Name, request.DurationInBlocks, request.WorkoutDaysPerBlock, ct);
        await commandHandler.HandleAsync(command);
        return Results.Created();
    }

    public sealed class CreateRoutineCommandHandler : ICommandHandler<CreateRoutineCommand>
    {
        private readonly AppDbContext _dbContext;

        public CreateRoutineCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task HandleAsync(CreateRoutineCommand command)
        {
            var (name, durationInBlocks, workoutDaysPerBlock, cancellationToken) = command;
            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var routine = new Routine { Name = name, DurationInBlocks = durationInBlocks };
                await _dbContext.Routines.AddAsync(routine, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                List<RoutineBlock> blocks = [];
                for (var i = 0; i < command.DurationInBlocks; i++)
                {
                    var block = new RoutineBlock { BlockNumber = i + 1, Routine = routine, RoutineId = routine.Id };
                    blocks.Add(block);
                }

                await _dbContext.RoutineBlocks.AddRangeAsync(blocks);
                await _dbContext.SaveChangesAsync(cancellationToken);

                List<WorkoutDay> workoutDays = [];
                foreach (var routineBlock in blocks)
                {
                    for (var i = 0; i < workoutDaysPerBlock; i++)
                    {
                        var workoutDay = new WorkoutDay
                            { RoutineBlock = routineBlock, RoutineBlockId = routineBlock.Id };
                        workoutDays.Add(workoutDay);
                    }
                }

                await _dbContext.WorkoutDays.AddRangeAsync(workoutDays, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }

    public sealed record CreateRoutineCommand(
        string Name,
        int DurationInBlocks,
        int WorkoutDaysPerBlock,
        CancellationToken CancellationToken)
        : ICommand;
}