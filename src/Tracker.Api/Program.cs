using Serilog;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

builder.Host.UseSerilog((_, loggerOptions) => { loggerOptions.WriteTo.Console(); });
builder.Services.AddSpaStaticFiles(options => { options.RootPath = "wwwroot"; });
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseStatusCodePages();
app.UseSpaStaticFiles();
app.UseRouting();
app.UseEndpoints(_ => { });

app.Use((context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/api"))
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        return Task.CompletedTask;
    }

    return next(context);
});

app.UseSpa(options =>
{
    if (app.Environment.IsDevelopment())
    {
        options.UseProxyToSpaDevelopmentServer("http://localhost:5173");
    }
});

var apiGroup = app.MapGroup("/api");
apiGroup.MapGet("/", () => "Hello World!");

app.Run();