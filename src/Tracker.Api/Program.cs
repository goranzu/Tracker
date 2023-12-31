using Serilog;
using Tracker.Api;
using Tracker.Api.Data;
using Tracker.Api.Features.Exercises;
using Tracker.Api.Features.Routines;
using Tracker.Api.Middleware;
using Tracker.Api.Shared.Abstractions;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

var commandHandlerType = typeof(ICommandHandler<>);
var queryHandlerType = typeof(IQueryHandler<,>);
var assembly = typeof(Program).Assembly;

foreach (var type in assembly.GetTypes()
             .Where(type => type is { IsClass: true, IsAbstract: false, IsInterface: false } &&
                            type.Name.EndsWith("Handler")))
{
    var interfaces = type.GetInterfaces().Where(itf =>
        itf is { IsGenericType: true } && (itf.GetGenericTypeDefinition() == commandHandlerType ||
                                           itf.GetGenericTypeDefinition() == queryHandlerType));
    foreach (var itf in interfaces)
    {
        builder.Services.AddScoped(itf, type);
    }
}

// var commandHandlerType = typeof(ICommandHandler<>);
// var queryHandlerType = typeof(IQueryHandler<,>);
// var assembly = typeof(Program).Assembly;
//
// foreach (var type in assembly.GetTypes()
//              .Where(x => x is { IsClass: true, IsAbstract: false, IsInterface: false }))
// {
//     var interfaces = type.GetInterfaces().Where(x =>
//         x is { IsGenericType: true } && (x.GetGenericTypeDefinition() == commandHandlerType ||
//                                          x.GetGenericTypeDefinition() == queryHandlerType));
//
//     foreach (var itf in interfaces)
//     {
//         builder.Services.AddScoped(itf, type);
//     }
// }

// var commandHandlerType = typeof(ICommandHandler<>);
// var queryHandlerType = typeof(IQueryHandler<,>);
//
// var assembly = typeof(Program).Assembly;
//
// foreach (var type in assembly.GetTypes())
// {
//     if (type.IsClass && !type.IsInterface && !type.IsAbstract)
//     {
//         var interfaces = type.GetInterfaces().Where(i => i.IsGenericType &&
//                                                          (i.GetGenericTypeDefinition() == commandHandlerType ||
//                                                           i.GetGenericTypeDefinition() == queryHandlerType));
//
//         foreach (var itf in interfaces)
//         {
//             builder.Services.AddScoped(itf, type);
//         }
//     }
// }

// Register Command and QueryHandler using Scrutor
// var assembly = typeof(Program).Assembly;
// builder.Services.Scan(x =>
//     x.FromAssemblies(assembly).AddClasses(c => c.AssignableToAny(typeof(ICommandHandler<>), typeof(IQueryHandler<,>)))
//         .AsImplementedInterfaces()
//         .WithScopedLifetime());
//
// builder.Services.TryDecorate(typeof(ICommandHandler<>), typeof(CommandHandlerWithUnitOfWork<>));

builder.Host.UseSerilog((_, loggerOptions) => { loggerOptions.WriteTo.Console(); });

builder.Services
    .AddSingleton<ApiPathMiddleware>()
    .AddData(builder.Configuration)
    .AddProblemDetails()
    .AddSpaStaticFiles(options => { options.RootPath = "wwwroot"; });

var app = builder.BuildWithSpa();

var apiGroup = app.MapGroup("/api");

apiGroup.MapGet("/exercises", GetExercises.RequestHandler);
apiGroup.MapGet("/exercises/{id:int}", GetExercise.HttpHandler);
apiGroup.MapPost("/routines", CreateRoutine.HttpHandler);
apiGroup.MapGet("/routines", GetAllRoutines.HttpHandler);
apiGroup.MapGet("/routines/{id:int}", GetRoutine.HttpHandler);

app.Run();