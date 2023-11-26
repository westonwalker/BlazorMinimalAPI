using BlazorMinimalApis.Slices.Applications.Home.Handlers;
using BlazorMinimalApis.Slices.Lib;

namespace BlazorMinimalApis.Slices.Applications.Home;

public class Routes : IRouteDefinition
{
    public void Map(WebApplication app)
	{
		app.MapGet("/", new ShowHome().Show);

		app.MapGet("/random-number", new ShowHome().RandomNumber);

	}
}
