using Tracker.Api.Middleware;

namespace Tracker.Api;

public static class Extensions
{
    public static WebApplication BuildWithSpa(this WebApplicationBuilder builder)
    {
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
        app.UseMiddleware<ApiPathMiddleware>();

        app.UseSpa(options =>
        {
            if (app.Environment.IsDevelopment())
            {
                options.UseProxyToSpaDevelopmentServer("http://localhost:5173");
            }
        });

        return app;
    }
}