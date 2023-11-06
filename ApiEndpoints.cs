using BlazorMinimalApis.Api.Example;
using BlazorMinimalApis.Api.Identity;

namespace BlazorMinimalApis;

public static class ApiEndpoints
{
    public static WebApplication MapApiEndpoints(this WebApplication app)
    {
        var api = app.MapGroup("/api");

        // maps to /api/example
        api.MapGet("/example", ExampleHandler.Index);

        return app;
    }

    public static WebApplication MapIdentityEndpoints(this WebApplication app)
    {
        app.MapGet("/account/login", new IdentityHandler().Login)
            .WithName("Identity.Login").AllowAnonymous();

        app.MapGet("/account/logout", new IdentityHandler().Logout)
            .WithName("Identity.Logout");

        return app;
    }
}
