using Serilog;
using Tracker.Api;
using Tracker.Api.Data;
using Tracker.Api.Features.Exercises.GetExercise;
using Tracker.Api.Features.Exercises.GetExercises;
using Tracker.Api.Shared;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

var commandHandlerType = typeof(ICommandHandler<>);
var queryHandlerType = typeof(IQueryHandler<,>);

var assembly = typeof(Program).Assembly;

foreach (var type in assembly.GetTypes())
{
    if (type.IsClass && !type.IsInterface && !type.IsAbstract)
    {
        var interfaces = type.GetInterfaces().Where(i => i.IsGenericType &&
                                                         (i.GetGenericTypeDefinition() == commandHandlerType ||
                                                          i.GetGenericTypeDefinition() == queryHandlerType));

        foreach (var itf in interfaces)
        {
            builder.Services.AddScoped(itf, type);
        }
    }
}

// Register Command and QueryHandler using Scrutor
// var assembly = typeof(Program).Assembly;
// builder.Services.Scan(x =>
//     x.FromAssemblies(assembly).AddClasses(c => c.AssignableToAny(typeof(ICommandHandler<>), typeof(IQueryHandler<,>)))
//         .AsImplementedInterfaces()
//         .WithScopedLifetime());

builder.Host.UseSerilog((_, loggerOptions) => { loggerOptions.WriteTo.Console(); });

builder.Services
    .AddData(builder.Configuration)
    .AddProblemDetails()
    .AddSpaStaticFiles(options => { options.RootPath = "wwwroot"; });

var app = builder.BuildWithSpa();

var apiGroup = app.MapGroup("/api");

apiGroup.MapGet("/exercises", GetExercises.RequestHandler);
apiGroup.MapGet("/exercises/{id:int}", GetExercise.HttpHandler);

app.Run();