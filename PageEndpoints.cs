using BlazorMinimalApis.Pages.Home;

namespace BlazorMinimalApis;

public static class PageEndpoints
{
    public static WebApplication MapPageEndpoints(this WebApplication app)
    {
        app.MapGet("/", new HomeHandler().Index)
            .WithName("Home");

        return app;
    }
}