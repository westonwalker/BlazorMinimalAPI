using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Api.Contacts;

public class ListContacts : XPage
{
	public override void Map(WebApplication app)
	{
		app.MapGet("/api/contacts", List);
	}
	
	public IResult List()
	{
		var data = new { Contacts = Database.Contacts };
		return Results.Ok(data);
	}
}
