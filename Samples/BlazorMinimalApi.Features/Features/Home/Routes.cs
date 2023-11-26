using BlazorMinimalApis.Features.Features.Home.Handlers;
using BlazorMinimalApis.Features.Lib;

namespace BlazorMinimalApis.Features.Features.Home;

public class Routes : IRouteDefinition
{
    public void Map(WebApplication app)
	{
		app.MapGet("/", new ShowHome().Show);

		app.MapGet("/random-number", new ShowHome().RandomNumber);

	}
}
