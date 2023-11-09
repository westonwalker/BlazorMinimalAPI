using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Api.Contacts;

public class ListContacts : ApiController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/api/contacts", List);
	}
	
	public IResult List()
	{
		var data = new { Contacts = Database.Contacts };
		return Results.Ok(data);
	}
}
