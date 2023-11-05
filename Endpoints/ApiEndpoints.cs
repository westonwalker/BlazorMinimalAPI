namespace BlazorMinimalApis.Endpoints;

public static class ApiEndpoints
{
	public static WebApplication MapApiEndpoints(this WebApplication app)
	{
		var api = app.MapGroup("/api");


        return app;
	}
}
