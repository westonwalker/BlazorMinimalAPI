using BlazorMinimalApis.Pages.Lib;
using BlazorMinimalApis.Pages.Pages.Api.Contacts;

namespace BlazorMinimalApis.Pages.Routes;

public class Api : IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/api/contacts", new ListContacts().Get);
	}
}
