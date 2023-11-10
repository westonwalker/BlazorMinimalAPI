using BlazorMinimalApis.Mvc.Controllers.Api;
using BlazorMinimalApis.Mvc.Lib;

namespace BlazorMinimalApis.Mvc.Routes;

public class Api : IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/api/contacts", new ContactApiController().List);
	}
}
