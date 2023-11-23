using BlazorMinimalApis.Pages.Data;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Pages.Lib;

namespace BlazorMinimalApis.Pages.Pages.Contacts;

public class ListContacts : XController, IRouteDefinition
{
	public void Map(WebApplication app)
	{
		app.MapGet("/contacts", List)
			.WithName("Contacts");
	}
	
	public IResult List(HttpContext context)
	{
		var parameters = new { Contacts = Database.Contacts };
		return View<ListContactsPage>(parameters);
	}
}